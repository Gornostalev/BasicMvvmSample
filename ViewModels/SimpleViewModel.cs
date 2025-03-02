// Remember to add this to your usings
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;

namespace BasicMvvmSample.ViewModels
{
    // This is our simple ViewModel. We need to implement the interface "INotifyPropertyChanged"
    // in order to notify the View if any of our properties changed.
    public class SimpleViewModel : INotifyPropertyChanged
    {
        // This event is implemented by "INotifyPropertyChanged" and is all we need to inform
        // our view about changes.
        public event PropertyChangedEventHandler? PropertyChanged;

        //Очень интересная штучька!
        //CallerMemberName выступает в роли сервиса компилятора, и помогает установить propertyName из свойства, которое изменилось
        private void RaisePropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            Debug.WriteLine(propertyName);
        }

        private string? _Name; // имя для поля

        public string? Name 
        {
            get
            {
                return _Name;
            }
            set
            {
                // нам нужно только обновлять имя на актуальнуе,+ нужно проверить что оно действительно новое
                if(_Name != value)
                {
                    _Name = value;

                    //Параметр не передаем, это тоже самое что RaisePropertyChanged(nameof(Name));
                     

                    // в данном случае мы очень зависимы от этого события,
                    //  т.к без него не будет ввода в Name и не будет обновления Greeting
                    //Thread.Sleep(2999);
                     RaisePropertyChanged();
                     
                     RaisePropertyChanged(nameof(Greeting));

                }
            }
        }

        public string Greeting
        {
            get
            {
                if(string.IsNullOrEmpty(Name))
                {
                    Debug.WriteLine(Name);
                    return "Привет из Авалонии!";
                }
                else
                {
                    Debug.WriteLine(Name);
                    return $"Привет {Name}, как здорово что ты здесь!";
                }
            }            
        }
    }
}