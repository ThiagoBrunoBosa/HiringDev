namespace BosaApi.Teste.Controllers.Templates
{
    public abstract class ControllerServiceBase<TService>
        : ControllerDefaultBase
    {
        protected TService RepositoryService { get; private set; }

        public ControllerServiceBase
            (TService service)
            : base()
        {
            RepositoryService = service;
        }
    }
}
