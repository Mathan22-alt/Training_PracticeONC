using DataAccessLibrary;
using Microsoft.Data.SqlClient;
using System.ComponentModel;

namespace DataAccessLibrary
{
    public class CategoriesOperations
    {
        static string connectionString = "server=mazenet-test;" +
            "Integrated Security=true;" +
            "database=northwind;TrustServerCertificate=true";


        public List<Products> GetProductsByCategory(int id)
        {
            SqlConnection cn = new SqlConnection(connectionString);
            SqlCommand cmd_search = new SqlCommand("select productid,productname,unitprice,Supplierid from products where categoryid=@catid", cn);
            cn.Open();
            cmd_search.Parameters.AddWithValue("@catid", id);
            SqlDataReader dr = cmd_search.ExecuteReader();

            List<Products> productsList = new List<Products>();
            if (dr != null)
            {
                while (dr.Read())
                {
                    Products product = new Products();
                    product.Prodid = Convert.ToInt32(dr["ProductID"]);
                    product.Prodname = dr["ProductName"].ToString();
                    product.Price = Convert.ToDouble(dr["UnitPrice"]);
                    product.Suppid = Convert.ToInt32(dr["SupplierID"]);
                    productsList.Add(product);

                }

            }
            cn.Close();
            cn.Dispose();
            return productsList;


        }



        public List<Category> ShowAll()
        {
            List<Category> categories = new List<Category>();
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(connectionString);
                cmd = new SqlCommand("select categoryid,categoryname,description from categories", cn);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader(); //for select command method is executereader
                                                        //Sql DAta Reader is readonly, forward only stream of data
                if (dr != null)
                {
                    while (dr.Read())
                    {
                        Category category = new Category();
                        category.CatID = Convert.ToInt32(dr["CategoryID"]);
                        category.Name = dr["CategoryName"].ToString();
                        category.Description = dr["Description"].ToString();
                        categories.Add(category);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cn.Close();
                cn.Dispose();
            }
            return categories;

        }
        public void NewCategory(Category category)
        {

            SqlConnection cn = new SqlConnection(connectionString);
            SqlCommand cmd_insert = new SqlCommand("insert into categories (categoryname,Description) values" +
                "(@catname,@catdes)", cn);
            cn.Open();
            cmd_insert.Parameters.AddWithValue("@catname", category.Name);
            cmd_insert.Parameters.AddWithValue("@catdes", category.Description);
            cmd_insert.ExecuteNonQuery();//Insert is a statement, not a query, so ExecuteNonQuery() method
            cn.Close();
            cn.Dispose();





        }

        public void DeleteCategory(int id)
        { }
        public void UpdateCategory(int id, Category newDetails) { }


        //public Category SearchCategory(string name) {}

        //public Category SearchCategory(int id) { }


    }
}