using ODataService.Models;
using ODataService.Repositories;
using ODataService.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.OData;

namespace ODataService.Controllers
{
    public class MyODataModelController : ODataController
    {
        private IMyODataModelService MyODataModelService { get; }

        // Delete this constructor and user dependency injection instead
        // For simplicity, i omitted any DI container, use the one you like :)
        public MyODataModelController()
            : this(new MyODataModelService(new MyDatabaseEntityRepository(), new MyODataModelMapper())) { }

        public MyODataModelController(IMyODataModelService myODataModelService)
        {
            if (myODataModelService == null) { throw new ArgumentNullException(nameof(myODataModelService)); }
            MyODataModelService = myODataModelService;
        }

        [EnableQuery]
        public virtual IHttpActionResult Get()
        {
            return Ok(MyODataModelService.All());
        }

        [EnableQuery]
        public virtual IHttpActionResult Get([FromODataUri] int key)
        {
            var record = MyODataModelService.Find(key);
            if (record == null)
            {
                return NotFound();
            }
            return Ok(record);
        }
    }
}