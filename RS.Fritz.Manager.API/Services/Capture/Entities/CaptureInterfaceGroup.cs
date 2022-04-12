namespace RS.Fritz.Manager.API;

public readonly record struct CaptureInterfaceGroup(string Name, IEnumerable<CaptureInterface> CaptureInterfaces);