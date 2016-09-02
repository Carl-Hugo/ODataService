using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ODataService.Models
{
    public class MyDatabaseComplexType
    {
        public string Description { get; set; }
        public ICollection<MyDatabaseComplexType> Children { get; set; }
    }
}