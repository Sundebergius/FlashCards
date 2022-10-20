using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using flashcards.Models;
using Microsoft.Data.SqlClient;

namespace flashcards
{
    public class StudyController
    {
        public static readonly string connectionString = 
            "Server=(localdb)\\MSSQLLocalDB; Initial Catalog=quizDb; Integrated Security=true;";
        internal static void NewStudySession()
        {
            var studySession = StudyEngine.CreateStudySession();

            SqlConnection conn = new SqlConnection(connectionString);

            using (conn)
                {
                    conn.Open();
                    var tableCmd = conn.CreateCommand();
                    tableCmd.CommandText = 
                        $@"INSERT INTO studySession (StackName, NumberOfQuestions, Score)
                            VALUES ('{studySession.StackName}', '{studySession.NumberOfQuestions}', {studySession.Score})";
                    tableCmd.ExecuteNonQuery();
                    conn.Close();
                }

            UserCommands.StudyMenu();
        }

        internal static void GetStudySessions()
        {
            List<StudySession> sessions = new List<StudySession>();

            SqlConnection conn = new(connectionString);

            using (conn)
            {
                conn.Open();
                var tablecmd = conn.CreateCommand();
                tablecmd.CommandText =
                    $@"SELECT * FROM studysession";
                tablecmd.ExecuteNonQuery();

                SqlDataReader reader = tablecmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        sessions.Add(
                            new StudySession
                            {
                                Id = reader.GetInt32(0),
                                NumberOfQuestions = reader.GetInt32(1),
                                Score = (int)(reader.GetDouble(2)),
                                StackName = reader.GetString(3),
                            });
                    }
                }
                else
                {
                    Console.WriteLine("\n\nNo rows found.\n\n");
                }
            }

            TableVisualisationEngine.ShowTable(sessions, "Study Sessions");

            UserCommands.StudyMenu();
        }
    
    }
}