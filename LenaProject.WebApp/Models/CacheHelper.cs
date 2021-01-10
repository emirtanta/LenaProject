using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;

namespace LenaProject.WebApp.Models
{
    public class CacheHelper
    {
        

        public static void Remove(string key)
        {
            WebCache.Remove(key);
        }
    }
}