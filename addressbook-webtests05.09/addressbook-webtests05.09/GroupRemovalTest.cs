
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;



namespace WebAddressbookTests

{
    [TestFixture]
    public class GroupRemovalTests : TestBase
    {
        [Test]
        public void GroupRemovalTest()
        {
            navigation.OpenHomePage();
            loginHelper.Login(new AccountData("admin","secret"));
            groupHelper.GoToGroupsPage();
            groupHelper.SelectGroup(1);
            groupHelper.Remove();
            groupHelper.ReturnToGroupPage();
        }
    }
}
