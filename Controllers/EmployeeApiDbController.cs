using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiEmployee.Models;

namespace WebApiEmployee.Controllers
{
    
           
    public class EmployeeApiDbController : ApiController
    {
        CrudOperationDBEmpEntities db = new CrudOperationDBEmpEntities();
        [HttpGet]
        public IHttpActionResult ActionModel()
        {
            List<CrudEmployeedb> list = db.CrudEmployeedbs.ToList();
            return Ok(list);
        }
        [HttpGet]
     public IHttpActionResult GetEmployeeMethod(int id)
        {
            var obj = db.CrudEmployeedbs.Where(Model=> Model.Id == id).FirstOrDefault();
            return Ok(obj);
        }

        [HttpPost]
        public IHttpActionResult EmployeeInsert(CrudEmployeedb crd)
        {
            db.CrudEmployeedbs.Add(crd);
            db.SaveChanges();
            return Ok();
        }
        [HttpPut]
        public IHttpActionResult EmployeeUpdate(CrudEmployeedb crd)
        {
            
            db.Entry(crd).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            //var emp = db.CrudEmployeedbs.Where(Model => Model.Id == crd.Id).FirstOrDefault();
            //if (emp != null)
            //{
            //    emp.Id = crd.Id;
            //    emp.Name = crd.Name;
            //    emp.Aderess = crd.Aderess;
            //    emp.Designation = crd.Designation;
            //    emp.Salary = crd.Salary;
            //    db.SaveChanges();
            //}
            //else
            //{
            //    return NotFound();
            //}
            return Ok();
        }
        [HttpDelete]
        public IHttpActionResult EmployeeDelete(int id)
        {
            var obj = db.CrudEmployeedbs.Where(Model => Model.Id == id).FirstOrDefault();
            db.Entry(obj).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();
            return Ok();
        }
    }
}
