using CyanDataTransactions.Classes;
using CyanFight.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CyanFight
{
    public partial class Fight : Form
    {
        public Fight(Pokemon playersPokemon, Pokemon enemyPokemon)
        {
            InitializeComponent();
            PlayersPokemon = playersPokemon;
            EnemyPokemon = enemyPokemon;
            Won = false;
        }
        public Fight()
        {
            InitializeComponent();
            Pokemon player = new Pokemon();
            player.PokemonName = "Çakır";
            player.PokemonBaseId = 1;
            player.Experience = 300;
            PlayersPokemon = player;

            Pokemon enemy = new Pokemon();
            enemy.PokemonBaseId = 0;
            enemy.Experience = 200;
            EnemyPokemon = enemy;
        }
        public Pokemon PlayersPokemon { get; set; }
        public Pokemon EnemyPokemon { get; set; }
        int TickNumber = 0;
        string writingText = "";
        private void Fight_Load(object sender, EventArgs e)
        {
            WriteString(PlayersPokemon.PokemonName + ", go!");
            SetPlayersData();
            SetEnemyData();
        }
        void SetPlayersData()
        {
            gbPlayerPokemon.Text = PlayersPokemon.PokemonName;
            lblPlayerLevel.Text = "Lvl " + PlayersPokemon.Level().ToString();
            lblPlayerMaxE.Text = PlayersPokemon.Energy.ToString();
            lblCurrentE.Text = lblPlayerMaxE.Text;
            pbPlayersPokemon.Image = PlayersPokemon.BackImage;
            pbPlayerHealth.Maximum = PlayersPokemon.Health;
            pbPlayerHealth.Value = PlayersPokemon.Health;
            foreach (Button btn in PlayersPokemon.Moves())
            {
                btn.Click += AttackMove;
                btn.Width = flpMoves.Width / 3;
                btn.Height = flpMoves.Height / 4;
                flpMoves.Controls.Add(btn);
            }
        }
        void AttackMove(object sender, EventArgs e)
        {
           
            PokemonMove mp = (PokemonMove)((Button)sender).Tag;
            int currentE = Convert.ToInt32(lblCurrentE.Text);
            if (mp.Cost < currentE)
            {
                Random rnd = new Random();
                int acc = rnd.Next(100);
                if (acc > mp.Accuracy)
                {
                    currentE -= mp.Cost;
                    lblCurrentE.Text = currentE.ToString();
                    flpMoves.Enabled = false;
                    int damage = CyanFight.Classes.Tools.CalculateAttackDamage(mp, PlayersPokemon, EnemyPokemon);
                    if (pbEnemyPokemonHealth.Value > damage)
                    {
                        WriteString(mp.Name + " inflicted " + damage.ToString() + " damage!");
                        pbEnemyPokemonHealth.Value -= damage;
                        EnemyAttack();
                    }
                    else
                    {
                        pbEnemyPokemonHealth.Value = 0;
                        WriteString(mp.Name + " inflicted " + damage.ToString() + " damage!");
                        WaitNWrite("Wild " + EnemyPokemon.PokemonBase().PokemonBaseName + " fainted!" );
                        flpMoves.Enabled = false;
                        Won = true;
                        MessageBox.Show("You have won!");
                        this.Close();
                    }
                }
                else
                {
                    WriteString(PlayersPokemon.PokemonName + "'s " + mp.Name + " missed!");
                    EnemyAttack();
                }
            }
            else
            {
                WriteString("You dont have the energy to do that...");
            }
        }
        bool IsWriting = false;
        void EnemyAttack()
        {
            Thread.Sleep(1000);
            List<PokemonMove> possibleMoves = new List<PokemonMove>();
            foreach (var item in EnemyPokemon.Moves())
            {
                PokemonMove pm = item.Tag as PokemonMove;
                if (pm.Cost <= Convert.ToInt32(lblEnemyCurrentE.Text))
                {
                    possibleMoves.Add(pm);
                }
            }
            Random rnd = new Random();
            int moveIndex = rnd.Next(possibleMoves.Count - 1);
            PokemonMove usedMove = possibleMoves[moveIndex];
            Random rnd2 = new Random();
            int acc = rnd2.Next(100);
            if (usedMove.Accuracy < acc)
            {
                int currentE = Convert.ToInt32(lblEnemyCurrentE.Text) - usedMove.Cost;
                lblEnemyCurrentE.Text = currentE.ToString();
                int damage = Classes.Tools.CalculateAttackDamage(usedMove, EnemyPokemon, PlayersPokemon);
                if (pbPlayerHealth.Value > damage)
                {
                    pbPlayerHealth.Value -= damage;
                    WaitNWrite(PlayersPokemon.PokemonName + " took " + damage.ToString() + " damage!");
                }
                else
                {
                    pbPlayerHealth.Value = 0;
                    WaitNWrite(PlayersPokemon.PokemonName + " has fainted! You have lost!");
                    MessageBox.Show("You have lost!");
                    this.Close();
                }
            }
            else
            {
                WaitNWrite("Wild "+ EnemyPokemon.PokemonBase().PokemonBaseName + " missed!");
            }
            
        }
        void SetEnemyData()
        {
            gbEnemyPokemon.Text = EnemyPokemon.PokemonBase().PokemonBaseName;
            lblEnemyPokemonLevel.Text = "Lvl " + EnemyPokemon.Level().ToString();
            pbEnemyPokemon.Image = EnemyPokemon.FrontImage;
            pbEnemyPokemonHealth.Maximum = EnemyPokemon.Health;
            pbEnemyPokemonHealth.Value = EnemyPokemon.Health;
            lblEnemyCurrentE.Text = EnemyPokemon.Energy.ToString();
            EnemyMaxE.Text = EnemyPokemon.Energy.ToString();
        }        
        void WriteString(string toWrite)
        {
            
                TickNumber = 0;
                writingText = toWrite;
                tmrWriter.Enabled = true;
                IsWriting = true;                
                       
        }      
        private void tmrWriter_Tick(object sender, EventArgs e)
        {
            if (TickNumber == 100)
            {
                TickNumber = 0;
                Thread.Sleep(1000);
                flpMoves.Enabled = true;
                IsWriting = false;
                tmrWriter.Enabled = false;
                
            }
            else if (TickNumber == 0)
            {
                flpMoves.Enabled = false;
                try
                {
                    lblText.Text = writingText.Remove(1, writingText.Length - 1);
                    writingText = writingText.Remove(0, 1);
                    TickNumber++;
                }
                catch
                {
                    flpMoves.Enabled = true;
                    IsWriting = false;
                    tmrWriter.Enabled = false;                  
                }
            }
            else
            {
                flpMoves.Enabled = false;
                try
                {
                    lblText.Text += writingText.Remove(1, writingText.Length - 1);
                    writingText = writingText.Remove(0, 1);
                    TickNumber++;
                }
                catch
                {
                    IsWriting = false;
                    flpMoves.Enabled = true;
                    tmrWriter.Enabled = false;
                }
            }
        }
        string writing;
        private void tmrWaiter_Tick(object sender, EventArgs e)
        {
            if (!IsWriting)
            {
                WriteString(writing);
                tmrWaiter.Enabled = false;
            }
        }
        void WaitNWrite(string writ)
        {
            writing = writ;
            tmrWaiter.Enabled = true;
        }
        public bool Won;

        private void gbFightScreen_Enter(object sender, EventArgs e)
        {

        } 
    }
}
