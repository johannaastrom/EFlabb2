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
        public const string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=AngryBirds;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public MainWindow()
        {
            InitializeComponent();
            Player player = GetPlayerDataByName("Evert");
            GetLevelData();
            GetRoundData();
        }
        public Player GetPlayerDataByName(string playerName)
        {
            using (GameContext context = new GameContext(connectionString))
            {
                return (from x in context.Players.Include("Level").Include("Round")
                        where x.Name == playerName
                        select x).SingleOrDefault();
            }


            //return query.SingleOrDefault();

            //using (SqlConnection con = new SqlConnection(connectionString))
            //{
            //    con.Open();
            //    var query = "SELECT * FROM Player";
            //    using (SqlCommand cmd = new SqlCommand(query, con))
            //    using (SqlDataReader reader = cmd.ExecuteReader())
            //    {
            //        while (reader.Read())
            //        {
            //            Player p = new Player();
            //            p.Id = reader.GetInt32(0);
            //            p.Name = reader.GetString(1);

            //            PlayerNamesListBox.Items.Add(p);
            //        }
            //    }
            //}
        }

        public void GetLevelData()
        {

            //using (SqlConnection con = new SqlConnection(connectionString))
            //{
            //    con.Open();
            //    var query = "SELECT * FROM Level";
            //    using (SqlCommand cmd = new SqlCommand(query, con))
            //    using (SqlDataReader reader = cmd.ExecuteReader())
            //    {
            //        while (reader.Read())
            //        {
            //            Level l = new Level();
            //            l.LevelId = reader.GetInt32(0);
            //            l.AvailableMoves = reader.GetInt32(1);

            //            LevelListBox.Items.Add(l);
            //        }
            //    }
            //}
        }

        public void GetRoundData()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                var query = "SELECT * FROM Round";
                using (SqlCommand cmd = new SqlCommand(query, con))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        //Round r = new Round();
                        //r.RoundId = reader.GetInt32(0);
                        //r.LevelId = reader.GetInt32(1);
                        //r.PlayerId = reader.GetInt32(2);
                        //r.Score = reader.GetInt32(3);

                        //RoundListBox.Items.Add(r);
                    }
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    //if name does not exist in data base = add new name to data base. if name exist - update score if its lower than the existing one.
                    connection.Open();

                    string query = "INSERT INTO Player (Name) VALUES (@Name)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("Name", NameTextBox.Text);
                    command.ExecuteNonQuery();
                    MessageBox.Show("A new Player Name has been created!");  // ta bort innann redovisning

                    PlayerNamesListBox.Items.Clear();
                    //GetPlayerDataByName();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        private void UpdateButton1_Click(object sender, RoutedEventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "UPDATE Round SET " + " Score = '" + MovesTextBox.Text + "' ";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Score has been updated!");

                    GetRoundData();

                    for (int i = 0; i < RoundListBox.Items.Count; i++)
                    {
                        RoundListBox.Items.RemoveAt(0);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

    }
}

