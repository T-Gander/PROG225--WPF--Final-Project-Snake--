using PROG225__Final_Project_Snake__.Pages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PROG225__Final_Project_Snake__
{
    public class DatabaseManager
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["groupServer"].ConnectionString;

        public static void CheckForDatabase()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                }
            }
            catch
            {
                BuildDatabase();
                MessageBox.Show("Created a new database name SnakeGame on localhost,1434");
            }
        }

        public static void BuildDatabase()
        {
            string createDatabaseSQL = @"
                    CREATE database SnakeGame
                ";

            string buildSQL = @"

                    USE SnakeGame
                    CREATE TABLE [dbo].[Highscores](
	                [Score_ID] [int] NOT NULL,
	                [Name] [varchar](6) NOT NULL,
	                [Score] [int] NOT NULL
                    )
                ";
            string fillSQL = @"

                    USE SnakeGame
                    DECLARE @count INT = 1;

                    WHILE @count < 9
                    BEGIN
                       INSERT INTO [dbo].[Highscores]
                       VALUES (@count, 'AAA', 0)
                       SET @count = @count + 1;
                    END;";

            try
            {
                string masterConnectionString = "server=localhost,1434;database=master;user id=sa;password=P@ssword!;encrypt=false";

                using (SqlConnection conn = new SqlConnection(masterConnectionString))
                {
                    conn.Open();
                    SqlCommand databasecmd = new SqlCommand(createDatabaseSQL, conn);
                    SqlCommand buildcmd = new SqlCommand(buildSQL, conn);
                    SqlCommand fillcmd = new SqlCommand(fillSQL, conn);

                    databasecmd.ExecuteNonQuery();
                    buildcmd.ExecuteNonQuery();
                    fillcmd.ExecuteNonQuery();
                }
            }
            catch
            {
                MessageBox.Show("Something went wrong building the database. Make sure that you have a localhost,1434 SQL Server running. And check the connectionString credentials within App.config.");
            }
            
        }

        public static List<Highscore> GetHighScores()
        {
            List<Highscore> highscores = new List<Highscore>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("select * from [highscores]", conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Highscore highscore = new Highscore();

                        highscore.ScoreID = reader.GetInt32(0);
                        highscore.Name = reader.GetString(1);
                        highscore.Score = reader.GetInt32(2);

                        highscores.Add(highscore);
                    }
                }
            }
            catch { }

            highscores = highscores.OrderByDescending(highscore => highscore.Score).ToList(); //Orders highscores by score.

            return highscores;
        }

        public static void UpdateHighscores()
        {
            GameController.Highscores = GetHighScores();

            Highscore newHighscore = new Highscore();

            for(int i = GameController.Highscores.Count -1; i > -1; i--)
            {
                if (GameController.Highscores[i].Score < GameController.Score)
                {
                    newHighscore.ScoreID = GameController.Highscores[i].ScoreID;
                    newHighscore.Name = GameOverScreen.PlayerName.ToString();
                    newHighscore.Score = GameController.Score;
                    break;
                }
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("update [highscores] set Name = @Name, Score = @Score where Score_ID = @Score_ID", conn);
                    cmd.Parameters.AddWithValue("@Name", newHighscore.Name);
                    cmd.Parameters.AddWithValue("@Score", newHighscore.Score);
                    cmd.Parameters.AddWithValue("@Score_ID", newHighscore.ScoreID);
                    
                    cmd.ExecuteNonQuery();
                }
            }
            catch { }
        }

        
    }
}
