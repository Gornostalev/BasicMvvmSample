namespace BasicMvvmSample.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    public string Greeting { get; } = "Welcome to Avalonia!";

    public SimpleViewModel SimpleViewModel { get; } = new SimpleViewModel();

    // Наша новая реактив модел вьюшка
   public ReactiveViewModel ReactiveViewModel { get; } = new ReactiveViewModel();
    
}
