﻿using Abstraction.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class SQLCodeLanguageRepository
    {
        string connectionString = "Data Source=ucl-jtm-sqlserver.database.windows.net;Initial Catalog=2-sem-gr-1;Persist Security Info=True;User ID=2-sem-gr-1-login;Password=Gr21Pa$$word!";
        SqlConnection Connection { get; set; }

        public SQLCodeLanguageRepository()
        {
            Connection = new SqlConnection(connectionString);
        }

        public void AddCodeLanguage(ICodeLanguage codeLanguage)
        {
            string query = "INSERT INTO CodeLanguage (LanguageName) VALUES (@LanguageName)";
            using (Connection)
            {
                SqlCommand sqlCommand = new SqlCommand(query, Connection);
                sqlCommand.Parameters.AddWithValue("@LanguageName", codeLanguage.Language);

                Connection.Open();
                sqlCommand.ExecuteNonQuery();
                Connection.Close();
            }
        }

        public void DeleteCodeLanguage(ICodeLanguage language)
        {
            string query = "DELETE FROM CodeLanguage WHERE Id = @Id";
            using (Connection)
            {
                SqlCommand sqlCommand = new SqlCommand(query, Connection);
                sqlCommand.Parameters.AddWithValue("@Id", language.Id);
                Connection.Open();
                sqlCommand.ExecuteNonQuery();
                Connection.Close();
            }
        }

        public void EditCodeLanguage(ICodeLanguage dto)
        {
            string query = "UPDATE CodeLanguage SET LanguageName = @LanguageName WHERE Id = @Id";
            using (Connection)
            {
                SqlCommand sqlCommand = new SqlCommand(query, Connection);
                sqlCommand.Parameters.AddWithValue("@Id", dto.Id);
                sqlCommand.Parameters.AddWithValue("@LanguageName", dto.Language);
                Connection.Open();
                sqlCommand.ExecuteNonQuery();
                Connection.Close();
            }
        }

       /* public List<ICodeLanguage> GetAllCodeLanguages()
        {
            DataTable languagetable = new DataTable();

        }*/
    }
}
