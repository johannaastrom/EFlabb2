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
            Player player = GetPlayerDataByName("Evert");
            GetLevelDataById(2); //by available moves??
            GetRoundDataByScore(2); // by score??
        }

        public void Add(GameContext context) //ändra till passande namn på add
        {
            Player p = new Player();
            p.Name = "Johanna";
            //p.Rounds = new Round();

            Round r = new Round();
            r.RoundId = 2;
            r.Score = 3;
            //r.PlayerId = ??
            //r.LevelId = ??
            //r.Player = p;

            //p.Rounds.Add(r);
            context.Players.Add(p);
            context.SaveChanges();
        }

        public Player GetPlayerDataByName(string playerName)
        {
            using (GameContext context = new GameContext(connectionString))
            {
                return (from x in context.Players
                        where x.Name == playerName
                        select x).SingleOrDefault();
            }
        }

        public Round GetRoundDataByPlayerIdLevelId(int playerId, int levelId)
        {
            using (GameContext context = new GameContext(connectionString))
            {
                return (from x in context.Rounds.Include("Player").Include("Level")
                        where x.PlayerId == playerId && x.LevelId == levelId //kolla detta villkor. by x.roundid?? döp om roundid till score?
                        select x).SingleOrDefault();
            }
        }

        public Level GetLevelDataById(int playerid)
        {
            using (GameContext context = new GameContext(connectionString))
            {
                return (from x in context.Levels
                        where x.LevelId == playerid //kolla detta villkor. by x.availablemoves?? döp om playerid?
                        select x).SingleOrDefault();
            }
        }

        public Round GetRoundDataByScore(int roundid)
        {
            using (GameContext context = new GameContext(connectionString))
            {
                return (from x in context.Rounds.Include("Player").Include("Level")
                        where x.RoundId == roundid //kolla detta villkor. by x.roundid?? döp om roundid till score?
                        select x).SingleOrDefault();
            }
        }

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
                            if (round.Score > int.Parse(MovesTextBox.Text))
                            {
                                int level = int.Parse(LevelTextBox.Text);
                                var r = context.Rounds.Where(rr => rr.PlayerId == round.PlayerId && rr.LevelId == level).SingleOrDefault();
                                r.Score = int.Parse(MovesTextBox.Text);
                                context.SaveChanges();
                            }
                        }
                    }
                    else
                    {
                        Player newPlayer = new Player();
                        newPlayer.Name = NameTextBox.Text;
                        context.Players.Add(newPlayer);
                        context.SaveChanges();
                        Round newRound = new Round();
                        newRound.Score = int.Parse(MovesTextBox.Text);
                        newRound.LevelId = int.Parse(LevelTextBox.Text);
                        newRound.PlayerId = newPlayer.Id;
                        context.Rounds.Add(newRound);
                        context.SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Nu blev det lite tokigt.");
                }
            }
        }

        private void UpdateButton1_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}

