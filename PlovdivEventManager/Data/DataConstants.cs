namespace PlovdivEventManager.Data
{
    public class DataConstants
    {
        public const int EventNameMaxLength = 30;
        public const int EventNameMinLength = 3;
        public const int EventDescriptionMaxLength = 200;
        public const int EventDescriptionMinValue = 30;
        public const string DateRegexValidation = @"^(0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])[- /.](19|20)\d\d$";
        public const string HourMinutesRegexValidation = @"^([0-1]?[0-9]|2[0-3]):[0-5][0-9]$";
        public const int DateMaxLength = 10;
        public const int TimeMaxLength = 5;
        public const int AddressMaxLength = 50;
    }
}
