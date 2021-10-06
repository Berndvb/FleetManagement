using System;

namespace FleetManagement.Framework.Models.Enums
{
    [Flags]
    public enum DriversLicenseTypes
    {
        AM = 1,
        A = 2,
        B = 4,
        C = 8,
        D = 16,
        G = 32,
        All = (AM | A | B | C | D | G)
    }
}
