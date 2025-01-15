using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILSplits
{
    public class ActivatedSplit
    {
        public string Name { get; set; }
        public int TickActivated { get; set; }

        public float TimeActivated
        {
            get
            {
                return float.Round(TickActivated * 0.015f, 3);
            }
        }

        public ActivatedSplit(string Name, int TickActivated)
        {
            this.Name = Name;
            this.TickActivated = TickActivated + 1;
        }
    }
}
