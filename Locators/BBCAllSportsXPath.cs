using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locators
{
    public static class BBCAllSportsXPath
    {
        public static string GetSearchInput() => "//input[@id=\"orb-search-q\"]";

        public static string GetHomePageLink() => "//a[@id=\"homepage-link\"]";

        public static string GetProfilePageLink() => "//a[@id=\"idcta-link\"]";

        public static string GetAllSportsButton() => "//button[@id=\"sp-nav-all-sport-button\"]";

        public static string GetOrbNavLinks()
            => "//div[@class=\"orb-nav-section orb-nav-links orb-nav-focus\"]/ul/li[position()<last()]";

        public static string GetSportNavLinks() 
            => "//ul[@class=\"sp-c-sport-navigation__inner gs-o-list-inline\"]/*/a";

        public static string GetLastNewsTime() 
            => "//div[@class=\"gel-layout gel-layout--equal gs-u-mt gs-u-mt+@s sp-qa-top-stories\"]//time";

        public static string GetSportsTypeLinks() 
            => "//ul[@class=\"sp-c-sport-flyout__inner sp-c-sport-flyout__inner--border gs-u-pv+@m gs-u-mb+\"]" +
            "//li[@class=\"sp-c-sport-flyout__item\"]//a";

    }
}
