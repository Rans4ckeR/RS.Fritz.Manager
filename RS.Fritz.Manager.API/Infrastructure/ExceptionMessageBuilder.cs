namespace RS.Fritz.Manager.API;

using System.Text;
using System.Xml.Linq;

public static class ExceptionMessageBuilder
{
    public static string GetDetailedExceptionInfo(this Exception ex)
        => new StringBuilder().GetExceptionInfo(ex).ToString();

    private static StringBuilder GetExceptionInfo(this StringBuilder sb, Exception ex)
    {
        sb.AppendLine(FormattableString.Invariant($"{nameof(Exception)}.{nameof(Exception.GetType)}: {ex.GetType()}"))
            .AppendLine(FormattableString.Invariant($"{nameof(Exception)}.{nameof(Exception.Message)}: {ex.Message}"))
            .GetExceptionDetails(ex);

        if (ex is AggregateException aggregateException)
        {
            foreach (Exception innerException in aggregateException.InnerExceptions)
            {
                _ = sb.AppendLine(FormattableString.Invariant($"{nameof(AggregateException)}.{nameof(AggregateException.InnerExceptions)}:"))
                    .GetExceptionInfo(innerException);
            }
        }
        else if (ex.InnerException is not null)
        {
            _ = sb.AppendLine(FormattableString.Invariant($"{nameof(Exception)}.{nameof(Exception.InnerException)}:"))
                .GetExceptionInfo(ex.InnerException);
        }

        return sb;
    }

    private static void GetExceptionDetails(this StringBuilder sb, Exception ex)
    {
        _ = sb.AppendLine(FormattableString.Invariant($"{nameof(Exception)}.{nameof(Exception.Source)}: {ex.Source}"))
            .AppendLine(FormattableString.Invariant($"{nameof(Exception)}.{nameof(Exception.TargetSite)}: {ex.TargetSite}"));

        if (ex is FaultException faultException)
        {
            sb.AppendLine(FormattableString.Invariant($"{nameof(FaultException)}.{nameof(FaultException.Action)}: {faultException.Action}"))
                .AppendLine(FormattableString.Invariant($"{nameof(FaultException)}.{nameof(FaultException.Reason)}: {faultException.Reason}"))
                .GetFaultCode(faultException.Code);

            _ = ex switch
            {
                FaultException<UPnPFault> upnpFaultFaultException => sb
                    .AppendLine(FormattableString.Invariant($"{nameof(UPnPFault)}.{nameof(UPnPFault.ErrorCode)}: {upnpFaultFaultException.Detail.ErrorCode}"))
                    .AppendLine(FormattableString.Invariant($"{nameof(UPnPFault)}.{nameof(UPnPFault.ErrorDescription)}: {upnpFaultFaultException.Detail.ErrorDescription}")),
                FaultException<AvmUPnPFault> avmUpnpFaultFaultException => sb
                    .AppendLine(FormattableString.Invariant($"{nameof(AvmUPnPFault)}.{nameof(AvmUPnPFault.ErrorCode)}: {avmUpnpFaultFaultException.Detail.ErrorCode}"))
                    .AppendLine(FormattableString.Invariant($"{nameof(AvmUPnPFault)}.{nameof(AvmUPnPFault.ErrorDescription)}: {avmUpnpFaultFaultException.Detail.ErrorDescription}")),
                _ => sb.AppendLine(GetFaultReasonContent(faultException))
            };
        }

        _ = sb.AppendLine(FormattableString.Invariant($"{nameof(Exception)}.{nameof(Exception.StackTrace)}: {ex.StackTrace}"));
    }

    private static void GetFaultCode(this StringBuilder sb, FaultCode faultCode)
    {
        _ = sb.AppendLine(FormattableString.Invariant($"{nameof(FaultCode)}.{nameof(FaultCode.IsPredefinedFault)}: {faultCode.IsPredefinedFault}"))
            .AppendLine(FormattableString.Invariant($"{nameof(FaultCode)}.{nameof(FaultCode.IsReceiverFault)}: {faultCode.IsReceiverFault}"))
            .AppendLine(FormattableString.Invariant($"{nameof(FaultCode)}.{nameof(FaultCode.IsSenderFault)}: {faultCode.IsSenderFault}"))
            .AppendLine(FormattableString.Invariant($"{nameof(FaultCode)}.{nameof(FaultCode.Name)}: {faultCode.Name}"))
            .AppendLine(FormattableString.Invariant($"{nameof(FaultCode)}.{nameof(FaultCode.Namespace)}: {faultCode.Namespace}"));

        if (faultCode.SubCode is not null)
        {
            sb.AppendLine(FormattableString.Invariant($"{nameof(FaultCode)}.{nameof(FaultCode.SubCode)}:"))
                .GetFaultCode(faultCode.SubCode);
        }
    }

    private static string GetFaultReasonContent(FaultException ex)
        => FormattableString.Invariant($"{nameof(FaultException)}.{nameof(FaultException.Reason)}.Content: {XElement.Parse(ex.CreateMessageFault().GetReaderAtDetailContents().ReadOuterXml())}");
}