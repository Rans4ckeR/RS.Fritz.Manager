namespace RS.Fritz.Manager.API;

[MessageContract(WrapperName = "GetLinkLayerMaxBitRates")]
public readonly record struct WanPppConnectionGetLinkLayerMaxBitRatesRequest;