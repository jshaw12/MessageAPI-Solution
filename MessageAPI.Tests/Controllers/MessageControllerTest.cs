using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MessageAPI.Controllers;
using System.Configuration;
using MessageAPI.Facade;

namespace MessageApi.Tests
{
    [TestClass]
    public class MessageControllerTests
    {
        [TestMethod]
        [ExpectedException(typeof(ConfigurationErrorsException))]
        public void MessageControllerExceptionTest()
        {
            var messageController = new MessageController();
            messageController.ConfigurationFacade = new ConfigurationFacade();

            messageController.GetMessage();
        }
    }
}
