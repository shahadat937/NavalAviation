import {GseScheduleWorkType} from './GseScheduleWorkType';

export interface IGseScheduleWorkTypePagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: GseScheduleWorkType[];
}

export class GseScheduleWorkTypePagination implements IGseScheduleWorkTypePagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: GseScheduleWorkType[] = [];


}
