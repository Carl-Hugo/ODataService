using ODataService.Models;
using ODataService.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ODataService.Services
{
    public class MyODataModelService : IMyODataModelService
    {
        private IMyDatabaseEntityRepository MyDatabaseEntityRepository { get; }
        private IMyODataModelMapper MyODataModelMapper { get; }

        public MyODataModelService(IMyDatabaseEntityRepository myDatabaseEntityRepository, IMyODataModelMapper myODataModelMapper)
        {
            if (myDatabaseEntityRepository == null) { throw new ArgumentNullException(nameof(myDatabaseEntityRepository)); }
            if (myODataModelMapper == null) { throw new ArgumentNullException(nameof(myODataModelMapper)); }

            MyDatabaseEntityRepository = myDatabaseEntityRepository;
            MyODataModelMapper = myODataModelMapper;
        }

        public IEnumerable<MyODataModel> All()
        {
            return MyDatabaseEntityRepository
                .All()
                .Select(dbModel => MyODataModelMapper.Map(dbModel));
        }

        public MyODataModel Find(int id)
        {
            var entity = MyDatabaseEntityRepository
                .All()
                .FirstOrDefault(x => x.Id == id);
            return MyODataModelMapper.Map(entity);
        }
    }

    public interface IMyODataModelService
    {
        IEnumerable<MyODataModel> All();
        MyODataModel Find(int id);
    }
}