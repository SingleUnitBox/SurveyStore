using System.Text.Json.Serialization;

namespace SurveyStore.Modules.Calibrations.Domain.Types
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum CalibrationStatus
    {
        ToBeReturnForCalibration,
        InCalibration,
        Calibrated,
        Uncalibrated,
        Pending
    }
}
