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

        private ICollection<MyComplexType1> MapChildren(MyDatabaseEntity entity)
        {
            return entity.Children.Select(dbComplexType => new MyComplexType1
            {
                Description = dbComplexType.Description,
                Children = MapChildren2(dbComplexType)
            }).ToList();
        }

        private ICollection<MyComplexType1> MapChildren1(MyDatabaseComplexType parent)
        {
            return parent.Children.Select(dbComplexType => new MyComplexType1
            {
                Description = dbComplexType.Description,
                Children = MapChildren2(dbComplexType)
            }).ToList();
        }

        private ICollection<MyComplexType2> MapChildren2(MyDatabaseComplexType parent)
        {
            return parent.Children.Select(dbComplexType => new MyComplexType2
            {
                Description = dbComplexType.Description,
                Children = MapChildren1(dbComplexType)
            }).ToList();
        }
    }

    public interface IMyODataModelMapper
    {
        MyODataModel Map(MyDatabaseEntity entity);
    }
}