using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ADO_MVC_DEMO1.Models
{
    public class Department
    {
       
        public int Id { get; set; }
        public String Name { get; set; }
        public string Location { get; set; }

    }
}