﻿//
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

    internal sealed class WanCommonInterfaceConfigViewModel : FritzServiceViewModel
    {
        private bool autoRefresh;

        private WanCommonInterfaceConfigGetTotalBytesReceivedResponse? wanCommonInterfaceConfigGetTotalBytesReceivedResponse;
        private WanCommonInterfaceConfigGetCommonLinkPropertiesResponse? wanCommonInterfaceConfigGetCommonLinkPropertiesResponse;

        // Constructor
        public WanCommonInterfaceConfigViewModel(DeviceLoginInfo deviceLoginInfo, ILogger logger, IFritzServiceOperationHandler fritzServiceOperationHandler)
            : base(deviceLoginInfo, logger, fritzServiceOperationHandler)
        {
            int dummy2 = 1;
        }

        public WanCommonInterfaceConfigGetTotalBytesReceivedResponse? WanCommonInterfaceConfigGetTotalBytesReceivedResponse
        {
            get => wanCommonInterfaceConfigGetTotalBytesReceivedResponse; set { _ = SetProperty(ref wanCommonInterfaceConfigGetTotalBytesReceivedResponse, value); }
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
                   GetWanCommonInterfaceConfigGetTotalReceivedBytesAsync()
                });
        }

        
        private async Task GetWanCommonInterfaceConfigGetCommonLinkPropertiesAsync()
        {
            //await Task.Delay(1000);
             
            wanCommonInterfaceConfigGetCommonLinkPropertiesResponse = await FritzServiceOperationHandler.GetWanCommonInterfaceConfigGetCommonLinkPropertiesAsync();
            var theCopy = wanCommonInterfaceConfigGetCommonLinkPropertiesResponse;
        }
        

        private async Task GetWanCommonInterfaceConfigGetTotalReceivedBytesAsync()
        {
            wanCommonInterfaceConfigGetTotalBytesReceivedResponse = await FritzServiceOperationHandler.GetWanCommonInterfaceConfigGetTotalBytesReceivedAsync();
        }

        
    }
}