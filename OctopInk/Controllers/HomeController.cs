using OctopInk.Models;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;

namespace OctopInk.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private ModelDBContext db = new ModelDBContext();

        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View(db.Prodotti);
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string email, string psw)
        {
            using (var context = new ModelDBContext())
            {
                var user = context.Utenti.FirstOrDefault(u => u.Email == email && u.Psw == psw);
                if (user != null)
                {
                    FormsAuthentication.SetAuthCookie(email, false);
                    if (user.IsAdmin)
                    {
                        TempData["Login"] = "Benvenuto/a " + user.Nome + " " + user.Cognome + " [Admin]";
                        return RedirectToAction("Create", "Prodotti");
                    }
                    else
                    {
                        TempData["Login"] = "Benvenuto/a " + user.Nome + " " + user.Cognome;
                        return RedirectToAction("Index", "Prodotti");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Email o password errati");
                    return View();
                }
            }
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(Utenti utente)
        {
            if (ModelState.IsValid)
            {
                using (var context = new ModelDBContext())
                {
                    context.Utenti.Add(utente);
                    context.SaveChanges();
                }
                return RedirectToAction("Index", "Prodotti");
            }
            // Se il modello non è valido, torna alla vista di registrazione mostrando gli errori
            return View(utente);
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            TempData["LogoutMess"] = "Logout effettuato con successo";
            return RedirectToAction("Index");
        }
    }
}


