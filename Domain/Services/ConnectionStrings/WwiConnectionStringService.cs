using CSharpFunctionalExtensions;

namespace Domain.Services.ConnectionStrings
{
    public class WwiConnectionStringService : IWwiConnectionStringService
    {
        public string ConnectionStirng
        {
            get => System.Configuration.ConfigurationManager
                .ConnectionStrings["WWImportersEntities"]
                .ConnectionString;
        }

        public Result TestConnecion()
        {
            return Result.Ok();
        }
    }
}
