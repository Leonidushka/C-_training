using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace WebAddressbookTests
{
    public class ContactHelper : HelperBase
    {

        public By IsContactPresent = By.ClassName("contact");
        public ContactHelper(ApplicationManager manager) : base(manager)
        {

        }


        public ContactHelper OpenHomePage()
        {
            driver.Navigate().GoToUrl("http://localhost/addressbook");
            return this;
        }

        public ContactHelper Create(ContactData contact)
        {
            OpenHomePage();
            InitContactCreation();
            FillContactForm(contact);
            SubmittingContactCreation();
            OpenHomePage();
            return this;
        }

        public ContactHelper InitContactCreation()
        {
            driver.FindElement(By.LinkText("add new")).Click();

            return this;
        }
        public ContactHelper SubmittingContactCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            contactCache = null;
            return this;
        }

        public ContactHelper Modify(int v, ContactData newData)
        {
            OpenHomePage();
            SelectContact(v);
            InitContactModification(0);
            FillContactForm(newData);
            SubmitContactModification();
            OpenHomePage();
            return this;
        }


        public ContactHelper Remove(int p)
        {

            OpenHomePage();
            SelectContact(p);
            RemoveContact();
            RemoveApproval();
            OpenHomePage();
            return this;
        }


        public ContactHelper SelectContact(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + (index + 1) + "]")).Click();
            return this;
        }

        public ContactHelper RemoveContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            contactCache = null;
            return this;
        }

        public ContactHelper RemoveApproval()
        {
            IAlert alert = driver.SwitchTo().Alert();
            alert.Accept();
            driver.FindElement(By.CssSelector("div.msgbox"));
            return this;
        }
        // Contact Modification
        public ContactHelper InitContactModification(int index)
        {
            driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"))[7]
                .FindElement(By.TagName("a")).Click();
            return this;
        }

        public ContactHelper FillContactForm(ContactData contact)
        {
            Type(By.Name("firstname"), contact.Firstname);
            Type(By.Name("lastname"), contact.Lastname);
            return this;
        }

        public ContactHelper SubmitContactModification()
        {
            driver.FindElement(By.Name("update")).Click();
            contactCache = null;
            return this;
        }

        private List<ContactData> contactCache = null;

        public List<ContactData> GetContactList()
        {
            if (contactCache == null)
            {
                contactCache = new List<ContactData>();
                OpenHomePage();
                ICollection<IWebElement> elements = driver.FindElements(By.Name("entry"));
                foreach (IWebElement element in elements)
                {
                    IList<IWebElement> windows = element.FindElements(By.TagName("td"));
                    contactCache.Add(new ContactData(windows[1].Text, windows[2].Text));
                }
            }
            return new List<ContactData>(contactCache);
        }
        public ContactData GetContactInformationFromTable(int index)
        {
            manager.Navigation.OpenHomePage();
            IList<IWebElement> windows = driver.FindElements(By.Name("entry"))[index].FindElements(By.TagName("td"));

            string lastname = windows[1].Text;
            string firstname = windows[2].Text;
            string address = windows[3].Text;
            string allPhones = windows[5].Text;
            string allEmails = windows[4].Text;

            return new ContactData(firstname, lastname)
            {
                Address = address,
                AllPhones = allPhones,
                AllEmails = allEmails,
            };
        }

        public ContactData GetContactInformationFromEditForm(int index)
        {
            manager.Navigation.OpenHomePage();
            InitContactModification(0);

            string firstname = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string lastname = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");

            string home = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobile = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string work = driver.FindElement(By.Name("work")).GetAttribute("value");

            string email = driver.FindElement(By.Name("email")).GetAttribute("value");
            string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");

            return new ContactData(firstname, lastname)
            {
                Address = address,
                HomePhone = home,
                MobilePhone = mobile,
                WorkPhone = work,
                Email = email,
                Email2 = email2,
                Email3 = email3
            };
        }

        public string GetInformationFromDetailPage(int index)
        {
            manager.Navigation.OpenHomePage();
            driver.FindElements(By.Name("entry"))[index].FindElements(By.TagName("td"))[6].FindElement(By.TagName("a")).Click();

            string smContact = driver.FindElement(By.Id("content")).Text;

            return smContact;
          
        }

        
    }
}
