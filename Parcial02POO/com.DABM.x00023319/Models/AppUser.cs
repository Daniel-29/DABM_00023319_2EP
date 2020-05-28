using System;
using System.Data;
using System.Windows.Forms;
using  com.DABM.x00023319.Models;
using Npgsql;

namespace com.DABM.x00023319
{
    public class AppUser
    {
        private NpgsqlConnection cn;
        private NpgsqlCommand cmd;
      //  private NpgsqlDataReader dr;
        private string sql;
        
        private int idUser;
        private string Fullname;
        private string username;
        private string password;
        private bool userType;

        public AppUser()
        {
            cn = Conection.connectDatabase();
        }
        public int IdUser
        {
            get => idUser;
            set => idUser = value;
        }

        public string Fullname1
        {
            get => Fullname;
            set => Fullname = value;
        }

        public string Username
        {
            get => username;
            set => username = value;
        }

        public string Password
        {
            get => password;
            set => password = value;
        }

        public bool UserType
        {
            get => userType;
            set => userType = value;
        }
        public bool InsertUser()
        {
            cn.Open();
            sql = "INSERT INTO APPUSER(fullname, username, password, userType) VALUES (@Fullname,@username,@password, @userType);";
            cmd = new NpgsqlCommand(sql, cn);
            cmd.Parameters.AddWithValue("Fullname", Fullname);
            cmd.Parameters.AddWithValue("username", username);
            cmd.Parameters.AddWithValue("password", password);
            cmd.Parameters.AddWithValue("userType", userType);
            cmd.Prepare();
            var result = cmd.ExecuteNonQuery();
            cn.Close();
            return result == 1;
        }
        public bool updateUser()
        {
            cn.Open();
            sql = "UPDATE APPUSER SET password = @password WHERE idUser = @idUser";
            cmd = new NpgsqlCommand(sql, cn);
            cmd.Parameters.AddWithValue("password", password);
            cmd.Parameters.AddWithValue("idUser", idUser);
            cmd.Prepare();
            var result = cmd.ExecuteNonQuery();
            cn.Close();
            return result == 1;
        }
        public bool Verificarusername()
        {
            cn.Open();
            sql = "SELECT idUser FROM APPUSER  WHERE username = @username;";
            cmd = new NpgsqlCommand(sql, cn);
            cmd.Parameters.AddWithValue("username",username );
            DataTable  dt  = new DataTable();
            dt.Load(cmd.ExecuteReader());
            cn.Close();
            return (dt.Rows.Count!=0) ? true : false;
        }
        public bool deleteUser()
        {
            cn.Open();
            sql = "DELETE FROM APPUSER WHERE idUser = @idUser";
            cmd = new NpgsqlCommand(sql, cn);
            cmd.Parameters.AddWithValue("idUser", idUser);
            cmd.Prepare();
            var result = cmd.ExecuteNonQuery();
            cn.Close();
            return result == 1;
        }
        public DataTable selectUser()
        {
            cn.Open();
            sql = "SELECT idUser,username,fullname, userType FROM APPUSER;";
            cmd = new NpgsqlCommand(sql, cn);
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            cn.Close();
            return dt;
        }
        public DataTable login()
        {
            DataTable dt;
            cn.Open();
            sql = "SELECT idUser,fullname, userType FROM APPUSER u WHERE  u.username=@username  and u.password=@password";
            cmd = new NpgsqlCommand(sql, cn);
            cmd.Parameters.AddWithValue("username",username );
            cmd.Parameters.AddWithValue("password", password);
            dt  = new DataTable();
            dt.Load(cmd.ExecuteReader());
            cn.Close();
            if (dt.Rows.Count<=0)
            {
                dt = null;
            }
            return dt;
          
        }
    }
}