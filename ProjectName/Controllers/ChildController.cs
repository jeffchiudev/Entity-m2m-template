using Microsoft.AspNetCore.Mvc;
using ProjectName.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ProjectName.Controllers
{
    public class ChildsController : Controller
    {
        private readonly ProjectNameContext _db;

        public ChildsController(ProjectNameContext db)
        {
            _db = db;
        }

        public ActionResult Index()
        {
            return View(_db.Childs.ToList());
        }

        public ActionResult Create()
        {
            ViewBag.ParentId = new SelectList(_db.Parents, "ParentId", "ParentName");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Child child, int ParentId)
        {
            _db.Childs.Add(child);
            if (ParentId != 0)
            {
                _db.ParentChild.Add(new ParentChild() { ParentId = ParentId, ChildId = child.ChildId });
            }
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var thisChild = _db.Childs
                .Include(child => child.Parents)
                .ThenInclude(join => join.Parent)
                .FirstOrDefault(child => child.ChildId == id);
            return View(thisChild);
        }

        public ActionResult Edit(int id)
        {
            var thisChild = _db.Childs.FirstOrDefault(childs => childs.ChildId == id);
            ViewBag.ParentId = new SelectList(_db.Parents, "ParentId", "Name");
            return View(thisChild);
        }

        [HttpPost]
        public ActionResult Edit(Child child, int ParentId)
        {
            if (ParentId != 0)
            {
                _db.ParentChild.Add(new ParentChild() { ParentId = ParentId, ChildId = child.ChildId });
            }
            _db.Entry(child).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult AddParent(int id)
        {
            var thisChild = _db.Childs.FirstOrDefault(childs => childs.ChildId == id);
            ViewBag.ParentId = new SelectList(_db.Parents, "ParentId", "Name");
            return View(thisChild);
        }

        [HttpPost]
        public ActionResult AddParent(Child child, int ParentId)
        {
            if (ParentId != 0)
            {
                _db.ParentChild.Add(new ParentChild() { ParentId = ParentId, ChildId = child.ChildId });
            }
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var thisChild = _db.Childs.FirstOrDefault(childs => childs.ChildId == id);
            return View(thisChild);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var thisChild = _db.Childs.FirstOrDefault(childs => childs.ChildId == id);
            _db.Childs.Remove(thisChild);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult DeleteParent(int joinId)
        {
            var joinEntry = _db.ParentChild.FirstOrDefault(entry => entry.ParentChildId == joinId);
            _db.ParentChild.Remove(joinEntry);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}