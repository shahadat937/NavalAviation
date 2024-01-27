import {MaintenanceType} from './MaintenanceType';

export interface IMaintenanceTypePagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: MaintenanceType[];
}

export class MaintenanceTypePagination implements IMaintenanceTypePagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: MaintenanceType[] = [];


}
