using Domain.Models;

namespace Domain.Services
{
    public class ServiceBase : IServiceBase
    {
        protected WideWorldImportersEntities Context;

        public ServiceBase(WideWorldImportersEntities db)
        {
            Context = db;
        }
    }
}
