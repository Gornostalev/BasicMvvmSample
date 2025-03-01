// Remember to add this to your usings
using System.ComponentModel;
using System.Runtime.CompilerServices;

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
                    return "Привет из Авалонии!!";
                }
                else
                {
                    return $"Привет {Name}";
                }
            }
        }
    }
}