using System;

namespace FleetManagement.Framework.Constants
{
    public class Constants
    {
        public static class ErrorCodes
        {
            public const string InvalidRequestInput = "E001";
            public const string DataNotFound = "E002";
            public const string IdNotUnique = "E003";
            public const string IdNotFound = "E004";
            public const string MoreThanOneActiveRelation = "E005";
        }

        public static class WarningCodes
        {
            public const string NoData = "E001";
        }

        public static class Info
        {
            public const string StartAllPhi = "20110812";
        }

        public static class Json
        {
            public const string DefaultCulture = "en-US";

            public const string DefaultDateTimeFormat = "yyyy-MM-ddTHH:mm:ssZ"; //
        }

        public static class Env
        {
            public const string IntegrationTesting = "integrationtesting";
            public const string UnitTesting = "unittesting";
        }
    }
}
