using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CrudApp2.Models
{
    public class EmpModel
    {
       
        public int id { get; set;  }
       
        public string name { get; set; }
        public string email { get; set; }
        public string city { get; set; }
        public int salary { get; set; }
    }
}