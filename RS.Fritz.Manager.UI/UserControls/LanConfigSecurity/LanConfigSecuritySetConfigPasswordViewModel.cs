namespace RS.Fritz.Manager.UI
{
    using System.ComponentModel;
    using System.Threading.Tasks;
    using Microsoft.Extensions.Logging;
    using RS.Fritz.Manager.Domain;

    internal sealed class LanConfigSecuritySetConfigPasswordViewModel : FritzServiceViewModel
    {
        private string? password;

        public LanConfigSecuritySetConfigPasswordViewModel(ILogger logger, IFritzServiceOperationHandler fritzServiceOperationHandler)
            : base(logger, fritzServiceOperationHandler)
        {
        }

        public string? Password
        {
            get => password;
            set
            {
                if (SetProperty(ref password, value))
                    DefaultCommand.NotifyCanExecuteChanged();
            }
        }

        protected override async Task DoExecuteDefaultCommandAsync()
        {
            _ = await FritzServiceOperationHandler.LanConfigSecuritySetConfigPasswordAsync(Password!);
        }

        protected override void FritzServiceViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            base.FritzServiceViewModelPropertyChanged(sender, e);

            switch (e.PropertyName)
            {
                case nameof(Password):
                    {
                        UpdateCanExecuteDefaultCommand();
                        break;
                    }
            }
        }

        protected override bool GetCanExecuteDefaultCommand()
        {
            return base.GetCanExecuteDefaultCommand() && !string.IsNullOrWhiteSpace(Password);
        }
    }
}