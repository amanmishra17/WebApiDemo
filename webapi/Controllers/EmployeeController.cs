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
        public IEnumerable<tblEmp> Get()
        {
            using (dbEmployeeEntities entities = new dbEmployeeEntities())
            {
                return entities.tblEmps.ToList();
            }
        }
        public HttpResponseMessage Get(int id)
        {
            using (dbEmployeeEntities entities = new dbEmployeeEntities())
            {
                var entity =  entities.tblEmps.FirstOrDefault(e => e.EmpId == id);
                if(entity!=null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, entity);

                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "employee with id = "+id.ToString() + "not found");
                }
            }

        }
        public HttpResponseMessage Post([FromBody] tblEmp employee)
        {   try
            {
                using (dbEmployeeEntities entities = new dbEmployeeEntities())
                {
                    entities.tblEmps.Add(employee);
                    entities.SaveChanges();
                    var message = Request.CreateResponse(HttpStatusCode.Created, employee);
                    message.Headers.Location = new Uri(Request.RequestUri + employee.EmpId.ToString());
                    return message;
                }
            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}
