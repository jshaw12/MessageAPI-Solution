using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageAPI.Core
{
    public interface IMessageRepository
    {
        string GetMessage();
    }
}
