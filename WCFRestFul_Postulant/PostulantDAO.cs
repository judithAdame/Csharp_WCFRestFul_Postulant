using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;

namespace WCFRestFul_Postulant
{
    public class PostulantDAO
    {
        static PostulantDAO() {
            Postulant p1 = new Postulant
            {
                Nom = "Judith Adame",
                Courriel = "judith@gmail.com",
                Langages = "Java, JEE, Nodejs, js"
            };
            Postulant p2 = new Postulant
            {
                Nom = "Yuni",
                Courriel = "Yuni@gmail.com",
                Langages = "ajax, jquery, javascript, js"
            };
            Postulant p3 = new Postulant
            {
                Nom = "Mohamed",
                Courriel = "Mohamed@gmail.com",
                Langages = "Java, JEE, Nodejs, js, ajax, jquery, js"
            };
        }
        public static List<Postulant> GetAll()
        {
            List<Postulant> postulants = new List<Postulant>();
            SqlConnection sqlConnection = DataManager.Get();
            try
            {
                sqlConnection.Open();

                SqlCommand cmd = new SqlCommand
                {
                    CommandText = "GetAll",
                    CommandType = System.Data.CommandType.StoredProcedure,
                    Connection = sqlConnection
                };

                SqlDataReader reader = cmd.ExecuteReader();

                Postulant postulant;
                while (reader.Read())
                {
                    postulant = new Postulant()
                    {
                        Id = int.Parse(reader["ID"].ToString()),
                        Nom = reader["NOM"].ToString(),
                        Courriel = reader["COURRIEL"].ToString(),
                        Langages = reader["LANGAGES"].ToString()
                    };
                    postulants.Add(postulant);
                }
            }catch (SqlException ex)
            {
                sqlConnection.Close();
                MessagesErreur(ex);
               return null;
            }
            sqlConnection.Close();
            return postulants;
        }

        public static void Add(Postulant postulant)
        {
            SqlConnection sqlConnection = DataManager.Get();
            try
            {
                sqlConnection.Open();

                SqlCommand cmd = new SqlCommand
                {
                    CommandText = "Add",
                    CommandType = System.Data.CommandType.StoredProcedure,
                    Connection = sqlConnection
                };

                cmd.Parameters.Add(new SqlParameter("@id", postulant.Id));
                cmd.Parameters.Add(new SqlParameter("@nom", postulant.Nom));
                cmd.Parameters.Add(new SqlParameter("@Courriel", postulant.Courriel));
                cmd.Parameters.Add(new SqlParameter("@Langages", postulant.Langages));

                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                sqlConnection.Close();
                MessagesErreur(ex);
            }
            sqlConnection.Close();
        }

        public static int Count => GetAll().Count();

        public static void Delete(string id)
        {
            SqlConnection sqlConnection = DataManager.Get();
            try
            {
                sqlConnection.Open();
                SqlCommand cmd = new SqlCommand
                {
                    CommandText = "Delete",
                    CommandType = System.Data.CommandType.StoredProcedure,
                    Connection = sqlConnection
                };

                cmd.Parameters.Add(new SqlParameter("@id", id));

                cmd.ExecuteNonQuery();
            }catch (SqlException ex)
            {
                sqlConnection.Close();
                MessagesErreur(ex);
            }
            sqlConnection.Close();
        }

        public static void Update(string id, Postulant postulant) {
            SqlConnection sqlConnection = DataManager.Get();
            try
            {
                sqlConnection.Open();
                SqlCommand cmd = new SqlCommand
                {
                    CommandText = "Update",
                    CommandType = System.Data.CommandType.StoredProcedure,
                    Connection = sqlConnection
                };

                cmd.Parameters.Add(new SqlParameter("@id",       id));
                cmd.Parameters.Add(new SqlParameter("@nom",      postulant.Nom));
                cmd.Parameters.Add(new SqlParameter("@Courriel", postulant.Courriel));
                cmd.Parameters.Add(new SqlParameter("@Langages", postulant.Langages));

                cmd.ExecuteNonQuery();

            }catch (SqlException ex){
                sqlConnection.Close();
                MessagesErreur(ex);
            }
            sqlConnection.Close();
        }

        public static Postulant GetById(string id)
        {
            SqlConnection sqlConnection = DataManager.Get();
            Postulant postulant = null;
            try { 
                sqlConnection.Open();

                SqlCommand cmd = new SqlCommand{
                    CommandText = "GetById",
                    CommandType = System.Data.CommandType.StoredProcedure,                
                    Connection = sqlConnection
                };

                cmd.Parameters.Add(new SqlParameter("@id", id));
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read()) { 
                    postulant = new Postulant() {
                        Id = int.Parse(reader["ID"].ToString()),
                        Nom = reader["NOM"].ToString(),
                        Courriel = reader["COURRIEL"].ToString(),
                        Langages = reader["LANGAGES"].ToString()
                    };
                }
            }
            catch (SqlException ex)
            {
                sqlConnection.Close();
                MessagesErreur(ex);
                return null;
            }
            sqlConnection.Close();
            return postulant;
        }

        public static List<Postulant> GetByLangages(int nbMatch, string lPostes)
        {
            List<Postulant> postulants = new List<Postulant>();
            SqlConnection sqlConnection = DataManager.Get();
            try
            {
                sqlConnection.Open();

                SqlCommand cmd = new SqlCommand
                {
                    CommandText = "GetAll",
                    //CommandText = "GetByLangages",
                    CommandType = System.Data.CommandType.StoredProcedure,
                    Connection = sqlConnection
                };

                //cmd.Parameters.Add(new SqlParameter("@nbMatch", nbMatch));
                //cmd.Parameters.Add(new SqlParameter("@lPostes", lPostes));

                SqlDataReader reader = cmd.ExecuteReader();

                Postulant postulant;
                while (reader.Read())
                {
                    postulant = new Postulant()
                    {
                        Id = int.Parse(reader["ID"].ToString()),
                        Nom = reader["NOM"].ToString(),
                        Courriel = reader["COURRIEL"].ToString(),
                        Langages = reader["LANGAGES"].ToString()
                    };
                    if (postulant.IsMatch(nbMatch, lPostes))
                    {
                        postulants.Add(postulant);
                    }
                }
            }
            catch (SqlException ex)
            {
                sqlConnection.Close();
                MessagesErreur(ex);
                return null;
            }
            sqlConnection.Close();
            return postulants;
        }

        private static void MessagesErreur (SqlException ex)
        {
            Console.WriteLine("Il y a un eu une erreur, plus d'informations ci-dessous :");
            Console.WriteLine();
            StringBuilder errorMessages = new StringBuilder();
            for (int i = 0; i < ex.Errors.Count; i++)
            {
                errorMessages.Append("Index #" + i + "\n" +
                    "Message: " + ex.Errors[i].Message + "\n" +
                    "LigneNumber: " + ex.Errors[i].LineNumber + "\n" +
                    "Source: " + ex.Errors[i].Source + "\n" +
                    "Procedure: " + ex.Errors[i].Procedure + "\n" +
                    "Type: " + ex.Errors[i].GetType() + "\n");
            }
            Console.WriteLine(errorMessages.ToString());
        }
    }
}