using KhabaryabCMS.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KhabaryabCMS.Controllers
{
    public class NewsController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        [ChildActionOnly]
        public ActionResult ShowGroups()
        {
            return PartialView(db.NewsGroups);
        }

        [Route("Groups")]
        public ActionResult Groups()
        {
            ViewBag.Layout = "~/Views/Shared/_Layout.cshtml";
            return View("ShowGroups", db.NewsGroups);
        }

        [ChildActionOnly]
        public ActionResult ShowNews()
        {
            return PartialView(db.News.OrderByDescending(i => i.CreateDate).Take(8));
        }

        [Route("TopNews")]
        public ActionResult TopNews()
        {
            ViewBag.Layout = "~/Views/Shared/_Layout.cshtml";
            return PartialView("ShowNews", db.News.OrderByDescending(i => i.CreateDate).Take(8));
        }

        [Route("News/{id}")]
        public ActionResult NewsDetails(int id)
        {
            News news = db.News.Find(id);
            if(news == null)
                return HttpNotFound();

            news.Visit++;
            ViewBag.Title = news.Title;
            db.SaveChanges();

            return View(news);
        }

        [Route("Group/{id}")]
        public ActionResult Group(int id)
        {
            NewsGroup group = db.NewsGroups.Find(id);
            if (group == null)
                return HttpNotFound();

            ViewBag.Title = "آخرین اخبار " + group.Title;
            return View(group);
        }

        [Authorize]
        public ActionResult Edit(int id)
        {
            News news = db.News.Find(id);
            if (news == null)
                return HttpNotFound();

            return View(news);
        }

        [Authorize, HttpPost]
        public ActionResult Edit(int id, News model, HttpPostedFileBase NewImage)
        {
            News news = db.News.Find(id);
            if (news == null)
                return HttpNotFound();

            if (NewImage != null)
            {
                string filename = Guid.NewGuid().ToString("n") + Path.GetExtension(NewImage.FileName);
                if (!Directory.Exists(Server.MapPath("/Images/News")))
                    Directory.CreateDirectory(Server.MapPath("/Images/News"));
                NewImage.SaveAs(Path.Combine(Server.MapPath("/Images/News"), filename));
                news.Image = filename;
            }

            news.Title = model.Title;
            news.Description = model.Description;
            news.Content = model.Content;
            db.SaveChanges();

            return Redirect("/News/" + news.NewsID);
        }

        protected override void Dispose(bool disposing)
        {
            if(disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}