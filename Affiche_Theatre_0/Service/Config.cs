using System;

namespace Affiche_Theatre_0.Service
{
    public class Config
    {
        //cвойства соответствуют appsettings.json
        public static string ConnectionString { get; set; }     //строка подключения
        public static string CompanyName { get; set; }          //название компании
        public static string CompanyPhone { get; set; }         //телефон
        public static string CompanyEmail { get; set; }         //электронный адрес
    }
}
