import {GseMaintenance} from './GseMaintenance';

export interface IGseMaintenancePagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: GseMaintenance[];
}

export class GseMaintenancePagination implements IGseMaintenancePagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: GseMaintenance[] = [];


}
