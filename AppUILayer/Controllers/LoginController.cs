using AppUILayer.Model;
using BlogDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace AppUILayer.Controllers
{
    public class LoginController : Controller
    {
        BlogContext db = new BlogContext();
        // GET: Login
        public ActionResult adminLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult adminLogin(AdminLoginModel admin)
        {
           
            if (ModelState.IsValid)
            {
                var obj = db.AdminInfos.Where(a=>a.EmailId.Equals(admin.EmailId) && a.Password.Equals(admin.Password)).FirstOrDefault();
                if (obj != null)
                {
                    FormsAuthentication.SetAuthCookie(obj.EmailId, false);
                    Session["EmailId"] = obj.EmailId.ToString();
                    return RedirectToAction("Index", "Emp");
                }
                
            }

            ModelState.AddModelError("", "Invalid email or password");
            return View(admin);
        }
        public ActionResult empLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult empLogin(EmpLoginModel emp)
        {

            if (ModelState.IsValid)
            {
                var obj = db.EmpInfos.Where(e => e.EmailId.Equals(emp.EmailId) && e.PassCode.Equals(emp.PassCode)).FirstOrDefault();
                if (obj != null)
                {
                    FormsAuthentication.SetAuthCookie(obj.EmailId, false);
                    Session["EmailId"] = obj.EmailId.ToString();
                    Session["Name"] = obj.Name.ToString();
                    return RedirectToAction("showList", "Blog");
                }
            }

            ModelState.AddModelError("", "Invalid email or password");
            return View(emp);
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            return RedirectToAction("Index", "Blog"); 
        }

    }
}