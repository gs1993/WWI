using Domain.Models;

namespace Domain.Services
{
    public class ServiceBase
    {
        protected WideWorldImportersEntities Context;

        public ServiceBase(WideWorldImportersEntities db)
        {
            Context = db;
        }
    }
}
