using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Application.Security.Passwordhelper.Interfaces
{
    public interface IPasswordHelper
    {
        string EncodePasswordMd5(string password);

    }
}
