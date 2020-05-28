using System;
using System.Data;
using Npgsql;

namespace com.DABM.x00023319.Models
{
    public class AppOrdera
    {
        private NpgsqlConnection cn;
        private NpgsqlCommand cmd;
        private string sql;
        private int idOrder;
        private DateTime fecha;
        private int idProduct;
        private int idAddress;
        private int iduser;
        
        public AppOrdera()
        {
            cn = Conection.connectDatabase();
        }

        public int IdOrder
        {
            get => idOrder;
            set => idOrder = value;
        }

        public int Iduser
        {
            get => iduser;
            set => iduser = value;
        }

        public DateTime Fecha
        {
            get => fecha;
            set => fecha = value;
        }

        public int IdProduct
        {
            get => idProduct;
            set => idProduct = value;
        }

        public int IdAddress
        {
            get => idAddress;
            set => idAddress = value;
        }
        public bool InsertAppOrdera()
        {
            cn.Open();
            sql = "INSERT INTO public.apporder(createdate, idproduct, idaddress) VALUES (@createdate, @idproduct,@idaddress );";
            cmd = new NpgsqlCommand(sql, cn);
            cmd.Parameters.AddWithValue("createdate", fecha);
            cmd.Parameters.AddWithValue("idproduct", idProduct);
            cmd.Parameters.AddWithValue("idaddress", idAddress);
            cmd.Prepare();
            var result = cmd.ExecuteNonQuery();
            cn.Close();
            return result == 1;
        }
        public bool deleteAppOrdera()
        {
            cn.Open();
            sql = "DELETE FROM apporder WHERE idorder=@idorder;";
            cmd = new NpgsqlCommand(sql, cn);
            cmd.Parameters.AddWithValue("idorder", idOrder);
            cmd.Prepare();
            var result = cmd.ExecuteNonQuery();
            cn.Close();
            return result == 1;
        }
        public DataTable selectAppOrdera()
        {
            cn.Open();
            sql = "SELECT idorder, createdate, pr.name, bu.name ,dr.address ,us.fullname FROM apporder ord INNER JOIN product pr ON pr.idproduct =ord.idproduct INNER JOIN business bu ON bu.idbusiness =pr.idbusiness INNER JOIN address dr ON dr.idaddress = ord.idaddress INNER JOIN appuser us ON us.iduser = dr.iduser WHERE us.iduser=@iduser;";
            cmd = new NpgsqlCommand(sql, cn);
            cmd.Parameters.AddWithValue("iduser", iduser);
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            cn.Close();
            return dt;
        }
        
        public DataTable ALLselectAppOrdera()
        {
            cn.Open();
            sql = "SELECT idorder, createdate, pr.name, bu.name ,dr.address ,us.fullname  FROM apporder ord INNER JOIN product pr ON pr.idproduct =ord.idproduct INNER JOIN business bu ON bu.idbusiness =pr.idbusiness INNER JOIN address dr ON dr.idaddress = ord.idaddress INNER JOIN appuser us ON us.iduser = dr.iduser ;";
            cmd = new NpgsqlCommand(sql, cn);
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            cn.Close();
            return dt;
        }
    }
}