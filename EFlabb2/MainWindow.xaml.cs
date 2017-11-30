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
            GetPlayerData();
            GetLevelData();
            GetRoundData();
        }
        public void GetPlayerData()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                var query = "SELECT * FROM Player";
                using (SqlCommand cmd = new SqlCommand(query, con))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Player p = new Player();
                        p.Id = reader.GetInt32(0);
                        p.Name = reader.GetString(1);

                        PlayerNamesListBox.Items.Add(p);
                    }
                }
            }
        }

        public void GetLevelData()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                var query = "SELECT * FROM Level";
                using (SqlCommand cmd = new SqlCommand(query, con))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Level l = new Level();
                        l.LevelId = reader.GetInt32(0);
                        l.AvailableMoves = reader.GetInt32(1);

                        LevelListBox.Items.Add(l);
                    }
                }
            }
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
                        Round r = new Round();
                        r.RoundId = reader.GetInt32(0);
                        r.LevelId = reader.GetInt32(1);
                        r.PlayerId = reader.GetInt32(2);
                        r.Score = reader.GetInt32(3);

                        RoundListBox.Items.Add(r);
                    }
                }
            }
        }
    }
}
