namespace RS.Fritz.Manager.API;

using System.ServiceModel;

[MessageContract(WrapperName = "GetLinkLayerMaxBitRates")]
public readonly record struct WanPppConnectionGetLinkLayerMaxBitRatesRequest;