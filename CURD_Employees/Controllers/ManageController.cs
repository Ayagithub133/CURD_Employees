using CURD_Employees.Domain;
using CURD_Employees.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CURD_Employees.Controllers
{
    public class ManageController : Controller
        
    {
        private DataAcessLayer DAL = new DataAcessLayer();
        // GET: Manage
        //[HttpGet]
        //public ActionResult Index()
        //{
        //    List<Employee> emps =  DAL.RetriveAllEmps();
        //    return View(emps);
        //}
        ///////////////////////////////////////////////////////
        [HttpGet]
        public ActionResult Index(int pagenum=1 , string searchvalue=null)
        {
            List<Employee> emps = DAL.getData(pagenum , searchvalue);
           float temp = DAL.CountOfEmployees()/5.0f;
            TempData["show"] = DAL.CountOfEmployees();
           
            
            if (temp - Convert.ToInt32(temp)==0.0)
            {
                TempData["count"] = temp;
            }
            else
            {
                TempData["count"] = Convert.ToInt32(temp )+ 1;
            }
            return View(emps);
        }

        //////////////////////////////////////////////////////
        [HttpGet]
        public ActionResult Edit(int id)
        {

            return View(DAL.EmpById(id));
        }
        [HttpPost]
        public ActionResult Edit(Employee emp, HttpPostedFileBase upload)
        {
            string path = Path.Combine(Server.MapPath("~/upload/"), upload.FileName);
            upload.SaveAs(path);
            emp.Image = upload.FileName;
            DAL.EditEmployee(emp);
            return RedirectToAction("Index");
        }
        /// ///////////////////////////////////////////
        /// 
        [HttpPost]
        public ActionResult Delete(int id)
        {
            DAL.DeleteEmployee(id);
            return RedirectToAction("Index");
        }

        ////////////////////////////////////////////
        [HttpPost]
        public ActionResult DeleteAll()
        {
            DAL.DeleteAll();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Create()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult Create(Employee emp , HttpPostedFileBase upload)
        {
            string path = Path.Combine(Server.MapPath("~/Upload/"), upload.FileName);
            upload.SaveAs(path);
            emp.Image = upload.FileName;
           
            DAL.AddEmployee(emp);

           
            return View();
        }

    }
}