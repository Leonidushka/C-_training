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
        private bool acceptNextAlert = true;

        public ContactHelper(ApplicationManager manager) : base(manager)
        {

        }
        public ContactHelper OpenHomePage()
        {
            driver.Navigate().GoToUrl("http://localhost/addressbook");
            return this;
        }

        public ContactHelper FillingNewContact(ContactData contact)
        {
            driver.FindElement(By.Name("firstname")).Click();
            driver.FindElement(By.Name("firstname")).Clear();
            driver.FindElement(By.Name("firstname")).SendKeys(contact.Firstname);
            driver.FindElement(By.Name("lastname")).Clear();
            driver.FindElement(By.Name("lastname")).SendKeys(contact.Lastname);
            driver.FindElement(By.Name("theform")).Click();
            return this;
        }

        public ContactHelper SubmittingContactCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            return this;
        }
        /*
        public ContactHelper(int v, ContactData newData)
        {
            OpenHomePage();
            SelectContact(v);
            InitContactModification();
            FillGroupForm(newData);
            SubmitGroupModification();
            ReturnToGroupPage();
            return this;
        }
        */

        public ContactHelper SelectContact(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + index + "]")).Click();
            return this;

        }

        public ContactHelper Remove()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
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
            driver.FindElement(By.Name("Edit")).Click();
            return this;
        }
        
        public ContactHelper SubmitContactModification()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }
    }
}
