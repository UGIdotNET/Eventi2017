using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Backend.AspNetMvc
{
    public static class UrlBuilder
    {
        public static string ContentPage(string id, string prefix, string slug)
        {
            return $"{prefix}/{id}/{slug}";
        }
    }
}