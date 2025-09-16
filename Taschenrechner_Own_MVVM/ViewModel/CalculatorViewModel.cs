// <copyright company="ROSEN Swiss AG">
//  Copyright (c) ROSEN Swiss AG
//  This computer program includes confidential, proprietary
//  information and is a trade secret of ROSEN. All use,
//  disclosure, or reproduction is prohibited unless authorized in
//  writing by an officer of ROSEN. All Rights Reserved.
// </copyright>

namespace Taschenrechner_Own_MVVM.ViewModel
{
    using System.ComponentModel;
    using System.Globalization;
    using System.Windows.Input;
    using Taschenrechner_Own_MVVM.Commands;
    using Taschenrechner_Own_MVVM.Model;

    public class CalculatorViewModel : INotifyPropertyChanged
    {
        #region Fields

        private string myDisplay = "";

        private bool isNewInput = true;

        private readonly CalculatorModel _model = new();

        private string myOperator = "";

        private double numberOne;

        #endregion

        #region Properties

        public ICommand ClearCommand { get; }

        public string Display
        {
            get => this.myDisplay;
            set
            {
                this.myDisplay = value;
                this.OnPropertyChanged(nameof(CalculatorViewModel.Display));
            }
        }

        public ICommand EqualCommand { get; }

        public ICommand KommaCommand { get; }

        public ICommand NumberCommand { get; }

        public ICommand OperatorCommand { get; }

        #endregion

        #region Events

        public event PropertyChangedEventHandler? PropertyChanged;

        #endregion

        #region Constructors

        public CalculatorViewModel()
        {
            this.NumberCommand = new RelayCommand(param => this.AddNumber(param?.ToString() ?? ""));
            this.OperatorCommand = new RelayCommand(param => this.SetOperator(param?.ToString() ?? ""));
            this.EqualCommand = new RelayCommand(_ => this.Calculate());
            this.ClearCommand = new RelayCommand(_ => this.Clear());
            this.KommaCommand = new RelayCommand(_ => this.AddKomma());
        }

        #endregion

        #region Methods

        private void AddKomma()
        {
            if (!this.Display.Contains(","))
            {
                if (string.IsNullOrEmpty(this.Display)) this.Display = "0";
                this.Display += ",";
            }
        }

        private void AddNumber(string number)
        {
            if (this.isNewInput)
            {
                this.Display = "";
                this.isNewInput = false;
            }

            Display += number;
        }

        private void Calculate()
        {
            if (double.TryParse(Display, out double zahl2))
            {
                try
                {
                    var result = _model.Calculate(this.numberOne, zahl2, this.myOperator);
                    Display = result.ToString(CultureInfo.CurrentCulture);
                }
                catch (DivideByZeroException)
                {
                    Display = "Fehler: Division durch 0";
                }

                this.isNewInput = true;
            }
        }

        private void Clear()
        {
            this.Display = "";
            this.numberOne = 0;
            this.myOperator = "";
            this.isNewInput = true;
        }

        protected void OnPropertyChanged(string name) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        private void SetOperator(string op)
        {
            if (double.TryParse(this.Display, out this.numberOne))
            {
                this.myOperator = op;
                this.isNewInput = true;
            }
        }

        #endregion
    }
}