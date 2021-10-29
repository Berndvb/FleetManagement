export interface ICreateAppeal {
    creationDate: Date,
    appealType: string,
    firstDatePlanning: Date,
    secondDatePlanning: Date,
    status: string,
    vehicleId: number,
    driverId: number,
    incidentDate: Date,
    damageDescription: string,
    vehicleLocation: string,
    message: string
}
