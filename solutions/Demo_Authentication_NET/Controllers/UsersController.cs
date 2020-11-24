using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Demo_Authentication_NET.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;

namespace Demo_Authentication_NET.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class UsersController : Controller
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();

        public UsersController()
        {
        }

        // GET: users/index
        public ActionResult Index()
        {
            var users = _context.Users.OrderBy(x => x.Email).ToList();

            ViewBag.Users = users;

            return View();
        }

        // GET: users/details/{id}
        public ActionResult Details(string id)
        {
            if (!String.IsNullOrEmpty(id))
            {
                ApplicationUser user = _context.Users
                    .Include(x => x.Roles)
                    .FirstOrDefault(x => x.Id.Equals(id));

                if (user == null)
                {
                    return HttpNotFound();
                }

                var roleName = _context.Roles.Find(user.Roles.First().RoleId).Name;

                ViewBag.RoleName = roleName;

                return View(user);
            }

            return HttpNotFound();
        }

        // GET: users/edit/{id}
        public ActionResult Edit(string id)
        {
            if (String.IsNullOrEmpty(id))
            {
                return HttpNotFound();
            }

            UserViewModel model = new UserViewModel();

            var user = _context.Users.Find(id);

            if (user == null)
            {
                return HttpNotFound();
            }

            model.User = user;
            model.RoleName = _context.Roles.Find(user.Roles.First().RoleId).Name;

            return View(model);
        }

        // POST: users/edit
        [HttpPost]
        public ActionResult Edit(string id, UserViewModel model)
        {
            ApplicationUser user = _context.Users.Find(id);

            if (user == null)
            {
                return HttpNotFound();
            }

            try
            {
                var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(_context));

                if (TryUpdateModel(user))
                {
                    var roles = _context.Roles.ToList();

                    foreach (var role in roles)
                    {
                        userManager.RemoveFromRole(user.Id, role.Name);
                    }

                    userManager.AddToRole(user.Id, model.RoleName);

                    _context.SaveChanges();

                    return RedirectToAction("Index");
                }
            }
            catch (Exception e)
            {
                return Json(new {error = e.Message}, JsonRequestBehavior.AllowGet);
            }

            return View(model);
        }

    }
}