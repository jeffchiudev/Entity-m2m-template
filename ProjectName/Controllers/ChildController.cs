using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;
using System.Security.Claims;
using System.Collections.Generic;
using System.Linq;
using ProjectName.Models;

namespace ProjectName.Controllers
{
    [Authorize]
    public class ChildsController : Controller
    {
        private readonly ProjectNameContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public ChildsController(UserManager<ApplicationUser> userManager, ProjectNameContext db)
        {
            _userManager = userManager;
            _db = db;
        }

        public async Task<ActionResult> Index()
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var currentUser = await _userManager.FindByIdAsync(userId);
            var userChilds = _db.Childs.Where(entry => entry.User.Id == currentUser.Id).ToList();
            return View(userChilds);
        }

        public ActionResult Create()
        {
            ViewBag.ParentId = new SelectList(_db.Parents, "ParentId", "ParentName");
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(Child child, int ParentId)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var currentUser = await _userManager.FindByIdAsync(userId);
            child.User = currentUser;
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