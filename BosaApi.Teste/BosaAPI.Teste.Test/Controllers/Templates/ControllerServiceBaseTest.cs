using System;
using System.Collections.Generic;
using System.Text;

namespace BosaAPI.Teste.Test.Controllers
{
    public abstract class ControllerServiceBaseTest
        <TRepository, TService, TController>
        : ControllerDefaultBaseTest<TController>
    {
        protected TRepository Repository { get; set; }

        protected TService Service { get; set; }
    }
}
