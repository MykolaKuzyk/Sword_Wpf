using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sword_Wpf
{
    class WeaponDamage
    {
        public WeaponDamage(int startingRoll)
        {
            roll = startingRoll;
            CalculateDamage();
        }

        /// <summary>
        /// Contains the calculated damage.
        /// </summary>
        public int Damage { get; protected  set; }

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
        protected virtual void CalculateDamage()
        {
            //Subclass overrides this logic 
        }

    }
}
