using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using flashcardApp.Models;
using System.Data.SqlClient;

namespace flashcardApp.DAO
{
    public class ModuleSqlDAO : IModuleDAO
    {
        private readonly string connectionString;

        public ModuleSqlDAO(string connString)
        {
            connectionString = connString;
        }

        public IList<Module> GetModules()
        {
            IList<Module> modules = new List<Module>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT module_id, module_name FROM module ORDER BY module_id;", conn);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Module module = new Module();
                    module.ModuleId = Convert.ToInt32(reader["module_id"]);
                    module.ModuleName = Convert.ToString(reader["module_name"]);

                    modules.Add(module);
                }
            }
            return modules;
        }
    }
}
