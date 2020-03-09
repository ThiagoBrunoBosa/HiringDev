using BosaApi.Teste.Useful;

namespace BosaApi.Teste.Models.Templates
{
    public abstract class Service<TRepository>
    {
        protected TRepository Repository { get; private set; }

        protected AppSettings AppSettings { get; private set; }

        protected StateResponse State { get; private set; }
            = new StateResponse();

        public Service(TRepository repository, AppSettings appSettings)
        {
            Repository = repository;
            AppSettings = appSettings;
        }
    }
}
