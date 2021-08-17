namespace RS.Fritz.Manager.Domain
{
    using System;
    using System.ServiceModel;

    public sealed class ServiceOperationHandlerException : Exception
    {
        public ServiceOperationHandlerException(string message, FaultException innerException)
            : base(message, innerException)
        {
        }
    }
}