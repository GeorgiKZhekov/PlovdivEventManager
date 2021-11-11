namespace PlovdivEventManager.Data
{
    public class DataConstants
    {
        public class Event
        {
            public const int NameMaxLength = 30;
            public const int NameMinLength = 3;
            public const int DescriptionMaxLength = 200;
            public const int DescriptionMinValue = 30;
            public const string DateRegexValidation = @"^(0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])[- /.](19|20)\d\d$";
            public const string HourMinutesRegexValidation = @"^([0-1]?[0-9]|2[0-3]):[0-5][0-9]$";
            public const int DateMaxLength = 10;
            public const int TimeMaxLength = 5;
            public const int AddressMaxLength = 50;
        }

        public class Category
        {
            public const int NameMaxLength = 25;
        }

        public class Organizer
        {
            public const int NameMinLength = 3;
            public const int NameMaxLength = 25;
            public const int CompanyNameMinLength = 2;
            public const int CompanyNameMaxLength = 35;         
            public const int PhoneNumberMinLength = 10;
            public const int PhoneNumberMaxLength = 13;
            public const string PhoneNumberRegexValidation = @"^((\+359)|(0)){1}(8){1}[1-9]{1}\d{7}$";
        }
        
    }
}
