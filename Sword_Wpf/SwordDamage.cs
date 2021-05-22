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
        public int Roll;
        public decimal MagicMultiplier = 1M;
        public int FlamingDamage = 0;
        public int Damage;


        
        public void CalculateDamage()
        {
            Damage = (int)(Roll * MagicMultiplier) + BASE_DAMAGE + FlamingDamage;
            Console.WriteLine("Rolled {0} for {1} HP  \n\n\n", Roll , Damage );

            Debug.WriteLine($"CalculateDamage finished:  {Damage}(roll: {Roll})");
        }

// Set Sword as Magic sword 1 = yes , 3 = yes, 1 - no, 
        public void SetMagic(bool isMagic)
        {
            if (isMagic)
            {
                MagicMultiplier = 1.75M;
            }
            else
            {
                MagicMultiplier = 1M;
            }
           
            Debug.WriteLine($"SetMagic finished:{Damage} (roll: {Roll})");
        }


        public void SetFlamin(bool isFlaming)
        {
            
            if (isFlaming)
            {
                Damage += FLAME_DAMAGE;
            }
            Debug.WriteLine($"SetFlamin finished:{Damage} (roll: {Roll}) is true?: {isFlaming}");
        }
    }
}
