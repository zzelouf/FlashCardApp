using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using flashcardApp.Models;
using System.Data.SqlClient;

namespace flashcardApp.DAO
{
    public class UnitSqlDAO : IUnitDAO
    {
        private readonly string connectionString;

        public UnitSqlDAO(string connString)
        {
            connectionString = connString;
        }

        public IList<Unit> GetUnits()
        {
            IList<Unit> units = new List<Unit>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT unit_id, unit_name, module_id FROM unit", conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Unit unit = new Unit();
                    unit.UnitId = Convert.ToInt32(reader["unit_id"]);
                    unit.UnitName = Convert.ToString(reader["unit_name"]);
                    unit.ModuleId = Convert.ToInt32(reader["module_id"]);

                    units.Add(unit);
                }
            }

            return units;
        }

        public IList<Unit> GetUnitsPerModule(int moduleId)
        {
            IList<Unit> units = new List<Unit>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT unit_id, unit_name, module_id FROM unit WHERE module_id = @module_id", conn);
                cmd.Parameters.AddWithValue("@module_id", moduleId);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Unit unit = new Unit();
                    unit.UnitId = Convert.ToInt32(reader["unit_id"]);
                    unit.UnitName = Convert.ToString(reader["unit_name"]);
                    unit.ModuleId = Convert.ToInt32(reader["module_id"]);

                    units.Add(unit);
                }
            }

            return units;
        }
    }
}
