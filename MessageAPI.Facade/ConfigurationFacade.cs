using MessageAPI.Core;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageAPI.Facade
{
    public class ConfigurationFacade : IConfigurationFacade
    {
        public Enums.MessageSources GetMessageSource()
        {
            Object messageSourceObj = ConfigurationManager.AppSettings["MessageSource"];

            if (messageSourceObj == null)
            {
                throw new ConfigurationErrorsException("Unable to retreive MessageSource from Web.config.");
            }

            var messageSource = messageSourceObj.ToString();

            if (!string.IsNullOrEmpty(messageSource))
            {
                messageSource = messageSource.ToLower();
            }

            Enums.MessageSources result;

            switch (messageSource)
            {
                case "appsetting":
                    result = Enums.MessageSources.AppSetting;
                    break;
                case "sql-server":
                    result = Enums.MessageSources.SQLServer;
                    break;
                case "twitter":
                    result = Enums.MessageSources.Twitter;
                    break;
                case "facebook":
                    result = Enums.MessageSources.Facebook;
                    break;
                default:
                    throw new ConfigurationErrorsException("Unknow MessageSource of type '" + messageSource + "' specified in Web.config.");
            }

            return result;
        }
    }
}
