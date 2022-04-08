namespace RS.Fritz.Manager.API;

[MessageContract(WrapperName = "GenerateUuId")]
public readonly record struct DeviceConfigGenerateUuIdRequest;