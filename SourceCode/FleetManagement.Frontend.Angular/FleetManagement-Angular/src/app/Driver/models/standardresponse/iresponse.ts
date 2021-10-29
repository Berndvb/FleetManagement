import { IError } from "./ierror";
import { IExecutionpaging } from "./iexecutionpaging";
import { IWarning } from "./iwarning";

export interface IResponse<TType> { //being lazy: needs to be generic without generating the same list x3
    appeals: TType[];
    vehicleDetails: TType[];
    fuelCards: TType[];
    errors: IError[]
    warnings: IWarning[]
    executionPaging: IExecutionpaging,
    errorType: string,
    warningType: string,
    hasSucceeded: boolean,
    hasWarnings: boolean,
    hasPaging: boolean
}
