namespace RS.Fritz.Manager.API;

[MessageContract(WrapperName = "SetUpgradeManagement")]
public readonly record struct ManagementServerSetUpgradeManagementRequest(
    [property: MessageBodyMember(Name = "NewUpgradesManaged")] bool UpgradesManaged);