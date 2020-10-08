using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {

        [Test]
        public void ContactCreationTest()
        {
            app.Navigation.OpenHomePageForContacts();
            ContactData contact = new ContactData("Leonid", "Kazakov");
            contact.Firstname = "Leonid";
            contact.Lastname = "Kazakov";
            app.Contact
            .FillContactForm(contact)
            .SubmittingContactCreation();
            //
        }
    }
}