using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using WebPageTest.Annotations;
using WebPageTest.Helpers;
using WebPageTest.Models;

namespace WebPageTest.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private bool _progressBarVisibility;
        private ResultTest _resultTest;
        private ICommand _startCommand;
        private string _url = "http://";

        public string Url
        {
            get
            {
                var url = _url;
                if (url.ToLower().StartsWith("http")) return url;
                return "http://" + url;
            }
            set => _url = value;
        }

        public bool ProgressBarVisibility
        {
            get => _progressBarVisibility;
            set
            {
                _progressBarVisibility = value;
                OnPropertyChanged();
            }
        }

        public ResultTest ResultTest
        {
            get => _resultTest;
            set
            {
                _resultTest = value;
                OnPropertyChanged();
            }
        }

        public ICommand StartCommand
        {
            get
            {
                if (_startCommand != null)
                    return _startCommand;

                _startCommand = new RelayCommand(async q => await ExecuteStartCommand(), q => true);
                return _startCommand;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private async Task ExecuteStartCommand()
        {
            ProgressBarVisibility = true;
            await Task.Run(() =>
            {
                try
                {
                    ResultTest = WebsiteAnalyzer.Analyze(Url);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            });
            ProgressBarVisibility = false;
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}