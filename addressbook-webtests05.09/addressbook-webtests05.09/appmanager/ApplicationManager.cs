using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;


namespace WebAddressbookTests
{
    public class ApplicationManager
    {
        protected IWebDriver driver;
        private StringBuilder verificationErrors;
        protected string baseURL;

        protected LoginHelper loginHelper;
        protected NavigationHelper navigation;
        protected GroupHelper groupHelper;
        protected ContactHelper contactHelper;

        public ApplicationManager()
        {
            loginHelper = new LoginHelper(driver);
            navigation = new NavigationHelper(driver, baseURL);
            groupHelper = new GroupHelper(driver);
            contactHelper = new ContactHelper(driver);
        }
        public void Stop()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {



            }
        }

        public LoginHelper Auth
        {
            get
            {
                return loginHelper;
            }
        }

        public NavigationHelper Navigation
        {
            get
            {
                return navigation;
            }
        }
        public GroupHelper Groups
        {
            get
            {
                return groupHelper;
            }
        }
        public ContactHelper Contact
        {
            get
            {
                return contactHelper;
            }
        }
    }
}
