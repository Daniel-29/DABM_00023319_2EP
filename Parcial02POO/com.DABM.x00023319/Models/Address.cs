using System.Data;
using Npgsql;

namespace com.DABM.x00023319.Models
{
    public class Address
    {
        
        private NpgsqlConnection cn;
        private NpgsqlCommand cmd;
        private string sql;

       private int idAddress;
       private int idUser;
       private string address;     

        public Address()
        {
            cn = Conection.connectDatabase();
        }

        public int IdAddress
        {
            get => idAddress;
            set => idAddress = value;
        }

        public int IdUser
        {
            get => idUser;
            set => idUser = value;
        }

        public string Address1
        {
            get => address;
            set => address = value;
        }
        public bool InsertAddress()
        {
            cn.Open();
            sql = "INSERT INTO ADDRESS(idUser, address) VALUES(@idUser,@address);";
            cmd = new NpgsqlCommand(sql, cn);
            cmd.Parameters.AddWithValue("idUser", idUser);
            cmd.Parameters.AddWithValue("address", address);
            cmd.Prepare();
            var result = cmd.ExecuteNonQuery();
            cn.Close();
            return result == 1;
        }
        public bool updateAddress()
        {
            cn.Open();
            sql = "UPDATE ADDRESS SET address = @address WHERE idAddress = @idAddress";
            cmd = new NpgsqlCommand(sql, cn);
            cmd.Parameters.AddWithValue("address", address);
            cmd.Parameters.AddWithValue("idAddress", idAddress);
            cmd.Prepare();
            var result = cmd.ExecuteNonQuery();
            cn.Close();
            return result == 1;
        }
        public bool deleteAddress()
        {
            cn.Open();
            sql = "DELETE FROM ADDRESS WHERE idAddress=@idAddress;";
            cmd = new NpgsqlCommand(sql, cn);
            cmd.Parameters.AddWithValue("idAddress", idAddress);
            cmd.Prepare();
            var result = cmd.ExecuteNonQuery();
            cn.Close();
            return result == 1;
        }
        public DataTable selectAddress()
        {
            cn.Open();
            sql = "SELECT idaddress, address	FROM address a INNER JOIN appuser u ON u.iduser = a.iduser WHERE a.iduser=@idUser;";
            cmd = new NpgsqlCommand(sql, cn);
            cmd.Parameters.AddWithValue("idUser", idUser);
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            cn.Close();
            return dt;
        }
    }
}