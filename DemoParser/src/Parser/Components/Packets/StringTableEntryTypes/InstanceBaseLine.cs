#nullable enable
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using DemoParser.Parser.Components.Messages;
using DemoParser.Parser.HelperClasses;
using DemoParser.Parser.HelperClasses.EntityStuff;
using DemoParser.Utils;
using DemoParser.Utils.BitStreams;

namespace DemoParser.Parser.Components.Packets.StringTableEntryTypes {
	
	// this is the baseline in the string tables, each one only holds the baseline for a single server class
	public class InstanceBaseLine : StringTableEntryData {

		private readonly string _entryName;
		private BitStreamReader _bsr;
		// might not get set until later
		private PropLookup? _propLookup;
		public ServerClass? ServerClassRef;
		public List<(int propIndex, EntityProperty prop)> Properties;


		public InstanceBaseLine(SourceDemo demoRef, BitStreamReader reader, string entryName,
			PropLookup? propLookup) : base(demoRef, reader, entryName) 
		{
			_entryName = entryName;
			_propLookup = propLookup;
		}
		
		 // if we're parsing this before the data tables, just leave it for now
		internal override void ParseStream(BitStreamReader bsr) {
			_bsr = bsr;
			if (_propLookup != null)
				ParseBaseLineData(_propLookup);
		}

		
		// called once 
		internal void ParseBaseLineData([NotNull]PropLookup propLookup) {

			_propLookup = propLookup;
			int id = int.Parse(_entryName);
			ServerClassRef = _propLookup[id].serverClass;

			// I assume in critical parts of the ent code that the server class ID matches the index it's on,
			// this is where I actually verify this.
			Debug.Assert(ReferenceEquals(ServerClassRef, _propLookup.Single(tuple => tuple.serverClass.DataTableId == id).serverClass),
				"the server classes must be searched to match ID; cannot use ID as index");
			
			List<FlattenedProp> fProps = propLookup[id].flattenedProps;

			try {
				Properties = _bsr.ReadEntProps(fProps, DemoRef);
				// once we're done, update the C_baselines so I can actually use this for prop creation
				DemoRef.CBaseLines?.UpdateBaseLine(ServerClassRef, Properties, fProps.Count);
			} catch (Exception e) {
				DemoRef.AddError($"error while parsing baseline for class {ServerClassRef.ClassName}: {e.Message}");
			}
		}


		public override void AppendToWriter(IndentedWriter iw) {
			if (ServerClassRef != null) {
				iw.AppendLine($"class: {ServerClassRef.ClassName} ({ServerClassRef.DataTableName})");
				if (Debugger.IsAttached)
					iw.AppendLine($"[DEBUG_ONLY] bits: {Reader.BitLength}");
				iw.Append("props:");
				iw.AddIndent();
				if (Properties != null) {
					foreach ((int i, EntityProperty prop) in Properties) {
						iw.AppendLine();
						iw.Append($"({i}) ");
						prop.AppendToWriter(iw);
					}
				} else {
					iw.Append("\nerror during parsing");
				}
				iw.SubIndent();
			}
		}
	}
}