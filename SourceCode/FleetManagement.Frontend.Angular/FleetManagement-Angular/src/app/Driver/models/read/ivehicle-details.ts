import { IAppeal } from "./iappeal";
import { IDriverVehicle } from "./idriver-vehicle";
import { IIdentityVehicle } from "./iidentity-vehicle";
import { IMaintenance } from "./imaintenance";
import { IRepare } from "./irepare";

export interface IVehicleDetails {
    id: number;
    identity: IIdentityVehicle;
    mileage: number[];
    maintenance: IMaintenance[];
    reparations: IRepare[];
    driverVehicles: IDriverVehicle[];
    appeals: IAppeal[];
}
