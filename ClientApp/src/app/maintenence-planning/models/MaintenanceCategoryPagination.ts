import {MaintenanceCategory} from './MaintenanceCategory';

export interface IMaintenanceCategoryPagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: MaintenanceCategory[];
}

export class MaintenanceCategoryPagination implements IMaintenanceCategoryPagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: MaintenanceCategory[] = [];


}
