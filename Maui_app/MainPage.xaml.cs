namespace Maui_app
{
    namespace TutorialMaui
    {
        public partial class MainPage : ContentPage
        {
            int count = 0;

            public MainPage()
            {
                InitializeComponent();
            }

            private void OnCounterClicked(object sender, EventArgs e)
            {
                count += 5;

                if (count == 1)
                    CounterBtn.Text = $"Clicked {count} time";
                else
                    CounterBtn.Text = $"Clicked {count} times";
                //Agreagmos cositas

                SemanticScreenReader.Announce(CounterBtn.Text);
            }
        }

    }

