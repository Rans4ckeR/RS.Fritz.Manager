﻿namespace RS.Fritz.Manager.UI
{
    using System.ComponentModel;
    using System.Threading.Tasks;
    using Microsoft.Extensions.Logging;

    internal sealed class DeviceInfoSetProvisioningCodeViewModel : FritzServiceViewModel
    {
        private string provisioningCode = string.Empty;

        public DeviceInfoSetProvisioningCodeViewModel(DeviceLoginInfo deviceLoginInfo, ILogger logger)
            : base(deviceLoginInfo, logger)
        {
        }

        public string ProvisioningCode
        {
            get => provisioningCode;
            set
            {
                if (SetProperty(ref provisioningCode, value))
                    DefaultCommand.NotifyCanExecuteChanged();
            }
        }

        protected override async Task DoExecuteDefaultCommandAsync()
        {
            _ = await DeviceLoginInfo.InternetGatewayDevice!.InternetGatewayDevice.ExecuteAsync((h, d) => h.DeviceInfoSetProvisioningCodeAsync(d, ProvisioningCode));
        }

        protected override void FritzServiceViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            base.FritzServiceViewModelPropertyChanged(sender, e);

            switch (e.PropertyName)
            {
                case nameof(ProvisioningCode):
                    {
                        UpdateCanExecuteDefaultCommand();
                        break;
                    }
            }
        }
    }
}