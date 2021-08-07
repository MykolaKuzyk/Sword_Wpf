using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Text;

//* To find the number of hit points (HP)
//  of damage for a sword attack, roll 3d6 (three 6 - sided dice)
//  and add "Base Damage" of 3HP
//* Some swords are flaming, which causes an extra 2HP of damage
//* Some swords are magic. For Magic swords, the 3D6 roll is multiplied by 1.75 
//  and rounded down, and the base damage and flaming damage are added to the result 
namespace Sword_Wpf
{
    class SwordDamage : WeaponDamage
    {
        public const int BASE_DAMAGE = 3;
        public const int FLAME_DAMAGE = 2;

        public SwordDamage(int startingRoll): base(startingRoll) { }
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
        /// <summary>
        /// The constructor calculates damage based on default SetMagic
        /// and Flaming values and a starting 3d6 roll
        /// </summary>
        /// <param name="startingRoll"></param>

    }
}
