using System.Collections.ObjectModel;
using System.Runtime.Serialization;

namespace RS.Fritz.Manager.API;

[CollectionDataContract(Name = "List", ItemName = "Item", Namespace = "")]
internal sealed class DeviceHostsList : Collection<DeviceHost>;