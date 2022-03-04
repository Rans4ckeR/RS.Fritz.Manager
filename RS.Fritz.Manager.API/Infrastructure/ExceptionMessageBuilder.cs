namespace RS.Fritz.Manager.API
{
    using System;
    using System.ServiceModel;
    using System.Text;

    public static class ExceptionMessageBuilder
    {
        public static string GetDetailedExceptionInfo(this Exception ex)
        {
            var exceptionStringBuilder = new StringBuilder();

            GetExceptionInfo(ex, exceptionStringBuilder);

            return exceptionStringBuilder.ToString();
        }

        public static string GetUserFriendlyExceptionInfo(this Exception ex)
        {
            var exceptionStringBuilder = new StringBuilder();

            GetExceptionInfo(ex, exceptionStringBuilder, false);

            return exceptionStringBuilder.ToString();
        }

        private static void GetExceptionInfo(Exception ex, StringBuilder sb, bool includeDetails = true)
        {
            sb.AppendLine(FormattableString.Invariant($"{nameof(Exception)}.{nameof(Exception.GetType)}: {ex.GetType()}"));
            sb.AppendLine(FormattableString.Invariant($"{nameof(Exception)}.{nameof(Exception.Message)}: {ex.Message}"));

            if (includeDetails)
                GetExceptionDetails(ex, sb);

            if (ex is AggregateException aggregateException)
            {
                foreach (Exception innerException in aggregateException.InnerExceptions)
                {
                    sb.AppendLine(FormattableString.Invariant($"{nameof(AggregateException)}.{nameof(AggregateException.InnerExceptions)}:"));
                    GetExceptionInfo(innerException, sb, includeDetails);
                }
            }
            else if (ex.InnerException is not null)
            {
                sb.AppendLine(FormattableString.Invariant($"{nameof(Exception)}.{nameof(Exception.InnerException)}:"));
                GetExceptionInfo(ex.InnerException, sb, includeDetails);
            }
        }

        private static void GetExceptionDetails(Exception ex, StringBuilder sb)
        {
            sb.AppendLine(FormattableString.Invariant($"{nameof(Exception)}.{nameof(Exception.Source)}: {ex.Source}"));
            sb.AppendLine(FormattableString.Invariant($"{nameof(Exception)}.{nameof(Exception.TargetSite)}: {ex.TargetSite}"));

            if (ex is FaultException faultException)
            {
                sb.AppendLine(FormattableString.Invariant($"{nameof(FaultException)}.{nameof(FaultException.Action)}: {faultException.Action}"));
                sb.AppendLine(FormattableString.Invariant($"{nameof(FaultException)}.{nameof(FaultException.Reason)}: {faultException.Reason}"));
                sb.AppendLine(GetFaultCode(faultException.Code));
            }

            sb.AppendLine(FormattableString.Invariant($"{nameof(Exception)}.{nameof(Exception.StackTrace)}: {ex.StackTrace}"));
        }

        private static string GetFaultCode(FaultCode faultCode)
        {
            var sb = new StringBuilder();

            sb.Append(FormattableString.Invariant($"{nameof(FaultException)}.{nameof(FaultException.Code)}:"));
            sb.AppendLine(FormattableString.Invariant($"{nameof(FaultCode)}.{nameof(FaultCode.IsPredefinedFault)}: {faultCode.IsPredefinedFault}"));
            sb.AppendLine(FormattableString.Invariant($"{nameof(FaultCode)}.{nameof(FaultCode.IsReceiverFault)}: {faultCode.IsReceiverFault}"));
            sb.AppendLine(FormattableString.Invariant($"{nameof(FaultCode)}.{nameof(FaultCode.IsSenderFault)}: {faultCode.IsSenderFault}"));
            sb.AppendLine(FormattableString.Invariant($"{nameof(FaultCode)}.{nameof(FaultCode.Name)}: {faultCode.Name}"));
            sb.AppendLine(FormattableString.Invariant($"{nameof(FaultCode)}.{nameof(FaultCode.Namespace)}: {faultCode.Namespace}"));

            if (faultCode.SubCode is not null)
            {
                sb.AppendLine(FormattableString.Invariant($"{nameof(FaultCode)}.{nameof(FaultCode.SubCode)}:"));
                sb.AppendLine(GetFaultCode(faultCode.SubCode));
            }

            return sb.ToString();
        }
    }
}