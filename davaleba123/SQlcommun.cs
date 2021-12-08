using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;


namespace davaleba123
{
    public static class SQlcommun
    {   
        static public SqlConnection con;
        static public SqlCommand comand;
        static public SqlDataAdapter ad;
        static public DataTable Dat;
        static string connectionString = ConfigurationManager.ConnectionStrings["connectionstr"].ConnectionString;
       
        public static void Delete(int id)
        {
            comand = new SqlCommand("Delete",con);

            SqlParameter[] par = new SqlParameter[0];
            par[0] = new SqlParameter("@id", SqlDbType.Int);
            par[0].Value = id;
            comand.Parameters.AddRange(par);
            con.Open();
            comand.ExecuteNonQuery();
            con.Close();
           

        }
        public static void addStudent(string fullname, string subject , string passcode)
        {
            con = new SqlConnection(connectionString);
            comand = new SqlCommand("addStudents", con);
            comand.CommandType = CommandType.StoredProcedure;
            SqlParameter[] par = new SqlParameter[3];
            par[0] = new SqlParameter("@fullname", SqlDbType.VarChar);
            par[1] = new SqlParameter("@Subject", SqlDbType.VarChar);
            par[2] = new SqlParameter("@password", SqlDbType.VarChar);

            par[0].Value = fullname;
            par[1].Value = subject;
            par[2].Value = passcode;
            comand.Parameters.AddRange(par);
            con.Open();
            comand.ExecuteNonQuery();
            con.Close();
            
      
        }

        public static void addTeaecher(string fullname, string subject, string passcode)
        {
            con = new SqlConnection(connectionString);
            comand = new SqlCommand("addTeachers", con);
            comand.CommandType = CommandType.StoredProcedure;
            SqlParameter[] par = new SqlParameter[3];
            par[0] = new SqlParameter("@fullname", SqlDbType.VarChar);
            par[1] = new SqlParameter("@Subject", SqlDbType.VarChar);
            par[2] = new SqlParameter("@password", SqlDbType.VarChar);

            par[0].Value = fullname;
            par[1].Value = subject;
            par[2].Value = passcode;
            comand.Parameters.AddRange(par);
            con.Open();
            comand.ExecuteNonQuery();
            con.Close();


        }
        public static void getTeaecher(string fullname, string subject)
        {
          
            con = new SqlConnection(connectionString);
            comand = new SqlCommand("get_Teacher", con);
            comand.CommandType = CommandType.StoredProcedure;
            DataTable dT = new DataTable();
            SqlDataAdapter ada;
            ada = new SqlDataAdapter(comand);
            ada.Fill(dT);
            

        }
        public static void getStudent(string fullname, string subject)
        {
            con = new SqlConnection(connectionString);
            comand = new SqlCommand("get_student", con);
            comand.CommandType = CommandType.StoredProcedure;
            DataTable dT = new DataTable();
            SqlDataAdapter ada;
            ada = new SqlDataAdapter(comand);
            ada.Fill(dT);

        }
        public static void getGrade(string fullname, string subject)
        {
            con = new SqlConnection(connectionString);
            comand = new SqlCommand("GetGrade", con);
            comand.CommandType = CommandType.StoredProcedure;
            DataTable dT = new DataTable();
            SqlDataAdapter ada;
            ada = new SqlDataAdapter(comand);
            ada.Fill(dT);

        }
        public static void GetTeachers(string fullname, string subject)
        {
            con = new SqlConnection(connectionString);
            comand = new SqlCommand("GetTeachers", con);
            comand.CommandType = CommandType.StoredProcedure;
            DataTable dT = new DataTable();
            SqlDataAdapter ada;
            ada = new SqlDataAdapter(comand);
            ada.Fill(dT);

        }
        public static void SentTOMe(string fullname, string subject)
        {
            con = new SqlConnection(connectionString);
            comand = new SqlCommand("SentTOMe", con);
            comand.CommandType = CommandType.StoredProcedure;
            DataTable dT = new DataTable();
            SqlDataAdapter ada;
            ada = new SqlDataAdapter(comand);
            ada.Fill(dT);

        }
          public static void Shetana(string fullname, string subject)
        {
            con = new SqlConnection(connectionString);
            comand = new SqlCommand("Setana", con);
            comand.CommandType = CommandType.StoredProcedure;
            SqlParameter[] par = new SqlParameter[7];
        
            par[0] = new SqlParameter("@messege,", SqlDbType.VarChar);
            par[1] = new SqlParameter("@messege_", SqlDbType.VarChar);
            par[2] = new SqlParameter("@id", SqlDbType.VarChar);
            par[3] = new SqlParameter(" @Sender", SqlDbType.VarChar);
            par[4] = new SqlParameter(" @topic", SqlDbType.VarChar);
            par[5] = new SqlParameter("@type_", SqlDbType.VarChar);
            par[6] = new SqlParameter("@text_", SqlDbType.VarChar);




        }
        public static void UPdate(string param )
        {

        }

    }
}
