namespace RS.Fritz.Manager.API;

using System.Text;

public static class ExceptionMessageBuilder
{
    public static string GetDetailedExceptionInfo(this Exception ex)
    {
        return new StringBuilder().GetExceptionInfo(ex).ToString();
    }

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

#pragma warning disable IDE0045 // Convert to conditional expression
            if (ex is FaultException<UPnPFault1> upnpFaultFault1Exception)
            {
                _ = sb.AppendLine(FormattableString.Invariant($"{nameof(UPnPFault1)}.{nameof(UPnPFault1.ErrorCode)}: {upnpFaultFault1Exception.Detail.ErrorCode}"))
                    .AppendLine(FormattableString.Invariant($"{nameof(UPnPFault1)}.{nameof(UPnPFault1.ErrorDescription)}: {upnpFaultFault1Exception.Detail.ErrorDescription}"));
            }
            else if (ex is FaultException<UPnPFault2> upnpFaultFault2Exception)
            {
                _ = sb.AppendLine(FormattableString.Invariant($"{nameof(UPnPFault2)}.{nameof(UPnPFault2.ErrorCode)}: {upnpFaultFault2Exception.Detail.ErrorCode}"))
                    .AppendLine(FormattableString.Invariant($"{nameof(UPnPFault2)}.{nameof(UPnPFault2.ErrorDescription)}: {upnpFaultFault2Exception.Detail.ErrorDescription}"));
            }
            else
            {
                throw new NotSupportedException(FormattableString.Invariant($"Encountered unexpected {nameof(FaultException)}."));
            }
#pragma warning restore IDE0045 // Convert to conditional expression
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
}