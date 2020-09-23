using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : TestBase
    {

        [Test]
        public void ContactCreationTest()
        {
            OpenHomePageForContacts();
            Login(new AccountData("admin", "secret"));
            ContactData contact = new ContactData("Leonid", "Kazakov");
            contact.Firstname = "Leonid";
            contact.Lastname = "Kazakov";
            FillingNewContact(contact);
            SubmittingContactCreation();
            Logout();
        }
    }
}