namespace RS.Fritz.Manager.Domain
{
    using System.ServiceModel;

    [MessageContract(WrapperName = "GetDefaultConnectionServiceResponse")]
    public sealed record Layer3ForwardingGetDefaultConnectionServiceResponse
    {
        [MessageBodyMember(Name = "NewDefaultConnectionService")]
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public string DefaultConnectionService { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    }
}