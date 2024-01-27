import {MaintenanceSubCategory} from './maintenanceSubCategory';

export interface IMaintenanceSubCategoryPagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: MaintenanceSubCategory[];
}

export class MaintenanceSubCategoryPagination implements IMaintenanceSubCategoryPagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: MaintenanceSubCategory[] = [];


}
