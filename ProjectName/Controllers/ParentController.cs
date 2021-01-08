using Microsoft.AspNetCore.Mvc;
using ProjectName.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ProjectName.Controllers
{
    public class ParentsController : Controller
    {
        private readonly ProjectNameContext _db;

        public ParentsController(ProjectNameContext db)
        {
            _db = db;
        }

        public ActionResult Index()
        {
            List<Parent> model = _db.Parents.ToList();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Parent parent)
        {
            _db.Parents.Add(parent);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var thisParent = _db.Parents
                .Include(parent => parent.Childs)
                .ThenInclude(join => join.Child)
                .FirstOrDefault(parent => parent.ParentId == id);
            return View(thisParent);
        }

        public ActionResult Edit(int id)
        {
            var thisParent = _db.Parents.FirstOrDefault(parent => parent.ParentId == id);
            return View(thisParent);
        }

        [HttpPost]
        public ActionResult Edit(Parent parent)
        {
            _db.Entry(parent).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var thisParent = _db.Parents.FirstOrDefault(parent => parent.ParentId == id);
            return View(thisParent);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var thisParent = _db.Parents.FirstOrDefault(parent => parent.ParentId == id);
            _db.Parents.Remove(thisParent);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}