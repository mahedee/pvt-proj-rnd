using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MVC.RdlcReport.Models
{

    public class ERPDBContext : IdentityDbContext<ApplicationUser>
    {


        public ERPDBContext()
            : base("DefaultConnection", throwIfV1Schema: true)
        {

        }

        public static ERPDBContext Create()
        {
            return new ERPDBContext();
        }


        public DbSet<Designation> Designations { get; set; }
        public DbSet<Employee> Employees { get; set; }

        //public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        public DataTable GetReportDS(string spName, int param)
        {
            using (this.Database.Connection)
            {
                Database.Connection.Open();
                DbCommand cmd = Database.Connection.CreateCommand();
                cmd.CommandText = "[rsp_employee_info]";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@designationId", 3));
                //cmd.Parameters.Add(new SqlParameter("SubID", subdivisionID));
                //cmd.Parameters.Add(new SqlParameter("FromDueDate", fromDueDate));
                //cmd.Parameters.Add(new SqlParameter("ToDueDate", toDueDate));
                //cmd.Parameters.Add(new SqlParameter("ShowHistory", showHistory));
                //cmd.Parameters.Add(new SqlParameter("CurrentPage", currentPage));
                //cmd.Parameters.Add(new SqlParameter("PageSize", pageSize));
                //var totalCountParam = new SqlParameter("TotalCount", 0) { Direction = ParameterDirection.Output };
                //cmd.Parameters.Add(totalCountParam);

                var reader = cmd.ExecuteReader();
                //DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                dt.Load(reader);
                //ds.Tables.Add(dt);
                //ds[]
                //ds.Load(reader)
                

                //List<Task> tasks;
                //using (var reader = cmd.ExecuteReader())
                //{
                //    tasks = reader.MapToList<MyItem>();
                //}
                ////Access output variable after reader is closed
                //totalCount = (totalCountParam.Value == null) ? 0 : Convert.ToInt32(totalCountParam.Value);
                //return tasks;
                return dt;
            }
        }



    }

}