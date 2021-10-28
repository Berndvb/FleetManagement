import { IDriverOverview } from "./idriver-overview";
import { IVehicleOverview } from "./ivehicle-overview";

export interface IAppeal {
    appealId: number;
    creationDate: Date;
    appealType: string;
    firstDatePlanning: Date;
    secondDatePlanning: Date;
    status: string;
    vehicle: IVehicleOverview;
    driver: IDriverOverview;
    message: string;
}
