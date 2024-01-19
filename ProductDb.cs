using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace CrudOperation_MVC.Models
{
    public class ProductDb
    {
        string conp = ConfigurationManager.ConnectionStrings["constr"].ToString();

        public List<Product>GetAllProducts()
        {
            List<Product> p = new List<Product>();
            using (SqlConnection con = new SqlConnection(conp))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_GetallProducts";
                SqlDataAdapter sqlDa = new SqlDataAdapter(cmd);
                DataTable dtProducts = new DataTable();
                con.Open();
                sqlDa.Fill(dtProducts);
                con.Close();

                foreach(DataRow dr in dtProducts.Rows)
                {
                    p.Add(new Product
                    {
                        ProductID=Convert.ToInt32(dr["ProductID"]),
                        ProductName = (dr["ProductName"]).ToString(),
                        Price = Convert.ToDecimal(dr["Price"]),
                        City= (dr["City"]).ToString(),
                        Remark= (dr["Remark"]).ToString()




                    });
                }

            }
            return p;
        }



        public bool insertProduct(Product pr)
        {
            int id = 0;
            using(SqlConnection con = new SqlConnection(conp))
            {
                SqlCommand cmd = new SqlCommand("insertP ", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ProductName",pr.ProductName);
                cmd.Parameters.AddWithValue("@Price", pr.Price);
                cmd.Parameters.AddWithValue("@city", pr.City);
                cmd.Parameters.AddWithValue("@Remark", pr.Remark);
                con.Open();
                id = cmd.ExecuteNonQuery();
                con.Close();

            }
            if (id > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Product> GetProductbyID(int ProductID)
        {
            List<Product> p = new List<Product>();
            using (SqlConnection con = new SqlConnection(conp))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetProductsbyId";
                SqlDataAdapter sqlDa = new SqlDataAdapter(cmd);
                DataTable dtProducts = new DataTable();
                con.Open();
                sqlDa.Fill(dtProducts);
                con.Close();

                foreach (DataRow dr in dtProducts.Rows)
                {
                    p.Add(new Product
                    {
                        ProductID = Convert.ToInt32(dr["ProductID"]),
                        ProductName = (dr["ProductName"]).ToString(),
                        Price = Convert.ToDecimal(dr["Price"]),
                        City = (dr["City"]).ToString(),
                        Remark = (dr["Remark"]).ToString()




                    });
                }

            }
            return p;
        }

        public bool UpdateProduct(Product pr)
        {
            int id = 0;
            using (SqlConnection con = new SqlConnection(conp))
            {
                SqlCommand cmd = new SqlCommand("UpdateP ", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ProductID", pr.ProductID);

                cmd.Parameters.AddWithValue("@ProductName", pr.ProductName);
                cmd.Parameters.AddWithValue("@Price", pr.Price);
                cmd.Parameters.AddWithValue("@city", pr.City);
                cmd.Parameters.AddWithValue("@Remark", pr.Remark);
                con.Open();
                id = cmd.ExecuteNonQuery();
                con.Close();

            }
            if (id > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}