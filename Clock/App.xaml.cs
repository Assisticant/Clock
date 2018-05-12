using Assisticant;
using System;
using System.Windows;

namespace Clock
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        ObservableClock _model;

        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);

            if (_model == null)
            {
                _model = new ObservableClock();
                var viewModel = new TimeDisplay(_model);
                MainWindow.DataContext = ForView.Wrap(viewModel);
            }
        }

        protected override void OnExit(ExitEventArgs e)
        {
            _model.Dispose();

            base.OnExit(e);
        }
    }
}
