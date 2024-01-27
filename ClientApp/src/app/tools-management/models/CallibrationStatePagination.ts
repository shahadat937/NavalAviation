import {CallibrationState} from './CallibrationState';

export interface ICallibrationStatePagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: CallibrationState[];
}

export class CallibrationStatePagination implements ICallibrationStatePagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: CallibrationState[] = [];


}
