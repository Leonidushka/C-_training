using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;


namespace WebAddressbookTests
{
   public class TestBase
    {
        
        protected IWebDriver driver;
        protected string baseURL;
      
        protected ApplicationManager app;

        [SetUp]
        public void SetupTest()
        {
            driver = new FirefoxDriver();
            baseURL = "http://localhost/addressbook";
          
         
            app = new ApplicationManager();
            app.Navigation.OpenHomePage();

            // Для создания контактов(тест не хочет выполняться через Add New)
            app.Navigation.OpenHomePageForContacts();
            app.Auth.Login(new AccountData("admin", "secret"));
           
        }

        [TearDown]
        public void TeardownTest()
        {
            app.Stop();
        }
    }
}

