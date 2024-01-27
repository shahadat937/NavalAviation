import {Store} from './store';

export interface IStorePagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: Store[];
}

export class StorePagination implements IStorePagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: Store[] = [];


}
