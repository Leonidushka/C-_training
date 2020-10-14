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
    public class ContactModificationTests : AuthTestBase
    {
        [Test]
        public void ContactModificationTest()
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
            //
            ContactData newData = new ContactData("Mika", "Hakkinen");
            newData.Firstname = null;
            newData.Lastname = null;

            app.Contact.Modify(1, newData);
        }
    }
}
