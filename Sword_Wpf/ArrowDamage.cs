using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Sword_Wpf
{
    class ArrowDamage
    {
        /// <summary>
        ///  The base damage for an arrow is the ID6 roll Multiplied by 35h 
        ///  For a magic arrow is mutiplied b 2.5HP
        ///  For Flame by 1.25HP 
        /// </summary>
        public const decimal BASE_MULTIPLIER = 0.35M;
        public const decimal MAGIC_MULTIPLIER = 2.5M;
        public const decimal FLAME_DAMAGE = 1.25M;

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
            set
            {
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
            get { return setMagic; }
            set
            {
                setMagic = value;
                CalculateDamage();
                Debug.WriteLine($"SetMagic finished:{Damage} (roll: {Roll}) is true?: {setMagic}");
            }
        }

        /// <summary>
        /// Calculates the damage based on the current properties.
        /// </summary>
        public void CalculateDamage()
        {
            decimal baseDamage = Roll * BASE_MULTIPLIER;
            if (SetMagic) baseDamage *= MAGIC_MULTIPLIER;
            if (Flaming) Damage = (int)Math.Ceiling(baseDamage + FLAME_DAMAGE);
            else Damage = (int)Math.Ceiling(baseDamage);
        }
        /// <summary>
        /// The constructor calculates damage based on default SetMagic
        /// and Flaming values and a starting 3d6 roll
        /// </summary>
        /// <param name="startingRoll"></param>
        public ArrowDamage(int startingRoll)
        {
            roll = startingRoll;
            CalculateDamage();
        }
    }
}
