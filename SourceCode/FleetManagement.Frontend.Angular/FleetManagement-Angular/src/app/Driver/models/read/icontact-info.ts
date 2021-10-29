import { IAddress } from "./iaddress";

export interface IContactInfo {
    id: number;
    emailAddress: string;
    phoneNumber: string;
    address: IAddress;
}
