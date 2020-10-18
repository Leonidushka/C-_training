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
    public class GroupModificationTests : AuthTestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            if (!app.Groups.IsElementPresent(app.Groups.IsGroupPresent))
            {
                // проба добавить тест если контакт отсутствует
                GroupData group = new GroupData("zzz");
                app.Groups.Create(group);

            }

            GroupData newData = new GroupData("zzz");
                 newData.Header = null;
                 newData.Footer = null;

            app.Groups.Modify(0, newData);
        }
    }
}

