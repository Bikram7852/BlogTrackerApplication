using AppUILayer.Model;
using BlogDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;

namespace AppUILayer.Controllers
{
    public class EmpController : Controller
    {
        BlogContext db = new BlogContext();
        // GET: Emp
        
        public ActionResult Index()
        {
            if (Session["EmailId"] != null)
            {
                List<EmpInfo> emplist = db.EmpInfos.ToList();
                List<EmpInfoModel> model = new List<EmpInfoModel>();
                foreach (var item in emplist)
                {
                    EmpInfoModel emp = new EmpInfoModel();
                    emp.EmailId = item.EmailId;
                    emp.Name = item.Name;
                    emp.DateOfJoining = item.DateOfJoining;
                    emp.PassCode = item.PassCode;
                    model.Add(emp);
                }
                return View(model); 
            }
            else
            {
                return RedirectToAction("adminLogin", "Login");
            }
        }
        

        // GET: Emp/Create
        public ActionResult Create()
        {
            if (Session["EmailId"] != null)
            {
                return View(); 
            }
            else
            {
                return RedirectToAction("adminLogin", "Login");
            }
        }

        // POST: Emp/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                EmpInfoModel model = new EmpInfoModel();
                model.EmailId = collection["EmailId"].ToString();
                model.Name = collection["Name"].ToString();
                model.DateOfJoining = collection["DateOfJoining"].AsDateTime();
                model.PassCode = Convert.ToInt32(collection["PassCode"]);
                EmpInfo emp = new EmpInfo();
                emp.EmailId = model.EmailId;
                emp.Name = model.Name;
                emp.DateOfJoining = model.DateOfJoining;
                emp.PassCode = model.PassCode;
                db.EmpInfos.Add(emp);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Emp/Edit/5
        public ActionResult Edit(string Email)
        {
            if (Session["EmailId"] != null)
            {
                EmpInfo emp = db.EmpInfos.Find(Email);
                EmpInfoModel model = new EmpInfoModel();
                model.EmailId = emp.EmailId;
                model.Name = emp.Name;
                model.DateOfJoining = Convert.ToDateTime(emp.DateOfJoining);
                model.PassCode = emp.PassCode;
                return View(model); 
            }
            else
            {
                return RedirectToAction("adminLogin", "Login");
            }
        }
        // POST: Emp/Edit/5
        [HttpPost]
        public ActionResult Edit(string Email, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                EmpInfo emp = db.EmpInfos.Find(Email);
                emp.EmailId = collection["EmailId"].ToString();
                emp.Name = collection["Name"].ToString();
                emp.DateOfJoining = collection["DateOfJoining"].AsDateTime();
                emp.PassCode = Convert.ToInt32(collection["PassCode"]);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Emp/Delete/5
        public ActionResult Delete(string Email)
        {
            if (Session["EmailId"] != null)
            {
                EmpInfo emp = db.EmpInfos.Find(Email);
                EmpInfoModel model = new EmpInfoModel();
                model.EmailId = emp.EmailId;
                model.Name = emp.Name;
                model.DateOfJoining = emp.DateOfJoining;
                model.PassCode = emp.PassCode;
                return View(model); 
            }
            else
            {
                return RedirectToAction("adminLogin", "Login");
            }
        }

        // POST: Emp/Delete/5
        [HttpPost]
        public ActionResult Delete(string Email, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                EmpInfo emp = db.EmpInfos.Find(Email);
                db.EmpInfos.Remove(emp);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
