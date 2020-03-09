using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BosaAPI.Teste.Test.Controllers
{
    public abstract class ControllerDefaultBaseTest
        <TController>
    {
        protected HubDbContext DbContext { get; private set; }

        protected TController Controller { get; set; }

        private const string CONN_STR = "Server=easycarros-hub-prod.cn6dkzezsndb.sa-east-1.rds.amazonaws.com;database=HUB-DEV; User ID=UHUB-DEV; password=ZWX250lNpQ;";
        
        [SetUp]
        public virtual void Setup()
        {
            var options = new DbContextOptionsBuilder<HubDbContext>();

            options.UseSqlServer(CONN_STR);

            DbContext = new HubDbContext(options.Options);
        }
    }
}
