using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locators
{
    public static class BBCAllSportsCSSSelector
    {
        public static string GetSearchInput() => "input#orb-search-q";

        public static string GetHomePageLink() => "a#homepage-link";

        public static string GetProfilePageLink() => "a#idcta-link";

        public static string GetAllSportsButton() => "button#sp-nav-all-sport-button";

        public static string GetOrbNavLinks() => "div#orb-nav-links li>a";

        public static string GetSportNavLinks() => "[role=menubar] li a";

        public static string GetLastNewsTime() => "ul.gs-u-mt- >li time";

        public static string GetSportsTypeLinks() => "a[class = 'sp-c-sport-flyout__link qa-flyout-atoz-item sp-nav-click-stat']";
    }
}
