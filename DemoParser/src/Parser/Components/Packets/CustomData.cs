#nullable enable
using System;
using DemoParser.Parser.Components.Abstract;
using DemoParser.Parser.Components.Packets.CustomDataTypes;
using DemoParser.Utils;
using DemoParser.Utils.BitStreams;

namespace DemoParser.Parser.Components.Packets {
	
	/// <summary>
	/// Contains a single custom game message.
	/// </summary>
	public class CustomData : DemoPacket {

		public CustomDataType DataType;
		public CustomDataMessage DataMessage;


		public CustomData(SourceDemo? demoRef, int tick) : base(demoRef, tick) {}


		protected override void Parse(ref BitStreamReader bsr) {
			DataType = (CustomDataType)bsr.ReadSInt();
			uint size = bsr.ReadUInt();
			DataMessage = CustomDataFactory.CreateCustomDataMessage(DemoRef, DataType);
			try {
				DataMessage.ParseStream(bsr.SplitAndSkip(size * 8));
			} catch (Exception e) {
				DemoRef.LogError($"error while parsing custom data of type: {DataType}... {e.Message}");
				DataMessage = new UnknownCustomDataMessage(DemoRef);
			}
		}
		

		internal override void WriteToStreamWriter(BitStreamWriter bsw) {
			throw new NotImplementedException();
		}


		public override void AppendToWriter(IndentedWriter iw) {
			iw.Append($"type: {DataType}");
			iw.FutureIndent++;
			iw.AppendLine();
			DataMessage.AppendToWriter(iw);
			iw.FutureIndent--;
		}
	}
}