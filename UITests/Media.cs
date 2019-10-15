﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Appium.Windows;

namespace UITests
{
    [TestClass]
    public class Media : Test_Base
    {
        private static WindowsElement mediaElement1 = null;
        private static WindowsElement mediaElement2 = null;

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            Setup(context);
            var buttonTab = session.FindElementByName("Media");
            buttonTab.Click();
            var button = session.FindElementByName("MediaPlayerElement");
            button.Click();
            var mediaElements = session.FindElementsByClassName("MediaPlayerElement");
            Assert.IsTrue(mediaElements.Count >= 2);
            mediaElement1 = mediaElements[0];
            mediaElement2 = mediaElements[1];
            Assert.IsNotNull(mediaElement1);
            Assert.IsNotNull(mediaElement2);
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            TearDown();
        }

        [TestMethod]
        public void PlayMedia()
        {
            Thread.Sleep(1000);
            WindowsElement play = session.FindElementByAccessibilityId("PlayPauseButton");
            Assert.IsNotNull(play);
            Assert.IsNotNull(session.FindElementByAccessibilityId("svPanel"));
            Thread.Sleep(1000);

            try
            {
                play.Click();
            }
            catch
            {

            }
            Thread.Sleep(1000);
            play.Click();
        }
    }

    [TestClass]
    public class PersonPicture : Test_Base
    {
        private static WindowsElement mediaElement1 = null;
        private static WindowsElement mediaElement2 = null;

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            Setup(context);
            //NavigateTo("Selection and picker controls", "RadioButton");

            var buttonTab = session.FindElementByName("Media");
            buttonTab.Click();
            var button = session.FindElementByName("PersonPicture");
            button.Click();
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            TearDown();
        }

    }
    
}
