using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
        private List<Character> enemies;

        public Form1()
        {
            InitializeComponent();
            InitializeEnemies();
        }

        private void InitializeEnemies()
        {

            // Create attacks for the player
            List<Attack> playerAttacks = new List<Attack>
            {
                new Attack("Giga Drain", 1000, "Grass", "Drain"),
                new Attack("Attack Down", 0, "Normal", "Attack Down"),
                new Attack("Attack Up", 0, "Normal", "Attack Up"),
                new Attack("Defense Up", 0, "Normal", "Defense Up")
            };

            // Create attacks for the enemies
            List<Attack> goblinAttacks = new List<Attack>
            {
                new Attack("Slash", 150, "Normal"),
                new Attack("Defense Down", 0, "Normal", "Defense Down"),
                new Attack("Quick Attack", 120, "Normal"),
                new Attack("Taunt", 0, "Normal")
            };

            List<Attack> orcAttacks = new List<Attack>
            {
                new Attack("Smash", 200, "Normal"),
                new Attack("Attack Down", 0, "Normal", "Attack Down"),
                new Attack("Roar", 0, "Normal", "Defense Down"),
                new Attack("Club Swing", 180, "Normal")
            };

            List<Attack> dragonAttacks = new List<Attack>
            {
                new Attack("Fire Breath", 300, "Fire"),
                new Attack("Wing Attack", 200, "Normal"),
                new Attack("Tail Whip", 150, "Normal"),
                new Attack("Inferno", 400, "Fire")
            };

            // Create enemy characters
            Character bluemon = new Character("Bluemon", "Water", 1000, 25, 15, goblinAttacks, "Images/bluemon.png");
            Character redmon = new Character("Redmon", "Fire", 1500, 30, 20, orcAttacks, "Images/redmon.png");
            Character yellowmon = new Character("Yellowmon", "Normal", 2000, 40, 25, dragonAttacks, "Images/yellowmon.png");

            // Add enemies to a list
            enemies = new List<Character> { bluemon, redmon, yellowmon };

            // Pick a random enemy
            Random random = new Random();
            opponent = enemies[random.Next(enemies.Count)];

            // Initialize the player
            player = new Character("Player", "Normal", 2000, 20, 20, playerAttacks, "Images/memon.png");

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
            // Update player HP
            lblPlayerHp.Text = $"Player HP: {player.HP}";

            // Update opponent's name and HP
            lblOpponentHp.Text = $"{opponent.Name} HP: {opponent.HP}";

            string path = Path.Combine(Application.StartupPath, opponent.ImagePath);
            pictureBox1.Image = Image.FromFile(path);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

            string path2 = Path.Combine(Application.StartupPath, player.ImagePath);
            pictureBox2.Image = Image.FromFile(path2);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;

            // Only update the message if it's not already updated by ExecuteAttack
            if (!battle.IsBattleOver() && string.IsNullOrEmpty(txtMessage.Text))
            {
                txtMessage.Text = "Choose an action!";
            }

            // If the battle is over, show a victory/defeat message
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

                ShowBattleResultForm();
            }
        }

        private void ShowBattleResultForm()
        {
            // Create an instance of the BattleResultForm
            var battleResultForm = new BattleResultForm();

            // Set the start position to center relative to Form1
            battleResultForm.StartPosition = FormStartPosition.CenterParent;

            // Show the BattleResultForm as a modal dialog
            battleResultForm.ShowDialog(this);

            // If Yes was clicked in BattleResultForm, restart the game
            if (battleResultForm.IsYesClicked)
            {
                InitializeEnemies(); // Reset the game state
            }
            else
            {
                Application.Exit(); // Exit the application if No was clicked
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
                    target.AttackBuffCounter--; // Reduce the target's attack buff counter
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
