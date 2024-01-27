import {MaintenancePlanning} from './MaintenancePlanning';

export interface IMaintenancePlanningPagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: MaintenancePlanning[];
}

export class MaintenancePlanningPagination implements IMaintenancePlanningPagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: MaintenancePlanning[] = [];


}
