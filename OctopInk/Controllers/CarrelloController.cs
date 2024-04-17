using OctopInk.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace OctopInk.Controllers
{
    public class CarrelloController : Controller
    {
        public ActionResult Index()
        {
            var cart = Session["cart"] as List<Prodotti>;
            if (cart == null || !cart.Any())
            {
                TempData["CartMessage"] = "Il carrello è vuoto";
                return RedirectToAction("Index", "Prodotti");
            }
            return View(cart);
        }

        // Rimuove un prodotto dal carrello
        // Se la quantità del prodotto è maggiore di 1, decrementa la quantità
        public ActionResult Delete(int? id)
        {
            var cart = Session["cart"] as List<Prodotti>;
            if (cart != null)
            {
                var productToRemove = cart.FirstOrDefault(p => p.IdProdotto == id);
                if (productToRemove != null)
                {
                    if (productToRemove.Quantita > 1)
                    {
                        productToRemove.Quantita--;
                    }
                    else
                    {
                        cart.Remove(productToRemove);
                    }
                }
            }

            return RedirectToAction("Index");
        }

        // Svuota il carrello
        public ActionResult CartClear()
        {
            var cart = Session["cart"] as List<Prodotti>;
            if (cart != null)
            {
                cart.Clear();
            }
            TempData["CreateMess"] = "Il carrello è stato svuotato";
            return RedirectToAction("Index", "Prodotti");
        }
    }
}