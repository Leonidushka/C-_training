
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Collections.Generic;




namespace WebAddressbookTests

{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    {
        [Test]
        public void GroupRemovalTest()
        {
            if (!app.Groups.IsElementPresent(app.Groups.IsGroupPresent))
            {
                // проба добавить тест если группа отсутствует
                GroupData group = new GroupData("zzz");
                app.Groups.Create(group);

            }

            List<GroupData> oldGroups = app.Groups.GetGroupList();


            app.Groups.Remove(0);

            List<GroupData> newGroups = app.Groups.GetGroupList();

            oldGroups.RemoveAt(0);
            Assert.AreEqual(oldGroups, newGroups);
        }

    }
}
