using ReactiveUI;
using System;

namespace BasicMvvmSample.ViewModels
{
    // Instead of implementing "INotifyPropertyChanged" on our own we use "ReactiveObject" as
    // our base class. Read more about it here: https://www.reactiveui.net
    public class ReactiveViewModel : ReactiveObject
    {
        private string? _Name; 

        public string? Name
        {

            get 
            {
                return _Name;
            }
            set
            {
                this.RaiseAndSetIfChanged(ref _Name, value);
            }
        }

        public string Greeting
        {
            get
            {
                if(string.IsNullOrEmpty(Name))
                {
                    return "Привет из Авалонии!";
                }
                else
                {
                    return $"Привет {Name}, как здорово что ты здесь!";
                }
            }            
        }
    
    }
}