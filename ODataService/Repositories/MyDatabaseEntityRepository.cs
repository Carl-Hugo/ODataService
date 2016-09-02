using ODataService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ODataService.Repositories
{
    public class MyDatabaseEntityRepository : IMyDatabaseEntityRepository
    {
        #region Some dummy data

        private static List<MyDatabaseEntity> InternalDataStore;
        static MyDatabaseEntityRepository()
        {
            InternalDataStore = new List<MyDatabaseEntity>();
            for (int i = 0; i < 10; i++)
            {
                var id = i + 1;
                InternalDataStore.Add(CreateMyDatabaseEntity(id));
            }
        }

        private static MyDatabaseEntity CreateMyDatabaseEntity(int id)
        {
            var model = new MyDatabaseEntity
            {
                Id = id,
                Description = string.Format("MyODataModel {0}", id),
                Children = new List<MyDatabaseComplexType>()
            };
            FillComplexTypeCollection(model.Children, 2);
            return model;
        }

        private static void FillComplexTypeCollection(ICollection<MyDatabaseComplexType> parentCollection, int level)
        {
            if (level < 5)
            {
                for (int i = 0; i < (level % 2) + 1; i++)
                {
                    var complexType = new MyDatabaseComplexType
                    {
                        Description = $"MyDatabaseComplexType level={level} | i = {i}",
                        Children = new List<MyDatabaseComplexType>()
                    };
                    FillComplexTypeCollection(complexType.Children, level + 1);
                    parentCollection.Add(complexType);
                }
            }
        }

        #endregion

        public IEnumerable<MyDatabaseEntity> All()
        {
            return InternalDataStore;
        }

        public MyDatabaseEntity Find(int id)
        {
            return InternalDataStore.FirstOrDefault(x => x.Id == id);
        }
    }

    public interface IMyDatabaseEntityRepository
    {
        IEnumerable<MyDatabaseEntity> All();
        MyDatabaseEntity Find(int id);
    }
}