using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using MessageAPI.Core;

namespace MessageAPI.Repositories
{
    public class AppSettingMessageRepository : IMessageRepository
    {
        public string GetMessage()
        {
            var message = ConfigurationManager.AppSettings["Message"].ToString();
            return message;
        }
    }
}