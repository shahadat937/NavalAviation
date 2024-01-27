import {RequiredSparesForMaintenance} from './RequiredSparesForMaintenance';

export interface IRequiredSparesForMaintenancePagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: RequiredSparesForMaintenance[];
}

export class RequiredSparesForMaintenancePagination implements IRequiredSparesForMaintenancePagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: RequiredSparesForMaintenance[] = [];


}
