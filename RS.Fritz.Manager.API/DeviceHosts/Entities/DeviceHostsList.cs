namespace RS.Fritz.Manager.API
{
    using System.Collections.ObjectModel;
    using System.Runtime.Serialization;

    [CollectionDataContract(Name = "List", ItemName = "Item", Namespace = "")]
    internal sealed class DeviceHostsList : Collection<DeviceHost>
    {
    }
}