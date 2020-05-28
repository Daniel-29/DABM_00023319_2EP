using System.Data;
using Npgsql;

namespace com.DABM.x00023319.Models
{
    public class Product
    {
        private NpgsqlConnection cn;
        private NpgsqlCommand cmd;
        private string sql;

        private int idProduct;
        private int idBusiness;
        private string name;

        public Product()
        {
            cn = Conection.connectDatabase();
        }

        public int IdProduct
        {
            get => idProduct;
            set => idProduct = value;
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
        
        public bool InsertProduct()
        {
            cn.Open();
            sql = "INSERT INTO PRODUCT(idBusiness, name) VALUES(@idBusiness, @name);";
            cmd = new NpgsqlCommand(sql, cn);
            cmd.Parameters.AddWithValue("idBusiness", idBusiness);
            cmd.Parameters.AddWithValue("name", name);
            cmd.Prepare();
            var result = cmd.ExecuteNonQuery();
            cn.Close();
            return result == 1;
        }
        public bool deleteProduct()
        {
            cn.Open();
            sql = "DELETE FROM PRODUCT WHERE idProduct=@idProduct;";
            cmd = new NpgsqlCommand(sql, cn);
            cmd.Parameters.AddWithValue("idProduct", idProduct);
            cmd.Prepare();
            var result = cmd.ExecuteNonQuery();
            cn.Close();
            return result == 1;
        }
        public DataTable selectProduct()
        {
            cn.Open();
            sql = "SELECT p.idproduct, p.name, b.name, b.description FROM product p INNER JOIN business b on b.idbusiness = p.idbusiness;";
            cmd = new NpgsqlCommand(sql, cn);
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            cn.Close();
            return dt;
        }
    }
}