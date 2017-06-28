using App1.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace App1.ViewModels
{
    public class SampleViewModel : BaseViewModel
    {
        private string _Entry1 = string.Empty;
        public string Entry1
        {
            get { return _Entry1; }
            set
            {
                if (_Entry1 == value)
                    return;
                _Entry1 = value;
                OnPropertyChanged("Entry1");

                if (TextChangedComand.CanExecute(null))
                    TextChangedComand.Execute(null);
            }
        }

        private Command _textChangedComand;
        public ICommand TextChangedComand
        {
            get
            {
                _textChangedComand = _textChangedComand ?? new Command(Entry1_OnTextChanged, CanExecuteEntryTextCommand);
                return _textChangedComand;
            }
        }

        private bool CanExecuteEntryTextCommand()
        {
            if (!string.IsNullOrWhiteSpace(Entry1))
                return true;
            return false;
        }

        private void Entry1_OnTextChanged()
        {
            System.Diagnostics.Debug.WriteLine(Entry1);
        }

        private string _currentBtnText = string.Empty;
        public string CurrentBtnText
        {
            get { return _currentBtnText; }
            set
            {
                if (_currentBtnText == value)
                    return;
                _currentBtnText = value;
                OnPropertyChanged("CurrentBtnText");
                    
            }
        }

        public ICommand ButtonCommand { get; set; }

        private ISampleService _sampleService;

        public SampleViewModel()
        {
            _sampleService = DependencyService.Get<ISampleService>();

            ButtonCommand = new Command((e) =>
            {
                var btn = e as Button;
                if (btn != null)
                {
                    CurrentBtnText = btn.Text;

                    System.Diagnostics.Debug.WriteLine(CurrentBtnText);
                }
            });
        }
    }
}
