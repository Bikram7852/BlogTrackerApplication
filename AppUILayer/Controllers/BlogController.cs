using AppUILayer.Model;
using BlogDAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;

namespace AppUILayer.Controllers
{
    public class BlogController : Controller
    {
        BlogContext db = new BlogContext();

        // GET: Blog
        public ActionResult Index()
        {
            if (Session["EmailId"] == null)
            {
                List<BlogInfo> blogs = db.BlogInfos.ToList();
                List<BlogInfoModel> list = new List<BlogInfoModel>();

                foreach (var item in blogs)
                {
                    SelectList availableUserTypes = new SelectList(Enum.GetValues(typeof(UserType)));
                    BlogInfoModel bim = new BlogInfoModel
                    {
                        BlogId = item.BlogId,
                        Title = item.Title,
                        Subject = item.Subject,
                        DateOfCreation = item.DateOfCreation,
                        EmpEmailId = item.EmpEmailId,
                        BlogUrl = item.BlogUrl,
                        AvailableUserTypes = availableUserTypes
                    };

                    list.Add(bim);
                }
                return View(list); 
            }
            return HttpNotFound();
        }
        
        public ActionResult showList()
        {
            if (Session["EmailId"] != null)
            {
                string userEmail = Session["EmailId"].ToString();
                List<BlogInfo> blogs = db.BlogInfos.Where(b => b.EmpEmailId == userEmail).ToList();
                List<BlogInfoModel> list = new List<BlogInfoModel>();

                foreach (var item in blogs)
                {

                    BlogInfoModel bim = new BlogInfoModel
                    {
                        BlogId = item.BlogId,
                        Title = item.Title,
                        Subject = item.Subject,
                        DateOfCreation = item.DateOfCreation,
                        EmpEmailId = item.EmpEmailId,
                        BlogUrl = item.BlogUrl,

                    };

                    list.Add(bim);
                }
                return View(list); 
            }
            else
            {
                return RedirectToAction("empLogin", "Login");
            }
        }

        [HttpPost]
        public ActionResult UserTypeSelected(UserType selectedUserType)
        {
            ViewBag.SelectedUserType = selectedUserType;

            if (selectedUserType == UserType.Admin)
            {
                return RedirectToAction("adminLogin", "Login");
            }
            else if (selectedUserType == UserType.Employee)
            {
                return RedirectToAction("empLogin", "Login");
            }
            return HttpNotFound();
        }
        
        // GET: Blog/Create
        public ActionResult Create()
        {
            if (Session["EmailId"] != null)
            {
                return View(); 
            }
            else
            {
                return RedirectToAction("empLogin", "Login");
            }
        }

        // POST: Blog/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                
                    // TODO: Add insert logic here
                    BlogInfoModel model = new BlogInfoModel();
                    model.Title = collection["Title"].ToString();
                    model.Subject = collection["Subject"].ToString();
                    model.DateOfCreation = collection["DateOfCreation"].AsDateTime();
                    model.EmpEmailId = Session["EmailId"].ToString();
                    model.BlogUrl = collection["BlogUrl"].ToString();
                    BlogInfo blog = new BlogInfo();
                    blog.Title = model.Title;
                    blog.Subject = model.Subject;
                    blog.DateOfCreation = model.DateOfCreation;
                    blog.EmpEmailId = model.EmpEmailId;
                    blog.BlogUrl = model.BlogUrl;
                    db.BlogInfos.Add(blog);
                    db.SaveChanges();
                    return RedirectToAction("showList"); 
                
            }
            catch
            {
                return View();
            }
        }

        // GET: Blog/Edit/5
        public ActionResult Edit(int id)
        {
            if (Session["EmailId"] != null)
            {
                BlogInfo blog = db.BlogInfos.Find(id);
                BlogInfoModel model = new BlogInfoModel();
                model.BlogId = blog.BlogId;
                model.Title = blog.Title;
                model.Subject = blog.Subject;
                model.DateOfCreation = blog.DateOfCreation;
                model.EmpEmailId = blog.EmpEmailId;
                model.BlogUrl = blog.BlogUrl;
                return View(model); 
            }
            else
            {
                return RedirectToAction("empLogin", "Login");
            }
        }

        // POST: Blog/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                BlogInfo blog = db.BlogInfos.Find(id);
                blog.Title = collection["Title"].ToString();
                blog.Subject = collection["Subject"].ToString();
                blog.DateOfCreation = collection["DateOfCreation"].AsDateTime();
                blog.EmpEmailId = collection["EmpEmailId"].ToString();
                blog.BlogUrl = collection["BlogUrl"].ToString();
                db.SaveChanges();
                return RedirectToAction("showList");
            }
            catch
            {
                return View();
            }
        }

        // GET: Blog/Delete/5
        public ActionResult Delete(int id)
        {
            if (Session["EmailId"] != null)
            {
                BlogInfo blog = db.BlogInfos.Find(id);
                BlogInfoModel model = new BlogInfoModel();
                model.BlogId = blog.BlogId;
                model.Title = blog.Title;
                model.Subject = blog.Subject;
                model.DateOfCreation = blog.DateOfCreation;
                model.EmpEmailId = blog.EmpEmailId;
                model.BlogUrl = blog.BlogUrl;
                return View(model); 
            }
            else
            {
                return RedirectToAction("empLogin", "Login");
            }

        }

        // POST: Blog/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                BlogInfo blog = db.BlogInfos.Find(id);
                db.BlogInfos.Remove(blog);
                db.SaveChanges();
                return RedirectToAction("showList");
            }
            catch
            {
                return View();
            }
        }
    }
}
