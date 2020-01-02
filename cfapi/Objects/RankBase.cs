using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace cfapi.Objects
{
    public class RankBase
    {
        public int From;
        public int To;
        public Color Color;

        public RankBase(int from, int to, Color color)
        {
            From = from;
            To = to;
            Color = color;
        }
    }
}
