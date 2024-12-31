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
        MessageBuffer messageBuffer = reply.CreateBufferedCopy(int.MaxValue);

        logger.SoapReply(GetLogMessage(messageBuffer));

        reply = messageBuffer.CreateMessage();
    }

    public object? BeforeSendRequest(ref Message request, IClientChannel channel)
    {
        MessageBuffer messageBuffer = request.CreateBufferedCopy(int.MaxValue);

        logger.SoapRequest(GetLogMessage(messageBuffer));

        request = messageBuffer.CreateMessage();

        return null;
    }

    private static string GetLogMessage(MessageBuffer messageBuffer)
    {
        Message message = messageBuffer.CreateMessage();
        var stringBuilder = new StringBuilder();

        using (var xmlWriter = XmlWriter.Create(stringBuilder))
        {
            message.WriteMessage(xmlWriter);
        }

        return XElement.Parse(stringBuilder.ToString()).ToString();
    }
}