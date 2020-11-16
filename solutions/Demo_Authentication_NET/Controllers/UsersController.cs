using System;
using System.Collections.Generic;
using System.Linq;
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
        public UsersController()
        {
        }

    }
}