using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace ILSplits
{
    public class LevelSplits
    {
        public List<Split> levelSplits;


        public LevelSplits()
        {
            levelSplits = new List<Split>
            {
				/* testchmb_a_00 */
                new BoundedSplit(
                    "testchmb_a_00",
                    "00 Vault exit",
                    new Vector3(-638, -417, 392),
                    new Vector3(-830, -191, 133),
                    1
                ),
                new BoundedSplit(
                    "testchmb_a_00",
                    "00 Door Close",
                    new Vector3(-900, -792, 0),
                    new Vector3(-300, -1200, 500),
                    1
                ),
                new BoundedSplit(
                    "testchmb_a_00",
                    "00 Ele Activated",
                    new Vector3(-1456, -1081, 0),
                    new Vector3(-1598, -722, 450),
                    1
                ),
                new BoundedSplit(
                    "testchmb_a_00",
                    "01 Ele Exit",
                    new Vector3(-1434.74f, -1000, 680),
                    new Vector3(-1410, -700, 900),
                    1
                ),
                new BoundedSplit(
                    "testchmb_a_00",
                    "01 Carousel Activate",
                    new Vector3(-908, -392, 672),
                    new Vector3(-1301, -644, 570),
                    1
                ),
                new BoundedSplit(
                    "testchmb_a_00",
                    "01 Enter End Room",
                    new Vector3(-1368, -135, 760),
                    new Vector3(-824, -296, 584),
                    1
                ),
                new BoundedSplit(
                    "testchmb_a_00",
                    "01 Ele Activated",
                    new Vector3(-400, -117, 554),
                    new Vector3(-282, -356, 809),
                    1
                ),
				
				
				/* testchmb_a_01 */
                new BoundedSplit(
                    "testchmb_a_01",
                    "02 Dialogue",
                    new Vector3(568, 0, 0),
                    new Vector3(515, 130, 134),
                    1
                ),
                new BoundedSplit(
                    "testchmb_a_01",
                    "02 PGun Floor",
                    new Vector3(-126, 382, -110),
                    new Vector3(317, -61, -64),
                    1
                ),
                new BoundedSplit(
                    "testchmb_a_01",
                    "02 Ele Activated",
                    new Vector3(-125, -352, 7),
                    new Vector3(-349, -465, 192),
                    1
                ),
                new BoundedSplit(
                    "testchmb_a_01",
                    "03 Portal Triggered",
                    new Vector3(-304, -130, 580),
                    new Vector3(-563, 92, 830),
                    1
                ),
                new BoundedSplit(
                    "testchmb_a_01",
                    "03 Ele Activated",
                    new Vector3(-1888, 782, 600),
                    new Vector3(-2000, 1000, 750),
                    1
                ),
				
				/* testchmb_a_02 */
                new BoundedSplit(
                    "testchmb_a_02",
                    "04 Portal Triggered",
                    new Vector3(896, 63, -10),
                    new Vector3(-831, 317, 253),
                    1
                ),
                new BoundedSplit(
                    "testchmb_a_02",
                    "04 Pit Bottom",
                    new Vector3(112, 112, -192),
                    new Vector3(-112, -112, -230),
                    1
                ),
                new BoundedSplit(
                    "testchmb_a_02",
                    "04 Ele Activated",
                    new Vector3(880, 300, 0),
                    new Vector3(1000, 90, 256),
                    1
                ),
                new BoundedSplit(
                    "testchmb_a_02",
                    "05 Portal Triggered",
                    new Vector3(544, 400, 580),
                    new Vector3(352, 528, 720),
                    1
                ),
                new BoundedSplit(
                    "testchmb_a_02",
                    "05 End Room",
                    new Vector3(-28, 710, 568),
                    new Vector3(213, 961, 705),
                    1
                ),
				
				/* testchmb_a_03 */
                new BoundedSplit(
                    "testchmb_a_03",
                    "06 Portal Timer",
                    new Vector3(-651.9999f, -100, -127),
                    new Vector3(-645, 100, 0),
                    1
                ),

                new BoundedSplit(
                    "testchmb_a_03",
                    "06 Exit Ceiling Portal",
                    new Vector3(192, 128, 260),
                    new Vector3(93, -110, 250),
                    1
                ),

                new BoundedSplit(
                    "testchmb_a_03",
                    "06 Ele Activated",
                    new Vector3(688, 100, 0),
                    new Vector3(800, -100, 256),
                    1
                ),

                new BoundedSplit(
                    "testchmb_a_03",
                    "07 Ele Exit",
                    new Vector3(665.73f, 128, 1380),
                    new Vector3(600, -128, 1540),
                    1
                ),

                new BoundedSplit(
                    "testchmb_a_03",
                    "07 End Platform",
                    new Vector3(-512, 325, 1345),
                    new Vector3(-646, 53, 1606),
                    1
                ),

                new BoundedSplit(
                    "testchmb_a_03",
                    "07 Ele Activated",
                    new Vector3(-944, 320, 1350),
                    new Vector3(-1050, 75, 1561),
                    1
                ),
				
				
				/* testchmb_a_04 */
                new BoundedSplit(
                    "testchmb_a_04",
                    "08 Ele Exit",
                    new Vector3(-1050.24f, -50, 18),
                    new Vector3(-933, 183, 132),
                    1
                ),

                new BoundedSplit(
                    "testchmb_a_04",
                    "08 Portal Timer",
                    new Vector3(-415.9999f, 43, 13),
                    new Vector3(-350, 188, 250),
                    1
                ),

                new BoundedSplit(
                    "testchmb_a_04",
                    "08 End Dialogue",
                    new Vector3(544, -127, 6),
                    new Vector3(626, 189, 130),
                    1
                ),

                new BoundedSplit(
                    "testchmb_a_04",
                    "08 Ele Activated",
                    new Vector3(944, 256, 4),
                    new Vector3(1020, 12, 190),
                    1
                ),
				
				/* testchmb_a_05 */
                new BoundedSplit(
                    "testchmb_a_05",
                    "09 Portal Timer",
                    new Vector3(784, 0, 0),
                    new Vector3(650, -128, 128),
                    1
                ),

                new BoundedSplit(
                    "testchmb_a_05",
                    "09 Ele Activated",
                    new Vector3(-416, 700, 7),
                    new Vector3(-544, 950, 200),
                    1
                ),

                new BoundedSplit(
                    "testchmb_a_05",
                    "09 Ele Come Down",
                    new Vector3(0, 688, 0),
                    new Vector3(128, 784, 128),
                    1
                ),
				

				/* testchmb_a_06 */
                new BoundedSplit(
                    "testchmb_a_06",
                    "10 First Room",
                    new Vector3(-1601, -1, -1),
                    new Vector3(-1503, 257, 129),
                    1
                ),

                new BoundedSplit(
                    "testchmb_a_06",
                    "10 Middle Room",
                    new Vector3(-1089, -1, 127),
                    new Vector3(-1007, 257, 257),
                    1
                ),

                new BoundedSplit(
                    "testchmb_a_06",
                    "10 End Room",
                    new Vector3(127, -65, -33),
                    new Vector3(898.5f, 321, 385),
                    1
                ),

                new BoundedSplit(
                    "testchmb_a_06",
                    "10 End Platform",
                    new Vector3(1024, -65, 383),
                    new Vector3(1409, 321, 641),
                    1
                ),

                new BoundedSplit(
                    "testchmb_a_06",
                    "10 Ele Activated",
                    new Vector3(1711, 63, 399),
                    new Vector3(1777, 193, 486),
                    1
                ),	
				
				
				/* testchmb_a_07 */
                new BoundedSplit(
                    "testchmb_a_07",
                    "11 Portal Gun Platform",
                    new Vector3(-257, -449, 127),
                    new Vector3(-131, -351, 241),
                    1
                ),

                new BoundedSplit(
                    "testchmb_a_07",
                    "11 End Room",
                    new Vector3(-385, -1185, 255),
                    new Vector3(-63, -799, 513),
                    1
                ),

                new BoundedSplit(
                    "testchmb_a_07",
                    "11 Ele Activated",
                    new Vector3(-809, -1185, 271),
                    new Vector3(-751, -1055, 358),
                    1
                ),

                new BoundedSplit(
                    "testchmb_a_07",
                    "12 Pit",
                    new Vector3(431.97f, -1519.97f, 500),
                    new Vector3(-47.97f, -1232, 600),
                    1
                ),

                new BoundedSplit(
                    "testchmb_a_07",
                    "12 Angled Surface Platform",
                    new Vector3(-65, -1057, 1279),
                    new Vector3(449, -511, 1297),
                    1
                ),

                new BoundedSplit(
                    "testchmb_a_07",
                    "12 End Platform",
                    new Vector3(-65, -1409, 1599),
                    new Vector3(449, -1183, 1617),
                    1
                ),

                new BoundedSplit(
                    "testchmb_a_07",
                    "12 Ele Activated",
                    new Vector3(-553, -1409, 1615),
                    new Vector3(-495, 1279, 1702),
                    1
                ),				

				/* testchmb_a_08 */
                new BoundedSplit(
                    "testchmb_a_08",
                    "13 First Room",
                    new Vector3(-577, -257, 127),
                    new Vector3(-303, 257, 385),
                    1
                ),

                new BoundedSplit(
                    "testchmb_a_08",
                    "13 Higher Cube Platform",
                    new Vector3(47, 208, 240),
                    new Vector3(-303, 257, 385),
                    1
                ),

                new BoundedSplit(
                    "testchmb_a_08",
                    "13 Ending Hall",             // Alientreph
                    new Vector3(559, -129, 127),
                    new Vector3(841, 129, 257),
                    1
                ),

                new BoundedSplit(
                    "testchmb_a_08",
                    "13 Ele Activated",
                    new Vector3(559, -129, 127),
                    new Vector3(841, 129, 257),
                    1
                ),	
				
				/* testchmb_a_09 */
                new BoundedSplit(
                    "testchmb_a_09",
                    "14 Get under ele",
                    new Vector3(-64, 448, 92),
                    new Vector3(80, 592, 112),
                    1
                ),

                new BoundedSplit(
                    "testchmb_a_09",
                    "14 Exit Portal Under End Platform",
                    new Vector3(400, 384, -1),
                    new Vector3(620, 640, 64),
                    1
                ),

                new BoundedSplit(
                    "testchmb_a_09",
                    "14 End Platform",
                    new Vector3(207, 447, 127),
                    new Vector3(417, 577, 257),
                    1
                ),

                new BoundedSplit(
                    "testchmb_a_09",
                    "14 Ele Activated",
                    new Vector3(-41, 447, 135),
                    new Vector3(17, 577, 230),
                    1
                ),	
				
				/* testchmb_a_10 */
                new BoundedSplit(
                    "testchmb_a_10",
                    "15 Hallway",
                    new Vector3(-511, -2367, 12),
                    new Vector3(-385, -1696, -243),
                    1
                ),

                new BoundedSplit(
                    "testchmb_a_10",
                    "15 Goo",
                    new Vector3(-379, 126, -142),
                    new Vector3(124, 6, -621),
                    1
                ),

                new BoundedSplit(
                    "testchmb_a_10",
                    "15 Ending Hall",
                    new Vector3(-188, 1278, 127),
                    new Vector3(-108, 365, 300),
                    1
                ),	
				
				/* testchmb_a_11 */
				/* testchmb_a_13 */
                new BoundedSplit(
                    "testchmb_a_13",
                    "17 Cube Drop",
                    new Vector3(2640, 60, 256),
                    new Vector3(2296, 190, 0),
                    1
                ),

                new BoundedSplit(
                    "testchmb_a_13",
                    "17 Enter Hallway",
                    new Vector3(1696, 514, 120),
                    new Vector3(1571, 640, 376),
                    1
                ),

                new BoundedSplit(
                    "testchmb_a_13",
                    "17 Exit Hallway",
                    new Vector3(1456.03f, 384, 220),
                    new Vector3(1519.97f, 404, 320),
                    1
                ),

                new BoundedSplit(
                    "testchmb_a_13",
                    "17 Setup for Fling",
                    new Vector3(840.72f, 320.16f, 130.86f),
                    new Vector3(956.15f, 8.78f, 251.86f),
                    1
                ),

                new BoundedSplit(
                    "testchmb_a_13",
                    "17 Enter Angled Portal",
                    new Vector3(818, 130, 125),
                    new Vector3(633, -5, 2),
                    1
                ),

                new BoundedSplit(
                    "testchmb_a_13",
                    "17 Land from Fling",
                    new Vector3(1184, 960, -125),
                    new Vector3(1343, 836, 32),
                    1
                ),

                new BoundedSplit(
                    "testchmb_a_13",
                    "17 Enter Pedestal Button Room",
                    new Vector3(1630, -352, -60),
                    new Vector3(1513, -480, 53),
                    1
                ),

                new BoundedSplit(
                    "testchmb_a_13",
                    "17 Activate Ele",
                    new Vector3(2240, -273, -50),
                    new Vector3(2377, -116, 96),
                    1
                ),	
				
				/* testchmb_a_14 */
                new BoundedSplit(
                    "testchmb_a_14",
                    "18 Button Platform",
                    new Vector3(704, 576, 1155),
                    new Vector3(1008, 780, 1216),
                    1
                ),
                new BoundedSplit(
                    "testchmb_a_14",
                    "18 Beside Door",
                    new Vector3(64, 768, 1023),
                    new Vector3(256, 577, 1154),
                    1
                ),
                new BoundedSplit(
                    "testchmb_a_14",
                    "18 Ending Area",
                    new Vector3(-1087, 897, 896),
                    new Vector3(-691, 302, 1160),
                    1
                ),
                new BoundedSplit(
                    "testchmb_a_14",
                    "18 In Flings",
                    new Vector3(-1281, 576, 887),
                    new Vector3(-1409, 706, 988),
                    1
                ),

				/* testchmb_a_15 */
                new BoundedSplit(
                    "testchmb_a_15",
                    "19 Door Room",
                    new Vector3(-886, 1490, 511),
                    new Vector3(-1085, 1291, 761),
                    1
                ),

                new BoundedSplit(
                        "testchmb_a_15",
                        "19 First Lag",
                        new Vector3(256, 515, 381),
                        new Vector3(518, 910, 652),
                        1
                    ),

                new BoundedSplit(
                        "testchmb_a_15",
                        "19 Loch Ness",
                        new Vector3(-541, 572, 0),
                        new Vector3(-634, -162, 256),
                        1
                    ),

                new BoundedSplit(
                        "testchmb_a_15",
                        "19 Pipe Entry",
                        new Vector3(0, 905, 1027),
                        new Vector3(256, 1150,1390),
                        1
                    ),

                new BoundedSplit(
                        "testchmb_a_15",
                        "19 Pipe Exit",
                        new Vector3(1532, 581, 813),
                        new Vector3(1732, 320, 642),
                        1
                    ),

                new BoundedSplit(
                        "testchmb_a_15",
                        "19 EG Sequence",
                        new Vector3(1340, 453, 903),
                        new Vector3(1472, 320, 766),
                        1
                    ),

                new BoundedSplit(
                        "testchmb_a_15",
                        "19 Vent Shot Spot",
                        new Vector3(2411, 124, -20),
                        new Vector3(2834, 144, 256),
                        1
                    ),
			    /* escape_00 */
			    /* escape_01 */
			    /* escape_02 */
                new BoundedSplit(
                    "escape_02",
                    "e02 Vent Shot",
                    new Vector3(4858, 773, -382),
                    new Vector3(5057, 514, -897),
                    1
                ),

                new BoundedSplit(
                    "escape_02",
                    "e02 Activate Turrets",
                    new Vector3(4591.99f, 512, -396),
                    new Vector3(4430, 769, -127),
                    1
                ),

                new BoundedSplit(
                    "escape_02",
                    "e02 Activate Glados",
                    new Vector3(8240.01f, 1416, 411),
                    new Vector3(8455, 1024, 640),
                    1
                ),





            };
        }

    }
}


/*

Voices in my head do not stop

*/
