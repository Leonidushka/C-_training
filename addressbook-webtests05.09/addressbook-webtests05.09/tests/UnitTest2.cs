using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace addressbook_webtests05._09.tests
{
   
    [TestClass]
    public class UnitTest2
    {
        #region Дополнительные атрибуты тестирования
        //
        // При написании тестов можно использовать следующие дополнительные атрибуты:
        //
        // ClassInitialize используется для выполнения кода до запуска первого теста в классе
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // ClassCleanup используется для выполнения кода после завершения работы всех тестов в классе
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // TestInitialize используется для выполнения кода перед запуском каждого теста 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // TestCleanup используется для выполнения кода после завершения каждого теста
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void TestMethod1()
        {
            double total = 1500;
            bool Vipclient = false;

            if (total > 1000 && Vipclient)
            {
                total = total * 0.9;
                System.Console.Out.Write("Скидка 10%, общая сумма" + total );
            }
            else
            {
                System.Console.Out.Write("Скидки нет, общая сумма" + total);
            }
        }
    }
}
