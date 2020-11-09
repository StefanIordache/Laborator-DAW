using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Microsoft.SqlServer.Server;

namespace Demo_MVC_CRUD.CustomValidations
{
    public class OnlyGmail : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            string email = value.ToString();

            return email.ToLower().Contains("@gmail.com");
        }
    }
}