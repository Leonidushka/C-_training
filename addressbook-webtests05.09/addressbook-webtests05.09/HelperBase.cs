﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace WebAddressbookTests
{
    public class HelperBase
    {
        protected IWebDriver driver;


        public HelperBase(IWebDriver driver)
        {
            this.driver = driver;
        }
    }
}