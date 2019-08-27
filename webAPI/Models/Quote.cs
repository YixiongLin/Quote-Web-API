using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webAPI.Models
{
    public class Quote
    {
        public int ID { get; set; }
        public string QuoteNum { get; set; }
        public string Company { get; set; }
        public double Price { get; set; }
        public System.DateTime ExpireDate { get; set; }
        public string Description { get; set; }

        public Quote() { }
    }
}