import {LifeLimitItemRunningHour} from './LifeLimitItemRunningHour';

export interface ILifeLimitItemRunningHourPagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: LifeLimitItemRunningHour[];
}

export class LifeLimitItemRunningHourPagination implements ILifeLimitItemRunningHourPagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: LifeLimitItemRunningHour[] = [];


}
