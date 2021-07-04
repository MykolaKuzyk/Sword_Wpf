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
    class SwordDamage
    {
        public const int BASE_DAMAGE = 3;
        public const int FLAME_DAMAGE = 2;

        /// <summary>
        /// Contains the calculated damage.
        /// </summary>
        public int Damage { get; private set; }

        /// <summary>
        /// Sets or gets the 3d6 roll
        /// </summary>
        private int roll;
        public int Roll 
        {
            get { return roll; }
            set { roll = Roll; CalculateDamage(); }
        }

        /// <summary>
        /// True if the sword is flaming, false otherwise.
        /// </summary>
        private bool flaming;
        public bool Flaming 
        {
            get { return flaming; }
            set {
                flaming = value;
                CalculateDamage();
                Debug.WriteLine($"SetFlamin finished:{Damage} (roll: {Roll}) is true?: {flaming}"); 
                }
        }


        /// <summary>
        /// Set Sword as Magic sword 1 = yes , 3 = yes, 1 - no
        /// </summary>
        private bool setMagic;
        public bool SetMagic 
        { 
           get{return setMagic; }
           set{setMagic = value;
               CalculateDamage();
               Debug.WriteLine($"SetMagic finished:{Damage} (roll: {Roll}) is true?: {setMagic}");
            }
        }

        /// <summary>
        /// Calculates the damage based on the current properties.
        /// </summary>
        public void CalculateDamage()
        {
            decimal MagicMultiplier = 1M;
            if (setMagic) MagicMultiplier = 1.75M;
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
        public SwordDamage (int startingRoll)
        {
            roll = startingRoll;
            CalculateDamage();
        }



    }
}
