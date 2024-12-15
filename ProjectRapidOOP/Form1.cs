using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectRapidOOP
{
    public partial class Form1 : Form
    {
        private Character player;
        private Character opponent;
        private Battle battle;

        public Form1()
        {
            InitializeComponent();
            StartGame();
        }

        private void StartGame()
        {
            // Create attacks for the player
            List<Attack> playerAttacks = new List<Attack>
            {
                new Attack("Giga Drain", 1000, "Grass", "Drain"),
                new Attack("Attack Down", 0, "Normal", "Attack Down"),
                new Attack("Attack Up", 0, "Normal", "Attack Up"),
                new Attack("Defense Up", 0, "Normal", "Defense Up")
            };

            // Create attacks for the opponent
            List<Attack> opponentAttacks = new List<Attack>
            {
                new Attack("Defense UP", 0, "Normal", "Defense UP"),
                new Attack("Attack Up", 0, "Normal", "Attack Up"),
                new Attack("Attack Down", 0, "Normal", "Attack Down"),
                new Attack("Defense Down", 0, "Normal", "Defense Down")
            };

            // Initialize player and opponent
            player = new Character("Player", "Normal", 2000, 20, 20, playerAttacks);
            opponent = new Character("Opponent", "Fire", 2000, 20, 20, opponentAttacks);
            
            // Update the button texts to match the player's moves
            btnAttack1.Text = playerAttacks[0].Name;
            btnAttack2.Text = playerAttacks[1].Name;
            btnAttack3.Text = playerAttacks[2].Name;
            btnAttack4.Text = playerAttacks[3].Name;

            // Start the battle
            battle = new Battle(player, opponent);

            // Update UI to reflect initial state
            UpdateUI();
        }


        private void UpdateUI()
        {
            lblPlayerHp.Text = $"Player HP: {player.HP}";
            lblOpponentHp.Text = $"Opponent HP: {opponent.HP}";

            // Only update the message if it's not already updated by ExecuteAttack
            if (!battle.IsBattleOver() && string.IsNullOrEmpty(txtMessage.Text))
            {
                txtMessage.Text = "Choose an action!";
            }

            if (battle.IsBattleOver())
            {
                if (player.HP == 0)
                {
                    txtMessage.Text += $"{player.Name} is knocked down! {opponent.Name} Wins";
                }
                if (opponent.HP == 0)
                {
                    txtMessage.Text += $"{opponent.Name} is knocked down! {player.Name} Wins";
                }

            }
        }

        private void btnAttack1_Click(object sender, EventArgs e)
        {
            ExecuteAttack(player.Attacks[0]);
        }

        private void btnAttack2_Click(object sender, EventArgs e)
        {
            ExecuteAttack(player.Attacks[1]);
        }

        private void btnAttack3_Click(object sender, EventArgs e)
        {
            ExecuteAttack(player.Attacks[2]);
        }

        private void btnAttack4_Click(object sender, EventArgs e)
        {
            ExecuteAttack(player.Attacks[3]);
        }

        private void ExecuteAttack(Attack attack)
        {
            if (battle.IsBattleOver()) return;

            // Player's turn
            string message = $"{player.Name} used {attack.Name}!{Environment.NewLine}";
            int damage = player.PerformAttack(attack, opponent, player);

            if (damage > 0)
                message += $"{attack.Name} dealt {damage} damage to {opponent.Name}.{Environment.NewLine}";

            // Apply player's skill effects
            ApplySkillEffects(attack, player, opponent, ref message);

            if (!battle.IsBattleOver())
            {
                // Opponent's turn
                Attack opponentAttack = opponent.Attacks[new Random().Next(opponent.Attacks.Count)];
                message += $"{opponent.Name} used {opponentAttack.Name}!{Environment.NewLine}";
                int opponentDamage = opponent.PerformAttack(opponentAttack, player, opponent);

                if (opponentDamage > 0)
                    message += $"{opponentAttack.Name} dealt {opponentDamage} damage to {player.Name}.{Environment.NewLine}";

                // Apply opponent's skill effects
                ApplySkillEffects(opponentAttack, opponent, player, ref message);
            }

            txtMessage.Text = message;
            UpdateUI();
        }

        private void ApplySkillEffects(Attack attack, Character attacker, Character target, ref string message)
        {
            if (attack.Effect == "Drain")
            {
                int healingAmount = (int)(attacker.AttackPower * 0.2); // Heal for 20% of attack power
                if (healingAmount < 1) healingAmount = 1;
                attacker.HP += healingAmount;

                if (attacker.HP > attacker.MaxHP)
                {
                    attacker.HP = attacker.MaxHP; // Prevent overhealing
                    healingAmount = 0;
                }

                message += $"{attacker.Name} healed for {healingAmount} HP.{Environment.NewLine}";
            }

            if (attack.Effect == "Defense Down")
            {
                if (target.DefenseBuffCounter <= -2) // Max debuff
                {
                    message += $"{target.Name}'s defense cannot be reduced further!{Environment.NewLine}";
                }
                else
                {
                    target.DefenseBuffCounter--;
                    message += $"{target.Name}'s defense decreased!{Environment.NewLine}";
                }
            }

            if (attack.Effect == "Defense Up")
            {
                if (attacker.DefenseBuffCounter >= 2) // Max buff
                {
                    message += $"{attacker.Name}'s defense cannot be increased further!{Environment.NewLine}";
                }
                else
                {
                    attacker.DefenseBuffCounter++;
                    message += $"{attacker.Name}'s defense increased!{Environment.NewLine}";
                }
            }

            if (attack.Effect == "Attack Down")
            {
                if (target.AttackBuffCounter <= -2) // Max debuff
                {
                    message += $"{target.Name}'s attack cannot be reduced further!{Environment.NewLine}";
                }
                else
                {
                    target.AttackBuffCounter--;
                    message += $"{target.Name}'s attack decreased!{Environment.NewLine}";
                }
            }

            if (attack.Effect == "Attack Up")
            {
                if (attacker.AttackBuffCounter >= 2) // Max buff
                {
                    message += $"{attacker.Name}'s attack cannot be increased further!{Environment.NewLine}";
                }
                else
                {
                    attacker.AttackBuffCounter++;
                    message += $"{attacker.Name}'s attack increased!{Environment.NewLine}";
                }
            }
        }
    }
}
