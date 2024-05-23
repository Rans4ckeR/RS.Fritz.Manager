﻿namespace RS.Fritz.Manager.API;

using System.Net;

internal interface IClientFactory<T>
{
    T Build(Uri location, bool secure, string controlUrl, ushort? port, NetworkCredential? networkCredential);
}