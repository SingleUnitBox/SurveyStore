using SurveyStore.Modules.Calibrations.Domain.Exceptions;

namespace SurveyStore.Modules.Calibrations.Domain.ValueObjects
{
    public record CertificateNumber
    {
        public string Value { get; }

        public CertificateNumber(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new EmptyCertificateNumberException();
            }
        }

        public static implicit operator string(CertificateNumber certificateNumber) => certificateNumber.Value;
        public static implicit operator CertificateNumber(string value) => new CertificateNumber(value);
    }
}
