import {Trade} from './Trade';

export interface ITradePagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: Trade[];
}

export class TradePagination implements ITradePagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: Trade[] = [];


}
