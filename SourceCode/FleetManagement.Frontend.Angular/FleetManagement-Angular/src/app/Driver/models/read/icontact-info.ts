import { IAddress } from "./iaddress";

export interface IContactInfo {
    contactInfoId: number;
    emailAddress: string;
    phoneNumber: string;
    address: IAddress;
}
