﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactRemovalTests : TestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
            app.Contact
            .OpenHomePageForContacts()
            .SelectContact(14)
            .Remove()
            .OpenHomePageForContacts();
        }
    }
}
