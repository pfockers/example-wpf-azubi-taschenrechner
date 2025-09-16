// <copyright company="ROSEN Swiss AG">
//  Copyright (c) ROSEN Swiss AG
//  This computer program includes confidential, proprietary
//  information and is a trade secret of ROSEN. All use,
//  disclosure, or reproduction is prohibited unless authorized in
//  writing by an officer of ROSEN. All Rights Reserved.
// </copyright>

namespace Taschenrechner_Own_MVVM.Model
{
    public class CalculatorModel
    {
        #region Methods

        public double Calculate(double numberOne, double numberTwo, string op)
        {
            return op switch
            {
                "+" => numberOne + numberTwo,
                "-" => numberOne - numberTwo,
                "*" => numberOne * numberTwo,
                "/" => numberTwo != 0 ? numberOne / numberTwo : throw new DivideByZeroException(),
                _ => 0
            };
        }

        #endregion
    }
}