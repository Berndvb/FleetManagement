import { IContactInfo } from "./icontact-info";
import { IIdentityPerson } from "./iidentity-person";

export interface IDriverDetails {
    id: number;
    identity: IIdentityPerson;
    contactinfo: IContactInfo;
    driversLicenseType: string;
    inService: boolean;
}
