using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using addressbook_webtests05._09;
using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests : AuthTestBase
    {
        [Test]
        public void GroupCreationTest()
        {
            app.Navigation.GoToGroupsPage();
            GroupData group = new GroupData("aaa");
            group.Header = "ddd";
            group.Footer = "fff";
            app.Groups.Create(group);
        }

        public void EmptyGroupCreationTest()
        {
            GroupData group = new GroupData("");
            group.Header = "";
            group.Footer = "";

            app.Navigation.GoToGroupsPage();
            app.Groups.Create(group);
        }
    }
}
