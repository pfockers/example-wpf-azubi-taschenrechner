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
    using Taschenrechner_Own_MVVM.Model;

    public class CalculatorViewModel : INotifyPropertyChanged
    {
        #region Fields

        private string _display = "";

        private bool _isNewInput = true;

        private readonly CalculatorModel _model = new();

        private string _operator = "";

        private double _zahl1 = 0;

        #endregion

        #region Properties

        public ICommand ClearCommand { get; }

        public string Display
        {
            get => _display;
            set
            {
                _display = value;
                OnPropertyChanged(nameof(Display));
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
            NumberCommand = new RelayCommand(param => AddNumber(param?.ToString() ?? ""));
            OperatorCommand = new RelayCommand(param => SetOperator(param?.ToString() ?? ""));
            EqualCommand = new RelayCommand(_ => Calculate());
            ClearCommand = new RelayCommand(_ => Clear());
            KommaCommand = new RelayCommand(_ => AddKomma());
        }

        #endregion

        #region Methods

        private void AddKomma()
        {
            if (!Display.Contains(","))
            {
                if (string.IsNullOrEmpty(Display))
                    Display = "0";
                Display += ",";
            }
        }

        private void AddNumber(string number)
        {
            if (_isNewInput)
            {
                Display = "";
                _isNewInput = false;
            }

            Display += number;
        }

        private void Calculate()
        {
            if (double.TryParse(Display, out double zahl2))
            {
                try
                {
                    var result = _model.Calculate(_zahl1, zahl2, _operator);
                    Display = result.ToString(CultureInfo.CurrentCulture);
                }
                catch (DivideByZeroException)
                {
                    Display = "Fehler: Division durch 0";
                }

                _isNewInput = true;
            }
        }

        private void Clear()
        {
            Display = "";
            _zahl1 = 0;
            _operator = "";
            _isNewInput = true;
        }

        protected void OnPropertyChanged(string name) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        private void SetOperator(string op)
        {
            if (double.TryParse(Display, out _zahl1))
            {
                _operator = op;
                _isNewInput = true;
            }
        }

        #endregion
    }
}