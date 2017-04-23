using System.Web.Http;
using MessageAPI.Models;
using MessageAPI.Core;
using Microsoft.Practices.Unity;
using MessageAPI.Repositories;

namespace MessageAPI.Controllers
{
    public class MessageController : ApiController
    {
        [Dependency]
        public IConfigurationFacade ConfigurationFacade
        {
            get;
            set;
        }

        public string GetMessage()
        {
            if (ConfigurationFacade == null)
            {
                ConfigurationFacade = new Facade.ConfigurationFacade();
            }

            var messageSource = ConfigurationFacade.GetMessageSource();
            IMessageRepository messageRepository = null;

            switch (messageSource)
            {
                case Enums.MessageSources.AppSetting:
                    messageRepository = new AppSettingMessageRepository();
                    break;
                case Enums.MessageSources.SQLServer:
                    messageRepository = new SQLMessageRepository(); 
                    break;
                case Enums.MessageSources.Twitter:
                    //ToDo
                    break;
                case Enums.MessageSources.Facebook:
                    //ToDo
                    break;
            }

            var message = messageRepository.GetMessage();
            LoggingHelper.LogRequest(messageSource.ToString(), message);
            return message;
        }
    }
}
