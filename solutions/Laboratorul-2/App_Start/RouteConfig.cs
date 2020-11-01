using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Laboratorul_2
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // Constrangerea de la exercitiul 3 poate fi aplicata in acest configurator
            // ATENTIE LA PLASARE! Constrangerile se executa in mod cascada, de sus in jos
            routes.MapRoute(
                name: "exercitiul3-regex",
                url: "laborator2/exercitiul3/{numar}",
                defaults: new { controller = "Laborator2", action = "Exercitiul3", numar = UrlParameter.Optional},
                /*
                 * Constrangerea functioneaza astfel:
                 * ^ - marcheaza inceputul cuvantului
                 * [1-9] - specificam conditia de inceput pentru orice numar: un caracter cuprins intre 1 i 9 (cifra diferita de 0)
                 * \d - orice digit (sintaxa echivalenta cu [0-9])
                 * {1,5} - specificam numarul de caractere de tipului ultimului token scris (in cazul nostru \d)
                 * [02468] - conditia de terminare a unui numar par, specificata printr-o lista de caractere
                 * $ - final de sir/string/linie
                 */
                constraints: new { numar = @"^[1-9]\d{1,5}[02468]$"}
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
