namespace RS.Fritz.Manager.UI
{
    using System.ComponentModel;
    using System.Threading.Tasks;
    using Microsoft.Extensions.Logging;

    internal sealed class LanConfigSecuritySetConfigPasswordViewModel : FritzServiceViewModel
    {
        private string? password;

        public LanConfigSecuritySetConfigPasswordViewModel(DeviceLoginInfo deviceLoginInfo, ILogger logger)
            : base(deviceLoginInfo, logger)
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
            _ = await DeviceLoginInfo.InternetGatewayDevice!.ExecuteAsync((h, d) => h.LanConfigSecuritySetConfigPasswordAsync(d, Password!));
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