using System.Xml.Serialization;

namespace RS.Fritz.Manager.API;

[XmlRoot(ElementName = "SessionInfo")]
public readonly record struct WebUiSessionInfo(
    [property: XmlElement("SID")] string Sid, // If this value consists of only zeroes, no rights are granted. Login is required. Otherwise, you receive a valid session ID for further access to the FRITZ!Box.The current access rights can be viewed in the<Rights> area
    [property: XmlElement("Challenge")] string Challenge, // Contains the challenge that can be used to log in using the challenge-response method.
    [property: XmlElement("BlockTime")] uint BlockTime, // Time in seconds during which no further login attempt is allowed.
    [property: XmlArray("Rights")][property: XmlArrayItem(typeof(WebUiRightName), ElementName = "Name")][property: XmlArrayItem(typeof(WebUiRightAccess), ElementName = "Access")] WebUiRight[] Rights, // The individual rights granted to the current session ID.Possible values are 1 (read only) and 2 (read and write access)
    [property: XmlArray("Users")][property: XmlArrayItem("User")] WebUiUser[] Users); // A list of all users.Only available in the home network, if activated.The attribute “last = 1” marks the user who was last logged in, otherwise “last = 0”.