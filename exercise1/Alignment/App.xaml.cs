namespace Alignment;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();
	}
	//añadir cambios a la vaina esta
	protected override Window CreateWindow(IActivationState activationState)
	{
		return new Window(new AppShell());
	}
}
