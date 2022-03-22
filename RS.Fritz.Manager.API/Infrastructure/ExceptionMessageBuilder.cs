namespace RS.Fritz.Manager.API;

using System.Text;

public static class ExceptionMessageBuilder
{
    public static string GetDetailedExceptionInfo(this Exception ex)
    {
        var exceptionStringBuilder = new StringBuilder();

        GetExceptionInfo(ex, exceptionStringBuilder);

        return exceptionStringBuilder.ToString();
    }

    private static void GetExceptionInfo(Exception ex, StringBuilder sb)
    {
        _ = sb.AppendLine(FormattableString.Invariant($"{nameof(Exception)}.{nameof(Exception.GetType)}: {ex.GetType()}"))
            .AppendLine(FormattableString.Invariant($"{nameof(Exception)}.{nameof(Exception.Message)}: {ex.Message}"));

        GetExceptionDetails(ex, sb);

        if (ex is AggregateException aggregateException)
        {
            foreach (Exception innerException in aggregateException.InnerExceptions)
            {
                _ = sb.AppendLine(FormattableString.Invariant($"{nameof(AggregateException)}.{nameof(AggregateException.InnerExceptions)}:"));
                GetExceptionInfo(innerException, sb);
            }
        }
        else if (ex.InnerException is not null)
        {
            _ = sb.AppendLine(FormattableString.Invariant($"{nameof(Exception)}.{nameof(Exception.InnerException)}:"));
            GetExceptionInfo(ex.InnerException, sb);
        }
    }

    private static void GetExceptionDetails(Exception ex, StringBuilder sb)
    {
        _ = sb.AppendLine(FormattableString.Invariant($"{nameof(Exception)}.{nameof(Exception.Source)}: {ex.Source}"))
        .AppendLine(FormattableString.Invariant($"{nameof(Exception)}.{nameof(Exception.TargetSite)}: {ex.TargetSite}"));

        if (ex is FaultException faultException)
        {
            _ = sb.AppendLine(FormattableString.Invariant($"{nameof(FaultException)}.{nameof(FaultException.Action)}: {faultException.Action}"))
                .AppendLine(FormattableString.Invariant($"{nameof(FaultException)}.{nameof(FaultException.Reason)}: {faultException.Reason}"))
                .AppendLine(GetFaultCode(faultException.Code));
        }

        _ = sb.AppendLine(FormattableString.Invariant($"{nameof(Exception)}.{nameof(Exception.StackTrace)}: {ex.StackTrace}"));
    }

    private static string GetFaultCode(FaultCode faultCode)
    {
        var sb = new StringBuilder();

        _ = sb.AppendLine(FormattableString.Invariant($"{nameof(FaultCode)}.{nameof(FaultCode.IsPredefinedFault)}: {faultCode.IsPredefinedFault}"))
            .AppendLine(FormattableString.Invariant($"{nameof(FaultCode)}.{nameof(FaultCode.IsReceiverFault)}: {faultCode.IsReceiverFault}"))
            .AppendLine(FormattableString.Invariant($"{nameof(FaultCode)}.{nameof(FaultCode.IsSenderFault)}: {faultCode.IsSenderFault}"))
            .AppendLine(FormattableString.Invariant($"{nameof(FaultCode)}.{nameof(FaultCode.Name)}: {faultCode.Name}"))
            .AppendLine(FormattableString.Invariant($"{nameof(FaultCode)}.{nameof(FaultCode.Namespace)}: {faultCode.Namespace}"));

        if (faultCode.SubCode is not null)
        {
            _ = sb.AppendLine(FormattableString.Invariant($"{nameof(FaultCode)}.{nameof(FaultCode.SubCode)}:"))
                .AppendLine(GetFaultCode(faultCode.SubCode));
        }

        return sb.ToString();
    }
}