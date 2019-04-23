using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCrud.Models;
using System.Data.SqlClient;

namespace MvcCrud.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        DbModels dbm = new DbModels();
        public ActionResult Index()
        {
            var data = dbm.PRC_GETEMPDETAILS();
            return View(data.ToList());
        }

        // GET: Employee/Details/5
        public ActionResult Details(int id)
        {
            SqlParameter param1 = new SqlParameter("@emp_id", id);
            var data = dbm.Database.SqlQuery<Employee>("exec PRC_GETEMPBYID @emp_id", param1).SingleOrDefault();
            return View(data);
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            try
            {
                // TODO: Add insert logic here
                SqlParameter param1 = new SqlParameter("@name", employee.Name);
                SqlParameter param2 = new SqlParameter("@address", employee.Address);
                SqlParameter param3 = new SqlParameter("@position", employee.Position);
                var data = dbm.Database.ExecuteSqlCommand("PRC_INSERTEMPDETAILS @name , @address , @position", param1, param2, param3);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int id)
        {
            SqlParameter param1 = new SqlParameter("@emp_id", id);
            var data = dbm.Database.SqlQuery<Employee>("exec PRC_GETEMPBYID @emp_id", param1).SingleOrDefault();
            return View(data);
        }

        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Employee employee)
        {
            try
            {
                // TODO: Add update logic here
                SqlParameter param1 = new SqlParameter("@emp_id", employee.EmpId);
                SqlParameter param2 = new SqlParameter("@name", employee.Name);
                SqlParameter param3 = new SqlParameter("@address", employee.Address);
                SqlParameter param4 = new SqlParameter("@position", employee.Position);
                var data = dbm.Database.ExecuteSqlCommand("PRC_UPDATEEMPDETAILS @emp_id , @name , @address , @position", param1, param2, param3, param4);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int id)
        {
            SqlParameter param1 = new SqlParameter("@emp_id", id);
            var data = dbm.Database.SqlQuery<Employee>("exec PRC_GETEMPBYID @emp_id", param1).SingleOrDefault();
            return View(data);
        }

        // POST: Employee/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                SqlParameter param1 = new SqlParameter("@emp_id", id);
                dbm.Database.ExecuteSqlCommand("PRC_DELETEEMPDETAILS @emp_id", param1);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
