using ODataService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ODataService.Services
{
    public class MyODataModelMapper : IMyODataModelMapper
    {
        public MyODataModel Map(MyDatabaseEntity entity)
        {
            return new MyODataModel
            {
                Id = entity.Id,
                Description = entity.Description,
                Children = MapChildren(entity)
            };
        }

        private ICollection<MyComplexType> MapChildren(MyDatabaseEntity entity)
        {
            return entity.Children.Select(dbComplexType => new MyComplexType
            {
                Description = dbComplexType.Description,
                Children = MapChildren(dbComplexType)
            }).ToList();
        }

        private ICollection<MyComplexType> MapChildren(MyDatabaseComplexType parent)
        {
            return parent.Children.Select(dbComplexType => new MyComplexType
            {
                Description = dbComplexType.Description,
                Children = MapChildren(dbComplexType)
            }).ToList();
        }
    }

    public interface IMyODataModelMapper
    {
        MyODataModel Map(MyDatabaseEntity entity);
    }
}