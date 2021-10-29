import { IContactInfo } from "./icontact-info";
import { IIdentityPerson } from "./iidentity-person";

export interface IDriverDetails {
    driverId: number;
    identityPerson: IIdentityPerson;
    contactInfo: IContactInfo;
    driversLicenceType: string;
    inService: boolean;
}
