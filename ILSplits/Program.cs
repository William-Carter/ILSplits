// See https://aka.ms/new-console-template for more information
using DemoParser.Parser;
using DemoParser.Utils;
using DemoParser.Parser.Components.Packets;

namespace ILSplits
{
    public static class Program
    {
        public static void Main(string[] args)
        {

            if (args.Length <= 0)            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No demo!");
                Console.ReadLine();
                return;
            }

            SourceDemo demo = new SourceDemo(args[0]);

            demo.Parse();

            float startOffset = 0.0f;
            if (demo.Header.MapName == "testchmb_a_00")
            {
                if (demo.StartAdjustmentTick == 0)
                {
                    startOffset = 53.025f;
                }
                else
                {
                    startOffset = -((float)demo.StartAdjustmentTick * 0.015f);
                }
            }
            
            List<(int Tick, CmdInfo locationInfo)> positions = demo.FilterForPacket<Packet>().Select(packet => (packet.Tick, locationInfo: packet.PacketInfo[0])).ToList();
            

            // Filter the list of every split down to just the ones on the current map
            string map = demo.Header.MapName;
            LevelSplits ls = new LevelSplits();

            List<Split> relevantSplits = new List<Split>();
            foreach (Split split in ls.levelSplits)
            {
                if (split.Map == map)
                {
                    relevantSplits.Add(split);
                }
            }

            List<ActivatedSplit> activatedSplits = new List<ActivatedSplit>();

            foreach ((int Tick, CmdInfo locationInfo) position in positions)
            {
                foreach (Split split in relevantSplits)
                {

                    if (split.GetType() == typeof(BoundedSplit) && !((BoundedSplit)split).CheckPointBounded(position.locationInfo.ViewOrigin))
                    {
                        continue;
                    }
                   
                    if (split.Activated) // Don't add it if we already did
                    {
                        continue;
                    }
                    split.increment();
                    if (split.Activated) // only add it if it just became activated
                    {
                        activatedSplits.Add(new ActivatedSplit(split.Name, position.Tick));
                    }
                }
                }

            float previousSplit = 0f;
            foreach (ActivatedSplit split in activatedSplits)
            {
                float timeActivated = split.TimeActivated;
                timeActivated += startOffset;
                string segmentTime = FormatDuration(timeActivated - previousSplit);
             
                string formattedTime = FormatDuration(timeActivated);
                
                Console.WriteLine(split.Name.PadRight(25) + formattedTime + " ("+segmentTime+")");
                previousSplit = timeActivated;

            }
            string finalSegment = FormatDuration(demo.AdjustedTickCount(true) * 0.015f - previousSplit);
            string finalTime = FormatDuration(demo.AdjustedTickCount(true)*0.015f);
            Console.WriteLine("\nFinal Time: "+finalTime + " ("+finalSegment+")");

            

            Console.ReadLine();
        }

        /// <summary>
        /// Formats a duration given in seconds into a string representation with minutes, seconds, and milliseconds.
        /// </summary>
        /// <param name="duration">The duration in seconds to format.</param>
        /// <returns>A string representing the formatted duration in the format "M:SS.mmm" or "SS.mmm" if less than a minute.</returns>
        public static string FormatDuration(float duration)
        {
            string output = string.Empty;
            int seconds = (int)duration % 60;
            int ms = (int)(float.Round(duration % 60 - seconds, 3) * 1000);
            int minutes = (int)duration / 60;

            string secondsString = seconds.ToString();

            if (minutes > 0)
            {
                output += minutes.ToString() + ":";
                secondsString = secondsString.PadLeft(2, '0');
            }
            output += secondsString + ".";
            output += ms.ToString().PadLeft(3, '0');

            return output;
        }


    }
}   