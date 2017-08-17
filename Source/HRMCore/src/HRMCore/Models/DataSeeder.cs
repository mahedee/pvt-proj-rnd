using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using Microsoft.AspNet.Builder;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
//using System.Data

namespace HRMCore.Models
{

    public static class DataSeeder
    {
        // TODO: Move this code when seed data is implemented in EF 7

        /// <summary>
        /// This is a workaround for missing seed data functionality in EF 7.0-rc1
        /// More info: https://github.com/aspnet/EntityFramework/issues/629
        /// </summary>
        /// <param name="app">
        /// An instance that provides the mechanisms to get instance of the database context.
        /// </param>
        public static void SeedData(this IApplicationBuilder app)
        {
            var db = app.ApplicationServices.GetService<HRMContext>();

            // TODO: Add seed logic here


            var objSE = new Designation { Name = "Software Engineer" };
            var objSSE = new Designation { Name = "Senior Engineer" };
            var objSA = new Designation { Name = "Software Archiect" };
            var objBA = new Designation { Name = "Business Analyst" };
            var objOfficer = new Designation { Name = "Officer" };
            var objSrOfficer = new Designation { Name = "Sr. Officer" };
            var objAssMgr = new Designation { Name = "Asst. Manager" };

            var objSSD = new Dept { Name = "Software Development" };
            var objIMP = new Dept { Name = "Software Implementation" };
            var objFin = new Dept { Name = "Finance & Administration" };
            var objMkt = new Dept { Name = "Sells & Marketing" };



            var lstEmployees = new List<Employee>()
            {
                new Employee(){EmpCode = "L0001", FullName = "Tariqul Islam", NickName = "Shakil",
                    Designation = objSE, Dept = objSSD, Phone = "01715333333", Email ="demo@gmail.com"  },

                new Employee(){EmpCode = "L0002", FullName = "Enamul Haque", NickName = "Rony",
                    Designation = objSSE, Dept = objIMP, Phone = "01715333332", Email ="deom@gmail.com"  },

                new Employee(){EmpCode = "L0003", FullName = "Mallik Arif Ahsan", NickName = "Arif",
                    Designation = objAssMgr, Dept = objFin, Phone = "01715333332", Email ="deom@gmail.com"  },

                new Employee(){EmpCode = "L0004", FullName = "Jafrin Islam", NickName = "Sinthi",
                    Designation = objSSE, Dept = objSSD, Phone = "01715333334", Email ="demo@gmail.com"  },

                new Employee(){EmpCode = "L0005", FullName = "Md. Mahedee Hasan", NickName = "Mahedee",
                    Designation = objSSE, Dept = objSSD, Phone = "01715333334", Email ="demo@gmail.com"  },

            };


            List<Dept> lstDept = new List<Dept> {
                     new Dept { Name = "Supply Chain" },
                     new Dept { Name = "Software Innovation" }
                };

            List<Designation> lstDesignation = new List<Designation>
            {
                    new Designation { Name = "Executive" },
                    new Designation { Name = "Senior Executive" },
                    new Designation { Name = "Manager" },
                    new Designation { Name = "Deputy Manager" },
                    new Designation { Name = "Project Manager" }
            };

            if (db.Depts.ToList().Count <= 0)
                db.AddRange(lstDept);

            if (db.Designations.ToList().Count <= 0)
                db.AddRange(lstDesignation);

            if (db.Employees.ToList().Count <= 0)
                db.Employees.AddRange(lstEmployees);

            db.SaveChanges();
        }
    }
}
