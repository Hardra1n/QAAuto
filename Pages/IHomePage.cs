using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pages
{
    public interface IHomePage
    {
        public IHomePage SendMessage(string mailToSend, string text);
    }
}
