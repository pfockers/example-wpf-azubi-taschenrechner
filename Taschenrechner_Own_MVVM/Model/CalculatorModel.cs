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

        public double Calculate(double zahl1, double zahl2, string op)
        {
            return op switch
            {
                "+" => zahl1 + zahl2,
                "-" => zahl1 - zahl2,
                "*" => zahl1 * zahl2,
                "/" => zahl2 != 0 ? zahl1 / zahl2 : throw new DivideByZeroException(),
                _ => 0
            };
        }

        #endregion
    }
}