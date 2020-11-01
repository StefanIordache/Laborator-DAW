using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Laboratorul_2.Controllers
{
    public class Laborator2Controller : Controller
    {

        // GET: /laborator2/exercitiul1/?word1=ceva&word2=altceva
        public ActionResult Exercitiul1(string word1, string word2)
        {
            // Tratam orice exceptie prin utilizarea blocului try-catch
            try
            {
                word1 = word1.ToLower();
                word2 = word2.ToLower();

                // Plasam in ViewData (sau ViewBag) mesajul pentru utilizator
                ViewData["message"] = word1.Contains(word2) || word2.Contains(word1);
            }
            // Exceptia aceasta este tratata in cel mai general mod posibil
            catch (Exception e)
            {
                ViewData["error"] = e.Message;
            }

            return View();
        }


        // GET: /laborator2/exercitiul2/?word1=ceva&word2=altceva
        // Optionalitatea celui de al doilea parametru este data in mod implicit de tipul de date string
        // Pentru variabile de tip int, float, DateTime, etc. se poate utiliza sintaxa "int? numar"
        public ActionResult Exercitiul2(string word1, string word2)
        {
            // Returnam un mesaj utilizatorului, in acest caz folosind o eroare predefinita: 404
            if (word2 == null)
            {
                return HttpNotFound("Al doilea parametru lipseste");
            }

            try
            {
                word1 = word1.ToLower();
                word2 = word2.ToLower();

                ViewData["message"] = word1.Contains(word2) || word2.Contains(word1);
            }
            catch (Exception e)
            {
                ViewData["error"] = e.Message;
            }

            return View();
        }


        // GET: /laborator2/exercitiul3/100
        public ActionResult Exercitiul3(int numar)
        {
            return View();
        }


        // GET: /laborator2/exercitiul4farapartialview/?numere=7&numere=3&numere=14
        public ActionResult Exercitiul4FaraPartialView(List<int> numere)
        {
            try
            {
                ViewData["numere"] = numere;
            }
            catch (Exception e)
            {
                // Putem returna direct un cod HTTP
                return new HttpStatusCodeResult(500);
            }

            return View();
        }

        // GET: /laborator2/exercitiul4/?numere=7&numere=3&numere=14
        public ActionResult Exercitiul4(List<int> numere)
        {
            try
            {
                ViewData["numere"] = numere;
            }
            catch (Exception e)
            {
                // Putem returna direct un cod HTTP
                return new HttpStatusCodeResult(500);
            }

            return View();
        }

    }
}