
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;




namespace WebAddressbookTests

{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    {
        [Test]
        public void GroupRemovalTest()
        {
            if (!IsElementPresent(By.XPath("(//input[@name='selected[]")))
            {
                // проба добавить тест если контакт отсутствует
                GroupData group = new GroupData("zzz");
                app.Groups.Create(group);

            }
            app.Groups
            .GoToGroupsPage()
            .SelectGroup(1)
            .Remove()
            .ReturnToGroupPage();
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
