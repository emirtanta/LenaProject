using LenaProject.Common;
using LenaProject.Entities;
using LenaProject.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LenaProject.WebApp.Init
{
    public class WebCommon : ICommon
    {
        public string GetCurrentUsername()
        {
            LenaUser user = CurrentSession.User;

            if (user != null)
                return user.Username;
            else
                return "system";
        }
    }
}