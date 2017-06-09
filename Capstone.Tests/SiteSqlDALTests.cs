using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Transactions;
using System.Configuration;
using Capstone.DAL;
using Capstone.Models;

namespace Capstone.Tests
{
    //[TestClass]
    //public class SiteSqlDALTests
    //{
    //    private TransactionScope tran;      //<-- used to begin a transaction during initialize and rollback during cleanup
    //    readonly string connectionString = ConfigurationManager.ConnectionStrings["ProjectDatabaseConnection"].ConnectionString;
    //    int tempCampgroundID;
    //    int siteCount;
    //     temp = new Department();

    //    [TestInitialize]
    //    public void Initialize()
    //    {
    //        tran = new TransactionScope();

    //        using (SqlConnection conn = new SqlConnection(connectionString))
    //        {
    //            SqlCommand cmd;

    //            conn.Open();

    //            cmd = new SqlCommand("SELECT COUNT(*) FROM department;", conn);
    //            deptCount = Convert.ToInt32(cmd.ExecuteScalar());

    //            cmd = new SqlCommand("INSERT INTO department VALUES('Department of Redundancy Department'); SELECT CAST(SCOPE_IDENTITY() AS INT);", conn);
    //            temp.Id = (int)cmd.ExecuteScalar();

    //            cmd = new SqlCommand($"UPDATE department SET name = 'Department of Whoops' WHERE department_id = {tempDeptID};", conn);
    //            temp.Name = "Department of Whoops";
    //            cmd.ExecuteNonQuery();
    //        }
    //    }


    //    [TestCleanup]
    //    public void CleanUp()
    //    {
    //        tran.Dispose();
    //    }

    //    [TestMethod]
    //    public void SiteSqlDALTests_GetsFromTable()
    //    {


    //    }
    //}
}
