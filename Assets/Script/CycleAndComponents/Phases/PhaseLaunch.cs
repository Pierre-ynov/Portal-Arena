using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Script.CycleAndComponents.Phases
{
    public class PhaseLaunch: Phase
    {
        public override void action()
        {
            GenerateCoolDown(time);
        }
    }
}
