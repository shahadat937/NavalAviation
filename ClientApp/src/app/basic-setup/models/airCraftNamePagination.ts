import {AirCraftName} from './airCraftName';

export interface IAirCraftNamePagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: AirCraftName[];
}

export class AirCraftNamePagination implements IAirCraftNamePagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: AirCraftName[] = [];


}
