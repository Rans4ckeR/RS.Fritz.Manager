namespace RS.Fritz.Manager.API;

using System.ServiceModel;

[MessageContract(WrapperName = "GetLinkLayerMaxBitRates")]
public sealed record WanPppConnectionGetLinkLayerMaxBitRatesRequest;