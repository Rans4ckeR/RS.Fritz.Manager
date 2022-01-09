//
// BasicHttpBinding Klasse
// https://docs.microsoft.com/de-de/dotnet/api/system.servicemodel.basichttpbinding?view=dotnet-plat-ext-6.0
//
// Introduction to the MVVM Toolkit
// https://docs.microsoft.com/en-us/windows/communitytoolkit/mvvm/introduction
/// <summary>
/// /
/// </summary>


namespace RS.Fritz.Manager.UI
{
    using System;
    using System.Threading.Tasks;
    using System.Windows.Threading;
    using CommunityToolkit.Mvvm.Messaging.Messages;
    using Microsoft.Extensions.Logging;
    using RS.Fritz.Manager.Domain;

    internal sealed class WANCommonInterfaceConfigViewModel : FritzServiceViewModel
    {
        private bool autoRefresh;

        private WanCommonInterfaceConfigGetTotalBytesReceivedResponse? wanCommonInterfaceConfigGetTotalBytesReceivedResponse;

        // Constructor
        public WANCommonInterfaceConfigViewModel(DeviceLoginInfo deviceLoginInfo, ILogger logger, IFritzServiceOperationHandler fritzServiceOperationHandler)
            : base(deviceLoginInfo, logger, fritzServiceOperationHandler)
        {
            int dummy2 = 1;
            
        }

        



        public WanCommonInterfaceConfigGetTotalBytesReceivedResponse? WanCommonInterfaceConfigGetTotalBytesReceivedResponse
        {
            get => wanCommonInterfaceConfigGetTotalBytesReceivedResponse; set { _ = SetProperty(ref wanCommonInterfaceConfigGetTotalBytesReceivedResponse, value); }
        }

        /*
        public override void Receive(PropertyChangedMessage<bool> message)
        {
            base.Receive(message);

            if (message.Sender != DeviceLoginInfo)
                return;

            switch (message.PropertyName)
            {
                case nameof(DeviceLoginInfo.LoginInfoSet):
                    {
                        if (!message.NewValue)
                        {
                            //AutoRefresh = false;
                        }
                        break;
                    }
            }
        }
        */

        protected override async Task DoExecuteDefaultCommandAsync()
        {
            await Domain.TaskExtensions.WhenAllSafe(new[]
                {
                   GetWanCommonInterfaceConfigGetTotalReceivedBytesAsync(),
                });
        }

        private async Task GetWanCommonInterfaceConfigGetTotalReceivedBytesAsync()
        {
            wanCommonInterfaceConfigGetTotalBytesReceivedResponse = await FritzServiceOperationHandler.GetWanCommonInterfaceConfigGetTotalBytesReceivedAsync();
#pragma warning disable S1481 // Unused local variables should be removed
            var theCopy = wanCommonInterfaceConfigGetTotalBytesReceivedResponse;
#pragma warning restore S1481 // Unused local variables should be removed
        }

        /*
        private async void AutoRefreshTimerTick(object? sender, EventArgs e)
        {
            if (CanExecuteDefaultCommand)
                await DefaultCommand.ExecuteAsync(false);
        }
        */
    }
}