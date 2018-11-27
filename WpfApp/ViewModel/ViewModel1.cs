using System.ComponentModel;
using System.Windows.Input;

namespace WpfApp.ViewModel
{
    class ViewModel1 : INotifyPropertyChanged
    {
        private string text1 = "";
        public string Text1
        {
            get
            {
                return text1;
            }
            set
            {
                text1 = value;
                OnPropertyChanged("Text1");
            }
        }
        private string text2 = "";
        public string Text2
        {
            get
            {
                return text2;
            }
            set
            {
                text2 = value;
                OnPropertyChanged("Text2");
            }
        }

        public ICommand CopyCommand { get; set; }

        public ViewModel1()
        {
            CopyCommand = new Command(Copy);
        }
        private void Copy(object parametre)
        {
            Text2 = Text1;
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