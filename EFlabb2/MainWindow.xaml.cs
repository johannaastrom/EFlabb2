using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.Entity;

namespace EFlabb2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public const string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=AngryBirdsGame;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public MainWindow()
        {
            InitializeComponent();
            PrintListBoxInfo();
        }

        //Method that prints all players, levels and rounds in the listboxes.
        public void PrintListBoxInfo()
        {
            using (GameContext context = new GameContext(connectionString))
            {
                List<Player> playerList = context.Players.ToList();
                foreach (var p in playerList)
                {
                    PlayerNamesListBox.Items.Add(p);
                }

                List<Level> levelList = context.Levels.ToList();
                foreach (var l in levelList)
                {
                    LevelListBox.Items.Add(l);
                }

                List<Round> roundList = context.Rounds.ToList();
                foreach (var r in roundList)
                {
                    RoundListBox.Items.Add(r);
                }
            }
        }

        //Query to get players name.
        public Player GetPlayerDataByName(string playerName)
        {
            using (GameContext context = new GameContext(connectionString))
            {
                return (from x in context.Players
                        where x.Name == playerName
                        select x).SingleOrDefault();
            }
        }

        //Query to get Id's.
        public Round GetRoundDataByPlayerIdLevelId(int playerId, int levelId)
        {
            using (GameContext context = new GameContext(connectionString))
            {
                return (from x in context.Rounds.Include("Player").Include("Level")
                        where x.PlayerId == playerId && x.LevelId == levelId
                        select x).SingleOrDefault();
            }
        }

        //Updating or creates new objects if it doesnt already exist in the data base.
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (GameContext context = new GameContext(connectionString))
            {
                try
                {
                    Player player = GetPlayerDataByName(NameTextBox.Text);

                    if (player != null)
                    {
                        Round round = GetRoundDataByPlayerIdLevelId(player.Id, int.Parse(LevelTextBox.Text));

                        if (round != null)
                        {
                            if (round.UsedMoves > int.Parse(MovesTextBox.Text))
                            {
                                int level = int.Parse(LevelTextBox.Text);
                                var r = context.Rounds.Where(rr => rr.PlayerId == round.PlayerId && rr.LevelId == level).SingleOrDefault();
                                r.UsedMoves = int.Parse(MovesTextBox.Text);
                                context.SaveChanges();

                                PlayerNamesListBox.Items.Clear();
                                LevelListBox.Items.Clear();
                                RoundListBox.Items.Clear();
                                PrintListBoxInfo();
                            }
                        }
                        else
                        {
                            Round newRound = new Round();
                            newRound.UsedMoves = int.Parse(MovesTextBox.Text);
                            newRound.LevelId = int.Parse(LevelTextBox.Text);
                            newRound.PlayerId = player.Id;
                            context.Rounds.Add(newRound);
                            context.SaveChanges();
                        }
                    }
                    else
                    {
                        Player newPlayer = new Player();
                        newPlayer.Name = NameTextBox.Text;
                        context.Players.Add(newPlayer);
                        context.SaveChanges();

                        Round newRound = new Round();
                        newRound.UsedMoves = int.Parse(MovesTextBox.Text);
                        newRound.LevelId = int.Parse(LevelTextBox.Text);
                        newRound.PlayerId = newPlayer.Id;
                        context.Rounds.Add(newRound);
                        context.SaveChanges();

                        PlayerNamesListBox.Items.Clear();
                        LevelListBox.Items.Clear();
                        RoundListBox.Items.Clear();
                        PrintListBoxInfo();
                    }
                    NameTextBox.Text = string.Empty;
                    LevelTextBox.Text = string.Empty;
                    MovesTextBox.Text = string.Empty;
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Nu blev det lite tokigt. Du har försökt spela en level som inte finns.");
                }
            }
        }

        //Prints the selected players levels and used moves.
        private void PlayerNamesListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PrintPlayerScoreListBox.Items.Clear();

            using (GameContext context = new GameContext(connectionString))
            {
                var query = from round in context.Rounds.ToList()
                            join l in context.Levels on round.LevelId equals l.LevelId
                            where round.PlayerId == PlayerNamesListBox.SelectedIndex + 1
                            select new { Level = round.LevelId, UsedMoves = round.UsedMoves, MovesLeft = l.AvailableMoves - round.UsedMoves };
                foreach (var x in query)
                {
                    PrintPlayerScoreListBox.Items.Add(x);
                }
            }
        }

        //Button to add level with available moves.
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            using (GameContext context = new GameContext(connectionString))
            {
                Level newLevel = new Level();
                newLevel.AvailableMoves = int.Parse(AddNewLevelTextBox.Text);
                context.Levels.Add(newLevel);
                context.SaveChanges();

                PlayerNamesListBox.Items.Clear();
                LevelListBox.Items.Clear();
                RoundListBox.Items.Clear();
                PrintListBoxInfo();
            }
            AddNewLevelTextBox.Text = string.Empty;
        }

        private void PrintPlayerLevelListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }
        private void UpdateButton1_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}

