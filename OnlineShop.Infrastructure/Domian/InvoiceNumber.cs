using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Infrastructure.Domian
{
    public class InvoiceNumber
    {
        public InvoiceNumber()
        {
            Number = year + month + day + hour + minutes;
        }

        public string Number { get; set; }

        string year = DateTime.Now.Year.ToString().Substring(2);
        string month = DateTime.Now.Month.ToString();
        string day = DateTime.Now.Day.ToString();
        string hour = DateTime.Now.Hour.ToString();
        string minutes = DateTime.Now.Minute.ToString();
    }
}
