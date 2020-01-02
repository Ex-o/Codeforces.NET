using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
namespace cfapi.Objects
{
    public class Newbie : RankBase
    {
        public Newbie() : base(0, 1400, Color.FromRgb(204, 204, 204)) { }
    }
    public class Pupil : RankBase
    {
        public Pupil() : base(1200, 1400, Color.FromRgb(119, 225, 119)) { }
    }
    public class Specialst : RankBase
    {
        public Specialst() : base(1400, 1600, Color.FromRgb(119, 221, 187)) { }

    }
    public class Expert : RankBase
    {
        public Expert() : base(1600, 1900, Color.FromRgb(170, 170, 225)) { }
    }
    public class CandidateMaster : RankBase
    {
        public CandidateMaster() : base(1900, 2100, Color.FromRgb(225, 136, 225)) { }

    }
    public class Master : RankBase
    {
        public Master() : base(2100, 2300, Color.FromRgb(225, 204, 136)) { }
    }
    public class InternationalMaster : RankBase
    {
        public InternationalMaster() : base(2300, 2400, Color.FromRgb(225, 187, 85)) { }
    }
    public class Grandmaster : RankBase
    {
        public Grandmaster() : base(2400, 2600, Color.FromRgb(225, 119, 119)) { }
    }
    public class InternationalGrandmaster : RankBase
    {
        public InternationalGrandmaster() : base(2600, 3000, Color.FromRgb(225, 51, 51)) { }
    }
    public class LegendaryGrandmaster : RankBase
    {
        public LegendaryGrandmaster() : base(3000, int.MaxValue, Color.FromRgb(170, 0, 0)) { }
    }
}
