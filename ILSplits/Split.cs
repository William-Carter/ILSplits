using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace ILSplits
{
    /// <summary>
    /// Represents a split in a map with a defined bounding box and activation count.
    /// </summary>
    public class Split
    {
        /// <summary>
        /// Gets or sets the map name.
        /// </summary>
        public string Map { get; set; }

        /// <summary>
        /// Gets or sets the split name.
        /// </summary>
        public string Name { get; set; }

        private int activationCount;
        private int counter;
        private bool activated = false;

        /// <summary>
        /// Gets a value indicating whether the split is activated.
        /// </summary>
        public bool Activated { get { return activated; } }

        /// <summary>
        /// Initializes a new instance of the <see cref="Split"/> class.
        /// </summary>
        /// <param name="Map">The map filename.</param>
        /// <param name="Name">The split name.</param>
        /// <param name="a">The first corner of the bounding box.</param>
        /// <param name="b">The second corner of the bounding box.</param>
        /// <param name="activationCount">The number of activations required to activate the split.</param>
        public Split(string Map, string Name, int activationCount)
        {
            this.Map = Map;
            this.Name = Name;
            this.activationCount = activationCount;
            counter = 0;
        }

        

        /// <summary>
        /// Increments the activation counter. Activates the split if the counter reaches the activation count.
        /// </summary>
        public void increment()
        {
            if (activated) // no need to keep incrementing
            {
                return;
            }

            counter++;
            if (counter == activationCount)
            {
                activated = true;
            }
        }
    }

    public class BoundedSplit: Split
    {
        private Vector3 a;
        private Vector3 b;
        public BoundedSplit(string Map, string Name, Vector3 a, Vector3 b, int activationCount) : base(Map, Name, activationCount)
        {
            this.a = a;
            this.b = b;
        }

        /// <summary>
        /// Checks if a point is within the bounding box defined by the split.
        /// </summary>
        /// <param name="point">The point to check.</param>
        /// <returns>True if the point is within the bounding box; otherwise, false.</returns>
        public bool CheckPointBounded(Vector3 point)
        {
            Vector3 boxMin = Vector3.Min(a, b);
            Vector3 boxMax = Vector3.Max(a, b);

            return point.X >= boxMin.X && point.X <= boxMax.X &&
                   point.Y >= boxMin.Y && point.Y <= boxMax.Y &&
                   point.Z >= boxMin.Z && point.Z <= boxMax.Z;
        }
    }

    public class SoundSplit : Split
    {
        private string soundName;
        private int offset;
        public SoundSplit(string Map, string Name, string soundName, int activationCount, int offset) : base(Map, Name, activationCount)
        {
            this.soundName = soundName;
            this.offset = offset;
        }
        /// <summary>
        /// Checks if a sound is the sound that activates the split.
        /// </summary>
        /// <param name="soundName">The sound to check.</param>
        /// <returns>True if the sound is the sound that activates the split; otherwise, false.</returns>
        public bool CheckSound(string soundName)
        {
            return soundName == this.soundName;
        }
    }
}
