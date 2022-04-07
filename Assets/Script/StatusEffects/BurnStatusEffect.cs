using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Script.StatusEffects
{
    public class BurnStatusEffect : StatusEffectBase
    {
        void Awake()
        {
            damage = (int)Damage.low;
            maxDurationEffect = 3;
            minDurationEffect = 3;
        }

        public override void ActionStatusEffect(Player player)
        {
            this.player = player;
            StartCoroutine(CoolDown(RandomDurationEffect()));
        }
    }
}
