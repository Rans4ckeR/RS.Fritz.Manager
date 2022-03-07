namespace RS.Fritz.Manager.API
{
    using System;
    using System.ServiceModel;

    [MessageContract(WrapperName = "GetDSLDiagnoseInfoResponse")]
#pragma warning disable S101 // Types should be named in PascalCase
    public sealed record WanDslInterfaceConfigGetDSLDiagnoseInfoResponse
#pragma warning restore S101 // Types should be named in PascalCase
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        [MessageBodyMember(Name = "NewX_AVM-DE_DSLDiagnoseState")]
        public string DSLDiagnoseState { get; set; }

        [MessageBodyMember(Name = "NewX_AVM-DE_CableNokDistance")]
        public int CableNokDistance { get; set; }

        [MessageBodyMember(Name = "NewX_AVM-DE_DSLLastDiagnoseTime")]
        public uint DSLLastDiagnoseTime { get; set; }

        [MessageBodyMember(Name = "NewX_AVM-DE_DSLSignalLossTime ")]
        public uint DSLSignalLossTime { get; set; }

        [MessageBodyMember(Name = "NewX_AVM-DE_DSLActive")]
        public bool DSLActive { get; set; }

        [MessageBodyMember(Name = "NewX_AVM-DE_DSLSync")]
        public bool DSLSync { get; set; }

        public string? Status
        {
            get
            {
                if (DSLDiagnoseState == "NONE" && CableNokDistance == -1 && DSLLastDiagnoseTime == 0 && DSLSignalLossTime == 0 && DSLActive && DSLSync)
                    return "The DSL connection is ready for data traffic. The Customer Premises Equipment (CPE) has set DSL to Active and the DSL chip could sync to ISP destination device.";

                if (DSLDiagnoseState == "NONE" && CableNokDistance == -1 && DSLLastDiagnoseTime == 0 && DSLSignalLossTime > 0 && DSLSignalLossTime < 300 && DSLActive && !DSLSync)
                    return "The Customer Premises Equipment (CPE) Device has lost the sync state since DSLSignalLossTime(in seconds).";

                if (DSLDiagnoseState == "RUNNING" && CableNokDistance == -1 && DSLLastDiagnoseTime == 0 && DSLSignalLossTime > 300 && DSLActive && !DSLSync)
                    return "5 minutes passed since the last DSLSync = 1, the Customer Premises Equipment (CPE) device is now instantiating a cable cut measurement. While the diagnose is running the DSLDiagnoseState is set to 'RUNNING'.";

                if (DSLDiagnoseState == "NO_CALIB" && CableNokDistance == -1 && DSLLastDiagnoseTime == 0 && DSLSignalLossTime > 300 && DSLActive && !DSLSync)
                    return "The Customer Premises Equipment (CPE) has tried to start a cable cut measurement, but could not initiate the measurement.Therefore no calibration has passed.";

                if (DSLDiagnoseState == "DONE_CABLE_OK" && CableNokDistance == -1 && DSLLastDiagnoseTime > 0 && DSLSignalLossTime > 300 && DSLActive && !DSLSync)
                    return "The cable cut measurement is finished and no cable cut could be detected.";

                if (DSLDiagnoseState == "DONE_CABLE_NOK" && CableNokDistance > 0 && DSLLastDiagnoseTime > 0 && DSLSignalLossTime > 300 && DSLActive && !DSLSync)
                    return FormattableString.Invariant($"The cable cut measurement is finished and a problem with the cable connection could be detected at {CableNokDistance} meters.");

                if (DSLDiagnoseState == "DONE_CABLE_OK" && CableNokDistance == -1 && DSLLastDiagnoseTime > 0 && DSLSignalLossTime > 300 && DSLActive && !DSLSync)
                    return "The measurement for cable cut is finished but the distance could not be detected or is too inaccurate.";

                if (DSLDiagnoseState == "NONE" && CableNokDistance == -1 && DSLLastDiagnoseTime > 0 && DSLSignalLossTime == 0 && DSLActive && DSLSync)
                    return "When the DSL signal is sync again, all values will be set to default values. Except the DSLLastDiagnoseTime which remains at the value of time in seconds between the last measurement and the resync.";

                return null;
            }
        }
    }
}