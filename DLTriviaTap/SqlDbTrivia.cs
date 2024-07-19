using MODELSTriviaTap;
using System.Data.SqlClient;

namespace DLTriviaTap
{
    public class SqlDbTrivia
    {

        string connectionString
        = "Data Source =DESKTOP-HVA24H8\\SQLEXPRESS; Initial Catalog = TriviaTapSYSTEM; Integrated Security = True;";

        SqlConnection sqlConnection;


        public SqlDbTrivia()
        {
            sqlConnection = new SqlConnection(connectionString);
        }

        public List<Trivia> GetTrivia()
        {
            string selectStatement = "SELECT questions, answers FROM trivia";

            SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection);

            sqlConnection.Open();
            List<Trivia> trivia = new List<Trivia>();  //'trivia' is the db table name

            SqlDataReader reader = selectCommand.ExecuteReader();

            while (reader.Read())
            {
                string questions = reader["questions"].ToString();
                string answers = reader["answers"].ToString();

                Trivia readUser = new Trivia();
                readUser.questions = questions;
                readUser.answers = answers;


                trivia.Add(readUser);
            }

            sqlConnection.Close();

            return trivia;
        }
    }
}