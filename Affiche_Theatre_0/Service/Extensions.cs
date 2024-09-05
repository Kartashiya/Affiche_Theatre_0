using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Affiche_Theatre_0.Service
{
    public static class Extensions
    {
        //во входной строке HomeController вырезаем Controller
        public static string CutController(this string str)
        {
            return str.Replace("Controller", "");
        }
    }
}
