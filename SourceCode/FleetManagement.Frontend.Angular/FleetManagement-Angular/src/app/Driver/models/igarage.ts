import { IContactInfo } from "./icontact-info";

export interface IGarage {
    garageId: number;
    name: string;
    contactInfo: IContactInfo;
    companyNumber: string;
    bankAccountNumber: string;
}
