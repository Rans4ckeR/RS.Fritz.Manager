namespace RS.Fritz.Manager.UI
{
    using System;
    using System.Threading.Tasks;
    using System.Windows.Threading;
    using CommunityToolkit.Mvvm.Messaging.Messages;
    using Microsoft.Extensions.Logging;
    using RS.Fritz.Manager.Domain;

    internal sealed class WanCommonInterfaceConfigViewModel : FritzServiceViewModel
    {
        private bool autoRefresh;

        private WanCommonInterfaceConfigGetCommonLinkPropertiesResponse? wanCommonInterfaceConfigGetCommonLinkPropertiesResponse;
        private WanCommonInterfaceConfigGetTotalBytesReceivedResponse? wanCommonInterfaceConfigGetTotalBytesReceivedResponse;
        private WanCommonInterfaceConfigGetTotalBytesSentResponse? wanCommonInterfaceConfigGetTotalBytesSentResponse;

        public WanCommonInterfaceConfigViewModel(DeviceLoginInfo deviceLoginInfo, ILogger logger, IFritzServiceOperationHandler fritzServiceOperationHandler)
            : base(deviceLoginInfo, logger, fritzServiceOperationHandler)
        {
        }

        public WanCommonInterfaceConfigGetTotalBytesReceivedResponse? WanCommonInterfaceConfigGetTotalBytesReceivedResponse
        {
            get => wanCommonInterfaceConfigGetTotalBytesReceivedResponse; set { _ = SetProperty(ref wanCommonInterfaceConfigGetTotalBytesReceivedResponse, value); }
        }

        public WanCommonInterfaceConfigGetTotalBytesSentResponse? WanCommonInterfaceConfigGetTotalBytesSentResponse
        {
            get => wanCommonInterfaceConfigGetTotalBytesSentResponse; set { _ = SetProperty(ref wanCommonInterfaceConfigGetTotalBytesSentResponse, value); }
        }

        public WanCommonInterfaceConfigGetCommonLinkPropertiesResponse? WanCommonInterfaceConfigGetCommonLinkPropertiesResponse
        {
            get => wanCommonInterfaceConfigGetCommonLinkPropertiesResponse; set { _ = SetProperty(ref wanCommonInterfaceConfigGetCommonLinkPropertiesResponse, value); }
        }

        protected override async Task DoExecuteDefaultCommandAsync()
        {
            await Domain.TaskExtensions.WhenAllSafe(new[]
                {
                   GetWanCommonInterfaceConfigGetCommonLinkPropertiesAsync(),
                   GetWanCommonInterfaceConfigGetTotalBytesReceivedAsync(),
                   GetWanCommonInterfaceConfigGetTotalBytesSentAsync()
                });
        }

        private async Task GetWanCommonInterfaceConfigGetCommonLinkPropertiesAsync()
        {
            wanCommonInterfaceConfigGetCommonLinkPropertiesResponse = await FritzServiceOperationHandler.GetWanCommonInterfaceConfigGetCommonLinkPropertiesAsync();
        }

        private async Task GetWanCommonInterfaceConfigGetTotalBytesReceivedAsync()
        {
            wanCommonInterfaceConfigGetTotalBytesReceivedResponse = await FritzServiceOperationHandler.GetWanCommonInterfaceConfigGetTotalBytesReceivedAsync();
        }

        private async Task GetWanCommonInterfaceConfigGetTotalBytesSentAsync()
        {
            wanCommonInterfaceConfigGetTotalBytesSentResponse = await FritzServiceOperationHandler.GetWanCommonInterfaceConfigGetTotalBytesSentAsync();
        }

    }
}