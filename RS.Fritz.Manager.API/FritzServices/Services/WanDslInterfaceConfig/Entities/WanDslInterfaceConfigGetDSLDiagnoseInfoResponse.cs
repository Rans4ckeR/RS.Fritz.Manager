namespace RS.Fritz.Manager.API;

using System;
using System.ServiceModel;

[MessageContract(WrapperName = "GetDslDiagnoseInfoResponse")]
public readonly record struct WanDslInterfaceConfigGetDslDiagnoseInfoResponse(
    [property: MessageBodyMember(Name = "NewX_AVM-DE_DSLDiagnoseState")] string DSLDiagnoseState,
    [property: MessageBodyMember(Name = "NewX_AVM-DE_CableNokDistance")] int CableNokDistance,
    [property: MessageBodyMember(Name = "NewX_AVM-DE_DSLLastDiagnoseTime")] uint DSLLastDiagnoseTime,
    [property: MessageBodyMember(Name = "NewX_AVM-DE_DSLSignalLossTime")] uint DSLSignalLossTime,
    [property: MessageBodyMember(Name = "NewX_AVM-DE_DSLActive")] bool DSLActive,
    [property: MessageBodyMember(Name = "NewX_AVM-DE_DSLSync")] bool DSLSync)
{
    public string? Status
    {
        get
        {
            if ("NONE".Equals(DSLDiagnoseState, StringComparison.OrdinalIgnoreCase) && CableNokDistance == -1 && DSLLastDiagnoseTime == 0 && DSLSignalLossTime == 0 && DSLActive && DSLSync)
                return "The DSL connection is ready for data traffic. The Customer Premises Equipment (CPE) has set DSL to Active and the DSL chip could sync to ISP destination device.";

            if ("NONE".Equals(DSLDiagnoseState, StringComparison.OrdinalIgnoreCase) && CableNokDistance == -1 && DSLLastDiagnoseTime == 0 && DSLSignalLossTime > 0 && DSLSignalLossTime < 300 && DSLActive && !DSLSync)
                return "The Customer Premises Equipment (CPE) Device has lost the sync state since DSLSignalLossTime(in seconds).";

            if ("RUNNING".Equals(DSLDiagnoseState, StringComparison.OrdinalIgnoreCase) && CableNokDistance == -1 && DSLLastDiagnoseTime == 0 && DSLSignalLossTime > 300 && DSLActive && !DSLSync)
                return "5 minutes passed since the last DSLSync = 1, the Customer Premises Equipment (CPE) device is now instantiating a cable cut measurement. While the diagnose is running the DSLDiagnoseState is set to 'RUNNING'.";

            if ("NO_CALIB".Equals(DSLDiagnoseState, StringComparison.OrdinalIgnoreCase) && CableNokDistance == -1 && DSLLastDiagnoseTime == 0 && DSLSignalLossTime > 300 && DSLActive && !DSLSync)
                return "The Customer Premises Equipment (CPE) has tried to start a cable cut measurement, but could not initiate the measurement.Therefore no calibration has passed.";

            if ("DONE_CABLE_OK".Equals(DSLDiagnoseState, StringComparison.OrdinalIgnoreCase) && CableNokDistance == -1 && DSLLastDiagnoseTime > 0 && DSLSignalLossTime > 300 && DSLActive && !DSLSync)
                return "The cable cut measurement is finished and no cable cut could be detected.";

            if ("DONE_CABLE_NOK".Equals(DSLDiagnoseState, StringComparison.OrdinalIgnoreCase) && CableNokDistance > 0 && DSLLastDiagnoseTime > 0 && DSLSignalLossTime > 300 && DSLActive && !DSLSync)
                return FormattableString.CurrentCulture($"The cable cut measurement is finished and a problem with the cable connection could be detected at {CableNokDistance} meters.");

            if ("DONE_CABLE_OK".Equals(DSLDiagnoseState, StringComparison.OrdinalIgnoreCase) && CableNokDistance == -1 && DSLLastDiagnoseTime > 0 && DSLSignalLossTime > 300 && DSLActive && !DSLSync)
                return "The measurement for cable cut is finished but the distance could not be detected or is too inaccurate.";

            if ("NONE".Equals(DSLDiagnoseState, StringComparison.OrdinalIgnoreCase) && CableNokDistance == -1 && DSLLastDiagnoseTime > 0 && DSLSignalLossTime == 0 && DSLActive && DSLSync)
                return "When the DSL signal is sync again, all values will be set to default values. Except the DSLLastDiagnoseTime which remains at the value of time in seconds between the last measurement and the resync.";

            return null;
        }
    }
}