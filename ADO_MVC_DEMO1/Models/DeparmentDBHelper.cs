using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace ADO_MVC_DEMO1.Models
{
    public class DeparmentDBHelper
    {
        public List<Department> GetDepartments()
        {
            List<Department> departments = new List<Department>();
            string str = ConfigurationManager.ConnectionStrings["ProductContext"].ConnectionString;

            using (SqlConnection con = new SqlConnection(str))
            {
                using (SqlCommand cmd = new SqlCommand("usp_getdata", con))
                {
                    con.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Department d = new Department();
                            d.Id = (int)reader["Id"];
                            d.Name = reader["Name"].ToString();
                            d.Location = reader["Location"].ToString();
                            departments.Add(d);
                        }
                    }
                }
            }
            return departments;
        }
    
        public void InsertDeptDetails(Department department)
        {
          
            string str = ConfigurationManager.ConnectionStrings["ProductContext"].ConnectionString;

            using (SqlConnection con = new SqlConnection(str))
            {
                SqlCommand cmd = new SqlCommand("usp_insertData", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                
                cmd.Parameters.AddWithValue("@Name", department.Name);
                cmd.Parameters.AddWithValue("@Location", department.Location);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
       
        public void UpdateDeptDetails(Department department)
        {
     
            string str = ConfigurationManager.ConnectionStrings["ProductContext"].ConnectionString;
           
            using (SqlConnection con = new SqlConnection(str))
            {
                SqlCommand cmd = new SqlCommand("usp_Updatedeprtment", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id", department.Id);
                cmd.Parameters.AddWithValue("@Name", department.Name);
                cmd.Parameters.AddWithValue("@Location", department.Location);

                con.Open();

                cmd.ExecuteNonQuery();
            }

        }

        public void DeleteDeptDetails(int? Id)
        {

            string str = ConfigurationManager.ConnectionStrings["ProductContext"].ConnectionString;

            using (SqlConnection con = new SqlConnection(str))
            {
                SqlCommand cmd = new SqlCommand("usp_Deletedeprtment", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id",Id);
                 
                con.Open();

                cmd.ExecuteNonQuery();
            }   

        }


    }

}





