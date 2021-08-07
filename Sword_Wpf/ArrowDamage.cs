using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Sword_Wpf
{
    class ArrowDamage : WeaponDamage
    {
        public const int BASE_DAMAGE = 3;
        public const decimal MAGIC_MULTIPLIER = 2.5M; 
        public const int FLAME_DAMAGE = 2;

        public ArrowDamage(int startingRoll) : base(startingRoll) { }
        /// <summary>
        /// Calculates the damage based on the current properties.
        /// </summary>
        protected override void CalculateDamage()
        {

            decimal MagicMultiplier = 1M;
            if (SetMagic) MagicMultiplier = 1.75M;
            Damage = BASE_DAMAGE;
            Damage = (int)(Roll * MagicMultiplier) + BASE_DAMAGE;
            if (Flaming) Damage += FLAME_DAMAGE;
            Debug.WriteLine($"CalculateDamage finished:  {Damage}(roll: {Roll})");
        }
    }
}
