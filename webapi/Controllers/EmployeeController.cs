using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EmployeeDataAccess;

namespace webapi.Controllers
{
    public class EmployeeController : ApiController
    {
        public IEnumerable<tblEmp>Get()
        {
            using (dbEmployeeEntities entities = new dbEmployeeEntities())
            {
                return entities.tblEmps.ToList();
            }
        }
        public tblEmp Get(int id)
        {
            using (dbEmployeeEntities entities = new dbEmployeeEntities())
            {
                return entities.tblEmps.FirstOrDefault(e=>e.EmpId==id);
            }
        }
    }
}
