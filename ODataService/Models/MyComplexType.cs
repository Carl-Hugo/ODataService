namespace ODataService.Models
{
    using System.Collections.Generic;

    public class MyComplexType
    {
        public string Description { get; set; }
        public ICollection<MyComplexType> Children { get; set; }
    }
}