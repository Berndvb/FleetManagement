import { IFile } from "./ifile";
import { IGarage } from "./igarage";
import { IVehicleOverview } from "./ivehicle-overview";

export interface IAdministration {
    administrationId: number;
    vehicle: IVehicleOverview;
    creationDate: Date;
    invoiceDate?: Date;
    price: number;
    garage: IGarage;
    documents: IFile[];
}
