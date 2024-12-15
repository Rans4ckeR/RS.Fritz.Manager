namespace RS.Fritz.Manager.API;

public readonly record struct SystemVersion(int Hw, int Major, int Minor, int Patch, int BuildNumber, string Display);