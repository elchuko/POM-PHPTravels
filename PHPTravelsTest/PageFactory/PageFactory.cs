using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PHPTravelsTest.Factory
{
    class PageFactory: AbsPageFactory
    {
        public string PageType;
        public override BasicPage GetPage(string PageType)
        {
            switch (PageType)
            {
                case "HomePage":
                    return new HomePage(driver);
                    break;

                case "LoginPage":
                    return new LoginPage(driver);
                    break;
            }

            return null;

        }
    }
}
