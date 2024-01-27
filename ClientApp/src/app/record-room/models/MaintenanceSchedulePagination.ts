import {MaintenanceSchedule} from './MaintenanceSchedule';

export interface IMaintenanceSchedulePagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: MaintenanceSchedule[];
}

export class MaintenanceSchedulePagination implements IMaintenanceSchedulePagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: MaintenanceSchedule[] = [];


}
