import {LifeLimitItem} from './LifeLimitItem';

export interface ILifeLimitItemPagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: LifeLimitItem[];
}

export class LifeLimitItemPagination implements ILifeLimitItemPagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: LifeLimitItem[] = [];


}
