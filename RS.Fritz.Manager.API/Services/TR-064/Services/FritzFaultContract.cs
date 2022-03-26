namespace RS.Fritz.Manager.API;

using System.Xml.Serialization;

public readonly record struct FritzFaultContract(
    [property: XmlElement(ElementName = "errorCode")] ushort ErrorCode,
    [property: XmlElement(ElementName = "errorDescription")] string ErrorDescription);