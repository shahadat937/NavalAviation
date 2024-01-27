import {Demand} from './Demand';

export interface IDemandPagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: Demand[];
}

export class DemandPagination implements IDemandPagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: Demand[] = [];


}
