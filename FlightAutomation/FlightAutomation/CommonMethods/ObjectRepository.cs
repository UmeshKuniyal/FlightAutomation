using System;
using System.Collections.Generic;
using System.Text;

namespace FlightAutomation.CommonMethods
{
    class ObjectRepository
    {
        public static string flightButton = @"//a[@data-name='flights']";
        public static string roundTripLabel = @"//label[@for='flightSearchRadio-1']";
        public static string toInputField = @"//input[@id='location_to_code']//preceding-sibling::input";
        public static string selectClass = @"//select[@name='cabinclass']";
        public static string selectClassByUL = @"//li[text()='First']/parent::ul";
        public static string spanEconomy = @"//span[text()='Economy']";
        public static string fromInputField = @"//input[@id='location_from']";
        public static string spanNYC = @"//span[text()='NYC']";
        public static string spanMIA = @"//div[@id='s2id_location_to']";
        public static string divDropMask = @"//div[@id='select2-drop-mask']";
        public static string divDehradun = @"//div[contains(text(),'Dehra Dun')]";
        public static string divDelhi = @"//div[contains(text(),'DEL')]";
        public static string divBangalore = @"//div[contains(text(),'Bangalore')]";
        public static string divLucknow = @"//div[contains(text(),'Lucknow')]";
        public static string divFlightsDateStart = @"//input[@id='FlightsDateStart']";
        public static string divFlightsDateEnd = @"//input[@id='FlightsDateEnd']";
        public static string buttonAdult = @"//div[@id='flights']/div/div/form/div/div[3]/div[3]/div/div/div[1]/div/div[2]/div/span/button[1]";
        public static string buttonChild = @"//div[@id='flights']/div/div/form/div/div[3]/div[3]/div/div/div[2]/div/div[2]/div/span/button[1]";
        public static string buttonInfant = @"//div[@id='flights']/div/div/form/div/div[3]/div[3]/div/div/div[3]/div/div[2]/div/span/button[1]";
        public static string buttonSearch = @"//div[@id='flights']/div/div/form/div/div[3]/div[4]/button";
        public static string listSearch = @"//ul[@id='LIST']//*";
        public static string dynamiclistItem = @"//body[@class='with-waypoint-sticky']";
        public static string businessClass = @"//li[text()='Business']";
        public static string date = DateTime.Today.Day.ToString();
        public static string fromDateXpath = String.Format(@"//div[@id='datepickers-container']/div[8]//div[text()='{0}']", date);
        public static string returnDateXpath = String.Format(@"//div[@id='datepickers-container']/div[9]//div[text()='{0}']", date);

    }
}
