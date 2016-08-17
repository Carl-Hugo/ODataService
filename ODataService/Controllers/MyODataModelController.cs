using ODataService.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.OData;

namespace ODataService.Controllers
{
    public class MyODataModelController : ODataController
    {
        #region Some dummy data

        private static List<MyODataModel> InternalDataStore;
        static MyODataModelController()
        {
            InternalDataStore = new List<MyODataModel>();
            for (int i = 0; i < 10; i++)
            {
                var id = i + 1;
                InternalDataStore.Add(new MyODataModel
                {
                    Id = id,
                    Description = string.Format("MyODataModel {0}", id)
                });
            }
        }

        #endregion

        [EnableQuery]
        public virtual IHttpActionResult Get()
        {
            return Ok(InternalDataStore);
        }

        [EnableQuery]
        public virtual IHttpActionResult Get([FromODataUri] int key)
        {
            var record = InternalDataStore.FirstOrDefault(r => r.Id == key);
            if (record == null)
            {
                return NotFound();
            }
            return Ok(record);
        }
    }
}