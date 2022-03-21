using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using flashcardApp.Models;
using System.Data.SqlClient;

namespace flashcardApp.DAO
{
    public class CardSqlDAO : ICardDAO
    {
        private readonly string connectionString;

        public CardSqlDAO(string connString)
        {
            connectionString = connString;
        }
        public IList<Card> GetCardsByUnit(int unitId)
        {
            IList<Card> cards = new List<Card>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT card_id, term, definition, code_example, interview_qs, unit_id " +
                                                "FROM card WHERE unit_id = @unit_id;", conn);
                cmd.Parameters.AddWithValue("@unit_id", unitId);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Card card = new Card();
                    card.CardId = Convert.ToInt32(reader["card_id"]);
                    card.Term = Convert.ToString(reader["term"]);
                    card.Definition = Convert.ToString(reader["definition"]);
                    card.CodeExample = Convert.ToString(reader["code_example"]);
                    card.InterviewQs = Convert.ToString(reader["interview_qs"]);
                    card.UnitId = Convert.ToInt32(reader["unit_id"]);

                    cards.Add(card);
                }
            }
            return cards;
        }

        public Card GetCard(int cardId)
        {
            Card card = new Card();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT card_id, term, definition, code_example, interview_qs, unit_id " +
                                                "FROM card WHERE card_id = @card_id;", conn);
                cmd.Parameters.AddWithValue("@card_id", cardId);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    card.CardId = Convert.ToInt32(reader["card_id"]);
                    card.Term = Convert.ToString(reader["term"]);
                    card.Definition = Convert.ToString(reader["definition"]);
                    card.CodeExample = Convert.ToString(reader["code_example"]);
                    card.InterviewQs = Convert.ToString(reader["interview_qs"]);
                    card.UnitId = Convert.ToInt32(reader["unit_id"]);
                }         
            }
            return card;
        }

    }
}
