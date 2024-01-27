import {AirCraftFlying} from './AirCraftFlying';

export interface IAirCraftFlyingPagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: AirCraftFlying[];
}

export class AirCraftFlyingPagination implements IAirCraftFlyingPagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: AirCraftFlying[] = [];


}
