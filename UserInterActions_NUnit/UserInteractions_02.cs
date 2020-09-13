using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.IO;
using System.Threading;

namespace UserInterActions_NUnit
{
    // Html-5
    
    [TestFixture]
    public class UserInteractions02
    {
        private FirefoxDriver _driver;
        private Actions _actions;
        private WebDriverWait _wait;

        [SetUp]
        public void Setup()
        {
            _driver = new FirefoxDriver();
            _actions = new Actions(_driver);
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(6));
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Close();
            _driver.Quit();
        }

        [Test]
        public void TestDragAndDrop_Html5()
        {

            _driver.Navigate().GoToUrl("http://the-internet.herokuapp.com/drag_and_drop");
            //var source = _driver.FindElement(By.Id("column-a"));
            var source = _wait.Until(ExpectedConditions.ElementIsVisible(By.Id("column-a")));
            //Thread.Sleep(1000);
            var jsFile = File.ReadAllText(@"C:\projects_selenium_c#\UserInteractions\UserInterActions_NUnit\Github\drag_and_drop_helper.js");
            IJavaScriptExecutor js = _driver as IJavaScriptExecutor;
            js.ExecuteScript(jsFile + "$('#column-a').simulateDragDrop({ dropTarget: '#column-b'});");

            //Thread.Sleep(1000);
            Assert.AreEqual("A", _driver.FindElement(By.XPath("//*[@id='column-b']/header")).Text );
        }

    }
}