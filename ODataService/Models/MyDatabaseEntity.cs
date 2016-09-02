namespace ODataService.Models
{
    using System.Collections.Generic;

    public class MyDatabaseEntity
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public ICollection<MyDatabaseComplexType> Children { get; set; }
    }
}