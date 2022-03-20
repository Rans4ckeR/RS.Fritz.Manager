namespace RS.Fritz.Manager.UI;

using System;
using RS.Fritz.Manager.API;

internal readonly record struct DeviceMeshInfo(string MeshListPath, Uri MeshListPathLink, DeviceMesh DeviceMesh);