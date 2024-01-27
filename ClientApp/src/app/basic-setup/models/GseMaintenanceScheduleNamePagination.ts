import {GseMaintenanceScheduleName} from './GseMaintenanceScheduleName';

export interface IGseMaintenanceScheduleNamePagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: GseMaintenanceScheduleName[];
}

export class GseMaintenanceScheduleNamePagination implements IGseMaintenanceScheduleNamePagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: GseMaintenanceScheduleName[] = [];


}
