using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;

namespace UserInterActions_NUnit
{
    [TestFixture]
    public class UserInteractions01
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
        public void TestDragAndDrop_01()
        {

            _driver.Navigate().GoToUrl("https://jqueryui.com/droppable/");
            _wait.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt(By.ClassName("demo-frame")));

            var targetElement = _driver.FindElement(By.Id("droppable"));
            var sourceElement = _driver.FindElement(By.Id("draggable"));

            _actions.DragAndDrop(sourceElement, targetElement).Perform();

            Assert.AreEqual("Dropped!", targetElement.Text);

        }

        [Test]
        public void TestDragAndDrop_02()
        {

            _driver.Navigate().GoToUrl("https://jqueryui.com/droppable/");
            _wait.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt(By.ClassName("demo-frame")));

            var targetElement = _driver.FindElement(By.Id("droppable"));
            var sourceElement = _driver.FindElement(By.Id("draggable"));

            var drag = _actions
                .ClickAndHold(sourceElement)
                .MoveToElement(targetElement)
                .Release(targetElement)
                .Build();

            drag.Perform();

            Assert.AreEqual("Dropped!", targetElement.Text);

        }

        [Test]
        public void OpenNetworkTab()
        {
            _driver.Navigate().GoToUrl("https://www.google.com");
            _actions.KeyDown(Keys.Control).KeyDown(Keys.Shift).SendKeys("q").Perform();

            _actions.KeyUp(Keys.Control).KeyUp(Keys.Shift).Perform();
            _driver.Navigate().GoToUrl("https://jqueryui.com/droppable/");
        }

    }
}