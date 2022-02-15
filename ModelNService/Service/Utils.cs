using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelNService.Service
{
    public static class Utils
    {
        public static bool AreEqual(this object masterObject, params object[] objects)
        {
            foreach (var obj in objects)
            {
                if (masterObject.Equals(obj))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
