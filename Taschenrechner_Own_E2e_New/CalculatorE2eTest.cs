// <copyright company="ROSEN Swiss AG">
//  Copyright (c) ROSEN Swiss AG
//  This computer program includes confidential, proprietary
//  information and is a trade secret of ROSEN. All use,
//  disclosure, or reproduction is prohibited unless authorized in
//  writing by an officer of ROSEN. All Rights Reserved.
// </copyright>

namespace Taschenrechner_Own_E2e_New
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using SmartBear.TestLeft;
    using SmartBear.TestLeft.TestObjects;
    using SmartBear.TestLeft.TestObjects.WPF;

    [TestClass]
    public class CalculatorE2eTest
    {
        #region Methods

        [TestMethod]
        public void Addition_TwoPlusThree_ShowsFive()
        {
            // MainWindow finden
            var driver = new LocalDriver();
            var mainWindow = driver.Find<IWindow>(new WPFPattern());

            // Buttons klicken: 2 + 3 =
            mainWindow.Find<IButton>(new WPFPattern { WPFControlText = "2" }).Click();
            mainWindow.Find<IButton>(new WPFPattern { WPFControlText = "+" }).Click();
            mainWindow.Find<IButton>(new WPFPattern { WPFControlText = "3" }).Click();
            mainWindow.Find<IButton>(new WPFPattern { WPFControlText = "=" }).Click();

            // Ergebnis auslesen
            var resultBox = mainWindow.Find<IControl>(new WPFPattern { WPFControlName = "ErgebnisTextBox" });
            string result = resultBox.ToString();

            Assert.AreEqual("5", result);
        }

        #endregion
    }
}