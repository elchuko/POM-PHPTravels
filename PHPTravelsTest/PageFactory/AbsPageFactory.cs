using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PHPTravelsTest.Factory
{
    public abstract class AbsPageFactory
    {
        public abstract BasicPage GetPage(string pageType);
    }
}
