import {RunningHour} from './runningHour';

export interface IRunningHourPagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: RunningHour[];
}

export class RunningHourPagination implements IRunningHourPagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: RunningHour[] = [];


}
