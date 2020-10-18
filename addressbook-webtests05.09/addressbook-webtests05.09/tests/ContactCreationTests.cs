using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;


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

            List<ContactData> oldContact = app.Contact.GetContactList();
            app.Contact.Create(contact);

            List<ContactData> newContact = app.Contact.GetContactList();
            oldContact.Add(contact);
            newContact.Sort();
            oldContact.Sort();

            Assert.AreEqual(oldContact.Count, newContact.Count);
        }
    }
}