// <copyright company="ROSEN Swiss AG">
//  Copyright (c) ROSEN Swiss AG
//  This computer program includes confidential, proprietary
//  information and is a trade secret of ROSEN. All use,
//  disclosure, or reproduction is prohibited unless authorized in
//  writing by an officer of ROSEN. All Rights Reserved.
// </copyright>

namespace Taschenrechner_Own_MVVM.Test
{
    using Taschenrechner_Own_MVVM.Model;

    [TestClass]
    public sealed class CalculatorModelTests
    {
        #region Fields

        private CalculatorModel _calculator;

        #endregion

        #region Methods

        [TestMethod]
        public void Calculate_Addition_ReturnsSum()
        {
            var result = _calculator.Calculate(2, 3, "+");
            Assert.AreEqual(5, result, 1e-10);
        }

        [TestMethod]
        public void Calculate_Division_ReturnsQuotient()
        {
            var result = _calculator.Calculate(10, 2, "/");
            Assert.AreEqual(5, result, 1e-10);
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void Calculate_DivisionByZero_ThrowsException()
        {
            _calculator.Calculate(5, 0, "/");
        }

        [TestMethod]
        public void Calculate_Multiplication_ReturnsProduct()
        {
            var result = _calculator.Calculate(4, 3, "*");
            Assert.AreEqual(12, result, 1e-10);
        }

        [TestMethod]
        public void Calculate_Subtraction_ReturnsDifference()
        {
            var result = _calculator.Calculate(5, 2, "-");
            Assert.AreEqual(3, result, 1e-10);
        }

        [TestMethod]
        public void Calculate_UnknownOperator_ReturnsZero()
        {
            var result = _calculator.Calculate(1, 2, "%");
            Assert.AreEqual(0, result, 1e-10);
        }

        [TestInitialize]
        public void Setup()
        {
            _calculator = new CalculatorModel();
        }

        #endregion
    }
}