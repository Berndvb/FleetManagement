import { IError } from "./ierror";
import { IExecutionpaging } from "./iexecutionpaging";
import { IWarning } from "./iwarning";

export interface ISingleResponse<TType> {
    items: TType;
    errors: IError[]
    warnings: IWarning[]
    executionPaging: IExecutionpaging,
    errorType: string,
    warningType: string,
    hasSucceeded: boolean,
    hasWarnings: boolean,
    hasPaging: boolean
}