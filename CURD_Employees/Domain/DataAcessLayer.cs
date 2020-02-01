using CURD_Employees.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Linq.Mapping;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CURD_Employees.Domain
{
    public class DataAcessLayer
    {
        
        SqlConnection con = new SqlConnection("Data Source =.; Initial Catalog = Company; Integrated Security = True");
        [Function(Name = "AddEmployee")]
        public void AddEmployee(Employee emp)
        {

            try
            {
                SqlCommand cmd = new SqlCommand("AddEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@fname", emp.FirstName);
                cmd.Parameters.AddWithValue("@lname", emp.LastName);
                cmd.Parameters.AddWithValue("@salary", emp.Salary);
                cmd.Parameters.AddWithValue("@address", emp.Address);
                cmd.Parameters.AddWithValue("@pic", emp.Image);
                cmd.Parameters.AddWithValue("@active", 1);
                cmd.Parameters.AddWithValue("@email", emp.Email);
                cmd.Parameters.AddWithValue("@phone", emp.Phone);
                cmd.Parameters.AddWithValue("@jobtitle", emp.JobTitle);
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch { }
            finally { con.Close(); }
        }

        /// /////////////////////////////////////////////////////
       [Function(Name = "DeleteAll")]
        public void DeleteAll()
        {

            try
            {
                SqlCommand cmd = new SqlCommand("DeleteAll", con);
                cmd.CommandType = CommandType.StoredProcedure;
              

                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch { }
            finally { con.Close(); }
        }
        /// 
        /// ////////////////////////////////////////////////
        [Function(Name = "DeleteEmployee")]
        public void DeleteEmployee(int id)
        {

            try
            {
                SqlCommand cmd = new SqlCommand("DeleteEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@empid", id);
                
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch { }
            finally { con.Close(); }
        }
        /// <summary>
        /// //////////////////////////////
        /// </summary>
        /// <param name="emp"></param>
        [Function(Name = "EditEmployee")]
        public void EditEmployee(Employee emp)
        {

            try
            {
                SqlCommand cmd = new SqlCommand("EditEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@empid", emp.EmpId);
                cmd.Parameters.AddWithValue("@fname", emp.FirstName);
                cmd.Parameters.AddWithValue("@lname", emp.LastName);
                cmd.Parameters.AddWithValue("@salary", emp.Salary);
                cmd.Parameters.AddWithValue("@address", emp.Address);
                cmd.Parameters.AddWithValue("@pic",emp.Image);
                cmd.Parameters.AddWithValue("@active",Convert.ToByte(emp.Active));
                cmd.Parameters.AddWithValue("@email", emp.Email);
                cmd.Parameters.AddWithValue("@phone", emp.Phone);
                cmd.Parameters.AddWithValue("@jobtitle", emp.JobTitle);
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch { }
            finally
            {
                con.Close();
            }
        }




        /////////////////////////////////////////////////////////////
        [Function(Name = "EmpById")]

        public Employee EmpById(int id)
        {
            Employee emp = null;
            try
            {
                SqlCommand cmd = new SqlCommand("EmpById", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@empid", id);
                con.Open();
                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    emp = new Employee();
                    emp.FirstName = read["FirstName"].ToString();
                    emp.LastName = read["LastName"].ToString();
                    emp.Salary = Convert.ToInt64(read["Salary"]);
                    emp.Phone = read["phone"].ToString();
                    emp.JobTitle = read["JobTitle"].ToString();
                    emp.Address = read["Address"].ToString();
                    emp.Email = read["Email"].ToString();
                   
                    emp.Image = read["Pic"].ToString();
                    emp.Active = Convert.ToBoolean(read["active"]);
                    emp.EmpId= Convert.ToInt32(read["EmpId"]);
                    break;

                }
                read.Close();
                return emp;


            }
            catch { return emp; }
            finally { con.Close(); }
        }

        /////////////////////////////////////////////////////////////
        [Function(Name = "RetriveAllEmps")]

        public List<Employee> RetriveAllEmps()
        {
            //SqlConnection con2 = null;
            Employee emp = null;
            List<Employee> emps = new List<Employee>();
            try
            {
                //con2 = new SqlConnection("Data Source=.;Initial Catalog=Company;Integrated Security=True");
                SqlCommand cmd = new SqlCommand("RetriveAllEmps", con);
                cmd.CommandType = CommandType.StoredProcedure;
                
                con.Open();
                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    emp = new Employee();
                    emp.FirstName = read["FirstName"].ToString();
                    emp.LastName = read["LastName"].ToString();
                    emp.Salary = Convert.ToInt64(read["Salary"]);
                    emp.Phone = read["phone"].ToString();
                    emp.JobTitle = read["JobTitle"].ToString();
                    emp.Address = read["Address"].ToString();
                    emp.Email = read["Email"].ToString();
                    emp.EmpId = Convert.ToInt32(read["EmpId"]);
                    emp.Image = read["Pic"].ToString();
                    emp.Active = Convert.ToBoolean(read["Active"]);
                    emps.Add(emp);

                }
                read.Close();
                return emps;


            }
            catch { return emps; }
            finally { con.Close(); }
        }
        ///////////////////////////////////////////

        [Function(Name = "CountOfEmployees ")]
        public int CountOfEmployees()
        {
            int count = 0;
            try
            {
                SqlCommand cmd = new SqlCommand("CountOfEmployees ", con);
                cmd.CommandType = CommandType.StoredProcedure;
                
                SqlParameter param = new SqlParameter();
                param.ParameterName = "@count";
                param.SqlDbType = SqlDbType.Int;
                param.Direction = ParameterDirection.Output;
                
                cmd.Parameters.Add(param);
                con.Open();
                cmd.ExecuteNonQuery();
                count= Convert.ToInt32(param.Value);
                
                return count;
            }
            catch { return count; }
            finally { con.Close(); }
        }
        ////////////////////////////////////////
        [Function(Name = "getData")]

        public List<Employee> getData(int pagenum , string searchvalue)
        {
            //SqlConnection con2 = null;
            Employee emp = null;
            List<Employee> emps = new List<Employee>();
            try
            {
                //con2 = new SqlConnection("Data Source=.;Initial Catalog=Company;Integrated Security=True");
                SqlCommand cmd = new SqlCommand("getData", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@index", pagenum);
                cmd.Parameters.AddWithValue("@searchname", searchvalue);
                con.Open();
                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                  
                    emp = new Employee();
                    emp.FirstName = read["FirstName"].ToString();
                    emp.LastName = read["LastName"].ToString();
                    emp.Salary = Convert.ToInt64(read["Salary"]);
                    emp.Phone = read["phone"].ToString();
                    emp.JobTitle = read["JobTitle"].ToString();
                    emp.Address = read["Address"].ToString();
                    emp.Email = read["Email"].ToString();
                    emp.EmpId = Convert.ToInt32(read["EmpId"]);
                    emp.Image = read["Pic"].ToString();
                    emp.Active = Convert.ToBoolean(read["Active"]);
                    emps.Add(emp);

                }
                read.Close();
                return emps;


            }
            catch { return emps; }
            finally { con.Close(); }
        }
    }
    } 