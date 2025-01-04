using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using Microsoft.Extensions.Logging;

namespace RS.Fritz.Manager.API;

internal sealed class ClientMessageLogger(ILogger logger) : IClientMessageInspector
{
    private readonly ILogger logger = logger;

    public void AfterReceiveReply(ref Message reply, object correlationState)
    {
        (string version, bool isFault, bool isEmpty, string body) = GetLogMessage(ref reply);

        logger.SoapReply(version, isFault, isEmpty, body);
    }

    public object? BeforeSendRequest(ref Message request, IClientChannel channel)
    {
        (string version, bool isFault, bool isEmpty, string body) = GetLogMessage(ref request);

        logger.SoapRequest(version, isFault, isEmpty, body);

        return null;
    }

    private static (string Version, bool IsFault, bool IsEmpty, string Body) GetLogMessage(ref Message message)
    {
        using MessageBuffer messageBuffer = message.CreateBufferedCopy(int.MaxValue);
        using Message messageCopy = messageBuffer.CreateMessage();
        var stringBuilder = new StringBuilder();

        using (var xmlWriter = XmlWriter.Create(stringBuilder))
        {
            messageCopy.WriteMessage(xmlWriter);
        }

        message = messageBuffer.CreateMessage();

        return (messageCopy.Version.ToString(), messageCopy.IsFault, messageCopy.IsEmpty, XElement.Parse(stringBuilder.ToString()).ToString());
    }
}