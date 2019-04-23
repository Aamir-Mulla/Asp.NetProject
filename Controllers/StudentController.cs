using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCrud.Models;
using System.Data.SqlClient;

namespace MvcCrud.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        DbModels dbModel = new DbModels();
        public ActionResult Index()
        {
            var data = dbModel.prc_getstudentdetails();
            return View(data.ToList());
        }

        // GET: Student/Details/5
        public ActionResult Details(int id)
        {
            SqlParameter param1 = new SqlParameter("studentId", id);
            var data = dbModel.Database.SqlQuery<Student>("exec prc_getstudentbyid @studentId", param1).SingleOrDefault();
            return View(data);
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Student/Create
        [HttpPost]
        public ActionResult Create(Student student)
        {
            try
            {
                // TODO: Add insert logic here

                SqlParameter param1 = new SqlParameter("@name", student.Name);
                SqlParameter param2 = new SqlParameter("@class", student.Class);
                SqlParameter param3 = new SqlParameter("@address", student.Address);
                var data = dbModel.Database.ExecuteSqlCommand("prc_insertstudentdetails @name , @class , @address", param1, param2, param3);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/Edit/5
        public ActionResult Edit(int id)
        {
            SqlParameter param1 = new SqlParameter("studentId", id);
            var data = dbModel.Database.SqlQuery<Student>("exec prc_getstudentbyid @studentId", param1).SingleOrDefault();
            return View(data);
        }

        // POST: Student/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Student student)
        {
            try
            {
                // TODO: Add update logic here
                SqlParameter param1 = new SqlParameter("@studentId", student.StudentId);
                SqlParameter param2 = new SqlParameter("@name", student.Name);
                SqlParameter param3 = new SqlParameter("@class", student.Class);
                SqlParameter param4 = new SqlParameter("@address", student.Address);
                var data = dbModel.Database.ExecuteSqlCommand("prc_editstudent @studentId , @name , @class , @address", param1, param2, param3, param4);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/Delete/5
        public ActionResult Delete(int id)
        {
            SqlParameter param1 = new SqlParameter("@studentId", id);
            var data = dbModel.Database.SqlQuery<Student>("exec prc_getstudentbyid @studentId", param1).SingleOrDefault();
            return View(data);
        }

        // POST: Student/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                SqlParameter param1 = new SqlParameter("@studentId", id);
                var data = dbModel.Database.ExecuteSqlCommand("prc_deletestudentdetails @studentId", param1);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
