using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactRemovalTests : AuthTestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
            if (!app.Contact.IsElementPresent(app.Contact.IsContactPresent))
            {
                // проба добавить тест если контакт отсутствует
                ContactData contact = new ContactData("Mika", "Hakkinen");
                app.Contact
                    .InitContactCreation()
                    .FillContactForm(contact)
                    .SubmittingContactCreation();
            }
            app.Contact
            .OpenHomePage()
            .SelectContact(1)
            .Remove()
            .RemoveApproval()
            .OpenHomePage();
        }
        private bool IsElementPresent(By by)
        {
            try
            {
                app.Driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }

        }
    }
}
