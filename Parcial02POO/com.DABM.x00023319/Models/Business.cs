using System.Data;
using System.Windows.Forms;
using Npgsql;

namespace com.DABM.x00023319.Models
{
    public class Business
    {
        private NpgsqlConnection cn;
        private NpgsqlCommand cmd;
        private string sql;

        private int idBusiness;
        private string name;
        private string description;
        
        public Business()
        {
            cn = Conection.connectDatabase();
        }

        public int IdBusiness
        {
            get => idBusiness;
            set => idBusiness = value;
        }

        public string Name
        {
            get => name;
            set => name = value;
        }

        public string Description
        {
            get => description;
            set => description = value;
        }
        public bool InsertBusiness()
        {
            cn.Open();
            sql = "INSERT INTO BUSINESS  (name, description) VALUES (@name, @description);";
            cmd = new NpgsqlCommand(sql, cn);
            cmd.Parameters.AddWithValue("name", name);
            cmd.Parameters.AddWithValue("description", description);
            cmd.Prepare();
            var result = cmd.ExecuteNonQuery();
            cn.Close();
            return result == 1;
        }
        public bool updateBusiness()
        {
            cn.Open();
            sql = "UPDATE BUSINESS  SET name=@name, description=@description WHERE idBusiness = @idBusiness";
            cmd = new NpgsqlCommand(sql, cn);
            cmd.Parameters.AddWithValue("name", name);
            cmd.Parameters.AddWithValue("description", description);
            cmd.Parameters.AddWithValue("idBusiness", idBusiness);
            cmd.Prepare();
            var result = cmd.ExecuteNonQuery();
            cn.Close();
            return result == 1;
        }
        public bool deleteBusiness()
        {
            cn.Open();
            sql = "DELETE FROM BUSINESS WHERE idBusiness=@idBusiness;";
            cmd = new NpgsqlCommand(sql, cn);
            cmd.Parameters.AddWithValue("idBusiness", idBusiness);
            cmd.Prepare();
            var result = cmd.ExecuteNonQuery();
            cn.Close();
            return result == 1;
        }
        public DataTable selectBusiness()
        {
            cn.Open();
            sql = "SELECT b.idBusiness, b.name , b.description  FROM BUSINESS b;";
            cmd = new NpgsqlCommand(sql, cn);
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            cn.Close();
            return dt;
        }
    }
}