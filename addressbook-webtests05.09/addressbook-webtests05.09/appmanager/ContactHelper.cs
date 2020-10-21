﻿using System;
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
            InitContactModification();
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
        public ContactHelper InitContactModification()
        {
            driver.FindElement(By.XPath("//img[@alt='Edit']")).Click();
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
    }
}
