import {ItemStatus} from './ItemStatus';

export interface IItemStatusPagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: ItemStatus[];
}

export class ItemStatusPagination implements IItemStatusPagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: ItemStatus[] = [];


}
