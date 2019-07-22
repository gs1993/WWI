using CSharpFunctionalExtensions;

namespace Domain.Services.ConnectionStrings
{
    public interface IWwiConnectionStringService
    {
        string ConnectionStirng { get; }

        Result TestConnecion();
    }
}