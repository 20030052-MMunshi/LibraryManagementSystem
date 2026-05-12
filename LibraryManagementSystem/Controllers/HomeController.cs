using LibraryManagementSystem.Data;
using LibraryManagementSystem.Models;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;

namespace LibraryManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        private LibraryManagementSystemContext db = new LibraryManagementSystemContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Library Management System description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Library Management System contact page.";
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Login");
            }

            return View(user);
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            var existingUser = db.Users
                .FirstOrDefault(u => u.UserName == user.UserName && u.Password == user.Password);

            if (existingUser != null)
            {
                FormsAuthentication.SetAuthCookie(existingUser.UserName, false);
                Session["UserName"] = existingUser.UserName;
                Session["Role"] = existingUser.Role;

                return RedirectToAction("Index", "Home");
            }

            ViewBag.Error = "Invalid username or password";
            return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Clear();

            return RedirectToAction("Login");
        }
    }
}