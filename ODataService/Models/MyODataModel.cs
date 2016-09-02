namespace ODataService.Models
{
    using System.Collections.Generic;

    public class MyODataModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public ICollection<MyComplexType1> Children { get; set; }
    }
}