using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;


namespace WebAddressbookTests
{ 
    public class NavigationHelper : HelperBase
    {
        
        private string baseURL;

        public NavigationHelper(IWebDriver driver, string baseURL) 
            : base(driver) 
        {
           
            this.baseURL = baseURL;
        }

        public void OpenHomePage()
        {

            driver.Navigate().GoToUrl(baseURL);
        }

        // Ни в какую тест не хочет добавлять через "Add New" для контактов, пришлось сделать стартовой форму на создание контакта
        public void OpenHomePageForContacts()
        {
            driver.Navigate().GoToUrl("http://localhost/addressbook/edit.php");
        }



        public void GoToGroupsPage()
        {

            driver.FindElement(By.LinkText("groups")).Click();
        }
    }
}
