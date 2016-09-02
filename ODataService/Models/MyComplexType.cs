namespace ODataService.Models
{
    using System.Collections.Generic;

    public class MyComplexType1
    {
        public string Description { get; set; }
        public ICollection<MyComplexType2> Children { get; set; }
    }

    public class MyComplexType2
    {
        public string Description { get; set; }
        public ICollection<MyComplexType1> Children { get; set; }
    }
}