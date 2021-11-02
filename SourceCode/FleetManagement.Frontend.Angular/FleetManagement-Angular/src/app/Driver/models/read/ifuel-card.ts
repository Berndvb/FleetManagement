import { IFuelCardDriver } from "./ifuel-card-driver";
import { IFuelCardOptions } from "./ifuel-card-options";

export interface IFuelCard {
    id: number;
    cardNumber: string;
    expirationDate: Date;
    pincode: string;
    authenticationType: string;
    blocked: boolean;
    fuelCardOptions: IFuelCardOptions;
    fuelCardDrivers: IFuelCardDriver[];
}