using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectRapidOOP
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainPage());
        }
    }

    public class Character
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public int HP { get; set; }
        public int MaxHP { get; set; }
        public int AttackPower { get; set; }
        public int OriginalAttackPower { get; set; }
        public int Defense { get; set; }
        public int OriginalDefense { get; set; }
        public List<Attack> Attacks { get; set; }
        public string ImagePath { get; set; } // New property for the image path

        public int DefenseBuffCounter { get; set; } // Track number of times defense has been reduced
        public int AttackBuffCounter { get; set; } // Track number of times defense has been reduced

        public Character(string name, string type, int hp, int attackPower, int defense, List<Attack> attacks, string imagePath)
        {
            Name = name;
            Type = type;
            MaxHP = hp;
            HP = hp;
            AttackPower = attackPower;
            Defense = defense;
            Attacks = attacks;
            DefenseBuffCounter = 0;
            AttackBuffCounter = 0;
            ImagePath = imagePath;

        }

        public int PerformAttack(Attack attack, Character target, Character attacker)
        {

            // Calculate effective defense percentage, capped at 80%
            double defensePercentage = Math.Min(target.Defense / 100.0, 0.8);

            // Apply defense buff or debuff logic based on the DefenseBuffCounter
            if (target.DefenseBuffCounter != 0)
            {
                // If DefenseBuffCounter is positive, increase defense
                // If negative, decrease defense
                double buffMultiplier = 1 + (target.DefenseBuffCounter * 0.25); // 25% change per buff level
                defensePercentage *= buffMultiplier;
            }

            int effectiveAttackPower = (int)(attacker.AttackPower * (attack.Damage / 100.0));

            // Apply attack buff or debuff logic based on the AttackBuffCounter
            if (attacker.AttackBuffCounter != 0)
            {
                effectiveAttackPower = (int)(effectiveAttackPower * (1 + 0.25 * attacker.AttackBuffCounter)); // Increase/Decrease damage by 25% per buff level
            }

            // Calculate the damage after applying defense reduction
            int damage = (int)(effectiveAttackPower * (1 - defensePercentage));

            // Subtract damage from the target's HP
            target.HP -= damage;

            // Ensure HP doesn't drop below 0
            if (target.HP < 0) target.HP = 0;

            return damage; // Return the actual damage dealt
        }
    }

    public class Attack
    {
        public string Name { get; set; }
        public int Damage { get; set; }
        public string Type { get; set; } // Normal, Fire, Water, Grass
        public string Effect { get; set; } // "Drain", "Defense Down", "Defense Up", "Attack Down", "Attack Up"

        public Attack(string name, int damage, string type, string effect = null)
        {
            Name = name;
            Damage = damage;
            Type = type;
            Effect = effect;
        }
    }

    public class Battle
    {
        private Character player;
        private Character opponent;

        public Battle(Character player, Character opponent)
        {
            this.player = player;
            this.opponent = opponent;
        }

        public bool IsBattleOver()
        {
            return player.HP <= 0 || opponent.HP <= 0;
        }
    }

}
