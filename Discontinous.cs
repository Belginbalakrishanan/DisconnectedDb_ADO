using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DisconnectedDB
{
    internal class Discontinous
    {
        public static void select()
        {
            string conStr= ConfigurationManager.ConnectionStrings["cn"].ToString();
            SqlConnection con = new SqlConnection(conStr);
            string query = "select * from employee";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(query,con);
            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet);
            DataTable table = dataSet.Tables[0];
            foreach(DataRow rows in table.Rows)
            {
                Console.WriteLine(rows[0] + "\t" + rows[1] + "\t" + rows[2] + "\t");
            }
        }
        public static void Update()
        {
            //SqlCommandBuilder=>
            //select
            //update
            string conStr = ConfigurationManager.ConnectionStrings["cn"].ToString();
            SqlConnection con = new SqlConnection(conStr);
            string query = "select * from employee";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(query, con);
            SqlCommandBuilder cmd = new SqlCommandBuilder(dataAdapter);
            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet);
            DataTable table = dataSet.Tables[0];

            DataRow[] rowUpdate = table.Select("empid="+ 1);
            foreach(DataRow row in rowUpdate)
            {
                row["ename"] = "Pavithra";
            }
            dataAdapter.Update(dataSet);


            foreach (DataRow rows in table.Rows)
            {
                Console.WriteLine(rows[0] + "\t" + rows[1] + "\t" + rows[2] + "\t");
            }
        }

        public static void Delete()
        {
            //SqlCommandBuilder=>
            //select
            //update
            string conStr = ConfigurationManager.ConnectionStrings["cn"].ToString();
            SqlConnection con = new SqlConnection(conStr);
            string query = "select * from employee";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(query, con);
            SqlCommandBuilder cmd = new SqlCommandBuilder(dataAdapter);
            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet);
            DataTable table = dataSet.Tables[0];


            DataRow[] rowUpdate = table.Select("empid=" + 9);
            foreach (DataRow row in rowUpdate)
            {
                row.Delete();
            }
            dataAdapter.Update(dataSet);


            foreach (DataRow rows in table.Rows)
            {
                Console.WriteLine(rows[0] + "\t" + rows[1] + "\t" + rows[2] + "\t");
            }
        }
        public static void Insert()
        {
            string conStr = ConfigurationManager.ConnectionStrings["cn"].ToString();
            SqlConnection con = new SqlConnection(conStr);
            string query = "select * from employee";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(query, con);
            SqlCommandBuilder cmd = new SqlCommandBuilder(dataAdapter);
            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet);
            DataTable table = dataSet.Tables[0];

            DataRow datarow = table.NewRow();
            datarow["empid"] = 9;
            datarow["ename"] = "Rethika";
            datarow["deptno"] = 103;
            table.Rows.Add(datarow);
            dataAdapter.Update(dataSet);


            foreach (DataRow rows in table.Rows)
            {
                Console.WriteLine(rows[0] + "\t" + rows[1] + "\t" + rows[2] + "\t");
            }
        }
    }
}
