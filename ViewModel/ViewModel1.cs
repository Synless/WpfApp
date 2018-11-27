using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Input;

namespace WpfApp.ViewModel
{
    class ViewModel1 : INotifyPropertyChanged
    {
        private string amount = "100000";
        public string Amount
        {
            get
            {
                return amount;
            }
            set
            {
                amount = value;
                OnPropertyChanged("Amount");
            }
        }
        double amountDouble;

        private string rate = "1";
        public string Rate
        {
            get
            {
                return rate;
            }
            set
            {
                rate = value;
                OnPropertyChanged("Rate");
            }
        }
        double rateDouble;

        private string years = "20";
        public string Years
        {
            get
            {
                return years;
            }
            set
            {
                years = value;
                OnPropertyChanged("Years");
            }
        }
        int yearsInt;

        private ObservableCollection<MonthlyPayement> loan = new ObservableCollection<MonthlyPayement>();
        public ObservableCollection<MonthlyPayement> Loan
        {
            get
            {
                return loan;
            }
            set
            {
                loan = value;
                OnPropertyChanged("Loan");
            }
        }

        public class MonthlyPayement
        {
            public string YM        { get; set; }
            public string Y         { get; set; }
            public string M         { get; set; }
            public string Monthly   { get; set; }
            public string Interest  { get; set; }
            public string Base      { get; set; }
            public string Payed     { get; set; }
            public string Remaining { get; set; }
        }


        public ICommand CopyCommand { get; set; }

        public ViewModel1()
        {
            CopyCommand = new Command(Copy);
        }
        private int n = 0;
        private void Copy(object parametre)
        {
            try
            {
                amountDouble = Double.Parse(Amount);
                rateDouble = Double.Parse(Rate)/100;
                yearsInt = Int32.Parse(Years);
                while (true)
                {
                    double toPayThisYear = amountDouble / yearsInt;
                    double tmp = Math.Pow(1 - rateDouble, (-1) * rateDouble);
                    double An = amountDouble * (rateDouble / ((-1) * tmp));

                    break;
                }
                OnPropertyChanged("List");

            }
            catch
            {
                System.Windows.MessageBox.Show("Invalid format");
            }
        }
        
        #region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}