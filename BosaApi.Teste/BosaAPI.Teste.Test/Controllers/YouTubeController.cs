using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using BosaAPI.Teste.Test.Controllers;
using BosaApi.Teste.Models;

namespace BosaApi.Teste.Controllers
{
    [TestFixture]
    public class YouTubeControllerTest : ControllerServiceBaseTest
        <YouTubeRepository, YouTubesService, YouTubeController>
    {
        [SetUp]
        public override void Setup()
        {
            base.Setup();

            Repository = new YouTubeRepository(DbContext);

            Service = new YouTubesService(Repository, AppSettings);

            Controller = new YouTubeController(Service);
        }

        [Test]
        public async Task GetAll()
        {
            // Arrange

            // Act

            var actionResult = await Controller.GetAll();

            // Assert

            Assert.IsInstanceOf<OkObjectResult>(actionResult);

            var okObjectResult = (OkObjectResult)actionResult;

            var value = okObjectResult.Value;

            Assert.IsInstanceOf<IEnumerable<YouTubeResponse>>(value);

            var response = (IEnumerable<YouTubeResponse>)value;

            Assert.IsNotEmpty(response);
        }

        [Test]
        public async Task GetItem_NotFound()
        {
            // Arrange

            var id = 0;

            // Act

            var actionResult = await Controller.GetItem(id);

            // Assert

            Assert.IsInstanceOf<NotFoundResult>(actionResult);
        }

        [Test]
        public async Task Post()
        {
            // Arrange

            var request = new YouTubePostRequest
            {
                Initials = $"Tst{ DateTime.Now.Day }{ DateTime.Now.Minute }{ DateTime.Now.Second }",
                Name = "YouTube C",
            };

            // Act

            var actionResult = await Controller.Post(request);

            // Assert

            Assert.IsInstanceOf<OkObjectResult>(actionResult);

            var okObjectResult = (OkObjectResult)actionResult;

            var value = okObjectResult.Value;

            Assert.IsInstanceOf<YouTubeResponse>(value);

            var response = (YouTubeResponse)value;

            Assert.Greater(response.Id, 0);

            Assert.AreEqual(request.Name, response.Name);
        }

        [Test]
        public async Task Post_BadRequest()
        {
            // Arrange

            // Act

            var actionResult = await Controller.Post(null);

            // Assert

            Assert.IsInstanceOf<BadRequestResult>(actionResult);
        }

        [Test]
        public async Task Put()
        {
            // Arrange

            var request = new YouTubePutRequest
            {
                Initials = $"Tst{DateTime.Now.Day}{DateTime.Now.Minute}{DateTime.Now.Second}",
                Name = "YouTube C",

            };

            // Act

            var actionResult = await Controller.Put(5, request);

            // Assert

            Assert.IsInstanceOf<OkObjectResult>(actionResult);

            var okObjectResult = (OkObjectResult)actionResult;

            var value = okObjectResult.Value;

            Assert.IsInstanceOf<YouTubeResponse>(value);

            var response = (YouTubeResponse)value;

            Assert.Greater(response.Id, 0);

            Assert.AreEqual(request.Name, response.Name);

            // Arrange

            var id = response.Id;

            request.Name = "YouTube B+";

            // Act

            actionResult = await Controller.Put(id, request);

            // Assert

            Assert.IsInstanceOf<OkObjectResult>(actionResult);

            okObjectResult = (OkObjectResult)actionResult;

            value = okObjectResult.Value;

            Assert.IsInstanceOf<YouTubeResponse>(value);

            response = (YouTubeResponse)value;

            Assert.AreEqual(id, response.Id);

            // Assert - Compare

            Assert.AreEqual(request.Name, response.Name);
        }

        [Test]
        public async Task Put_EntityVersion()
        {
            // Arrange

            var request = new YouTubePutRequest
            {
                Initials = $"Tst{DateTime.Now.Day}{DateTime.Now.Minute}{DateTime.Now.Second}",
                Name = "YouTube C"
            };

            // Act

            var actionResult = await Controller.Put(5, request);

            // Assert

            Assert.IsInstanceOf<OkObjectResult>(actionResult);

            var okObjectResult = (OkObjectResult)actionResult;

            var value = okObjectResult.Value;

            Assert.IsInstanceOf<YouTubeResponse>(value);

            var response = (YouTubeResponse)value;

            Assert.Greater(response.Id, 0);

            Assert.AreEqual(request.Name, response.Name);

            // Arrange

            var id = response.Id;

            request.Name = "YouTube B+";

            request.EntityVersion = response.EntityVersion;

            // Act

            actionResult = await Controller.Put(id, request);

            // Assert

            Assert.IsInstanceOf<OkObjectResult>(actionResult);

            okObjectResult = (OkObjectResult)actionResult;

            value = okObjectResult.Value;

            Assert.IsInstanceOf<YouTubeResponse>(value);

            response = (YouTubeResponse)value;

            Assert.AreEqual(id, response.Id);

            // Assert - Compare

            Assert.AreEqual(request.Name, response.Name);
        }

        [Test]
        public async Task Put_EntityVersion_Conflict()
        {
            // Arrange

            var request = new YouTubePutRequest
            {
                Initials = $"Tst{DateTime.Now.Day}{DateTime.Now.Minute}{DateTime.Now.Second}",
                Name = "YouTube C",
            };

            // Act

            var actionResult = await Controller.Put(1, request);

            // Assert

            Assert.IsInstanceOf<OkObjectResult>(actionResult);

            var okObjectResult = (OkObjectResult)actionResult;

            var value = okObjectResult.Value;

            Assert.IsInstanceOf<YouTubeResponse>(value);

            var response = (YouTubeResponse)value;

            Assert.Greater(response.Id, 0);

            Assert.AreEqual(request.Name, response.Name);

            // Arrange

            var id = response.Id;

            request.Name = "YouTube B+";

            request.EntityVersion = response.EntityVersion.Value.AddDays(-1);

            // Act

            actionResult = await Controller.Put(id, request);

            // Assert

            Assert.IsInstanceOf<ConflictObjectResult>(actionResult);

            var conflictObjectResult = (ConflictObjectResult)actionResult;

            value = conflictObjectResult.Value;

            Assert.IsInstanceOf<StateResponse>(value);

            var stateResponse = (StateResponse)value;

            Assert.IsNotEmpty(stateResponse);

            Assert.IsTrue(stateResponse.ContainsKey("EntityVersion"));

            Assert.AreEqual(Messages3.EntityVersion_Conflict, stateResponse["EntityVersion"]);
        }

        [Test]
        public async Task Put_NotFound()
        {
            // Arrange

            var id = 0;

            var request = new YouTubePutRequest
            {
                Initials = "ENC",
                Name = "YouTube C",
            };

            // Act

            var actionResult = await Controller.Put(id, request);

            // Assert

            Assert.IsInstanceOf<NotFoundResult>(actionResult);
        }

        [Test]
        public async Task Put_BadRequest()
        {
            // Arrange

            var id = 0;

            // Act

            var actionResult = await Controller.Put(id, null);

            // Assert

            Assert.IsInstanceOf<BadRequestResult>(actionResult);
        }
    }
}
