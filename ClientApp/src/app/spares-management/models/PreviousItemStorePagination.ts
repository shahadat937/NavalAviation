import {PreviousItemStore} from './PreviousItemStore';

export interface IPreviousItemStorePagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: PreviousItemStore[];
}

export class PreviousItemStorePagination implements IPreviousItemStorePagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: PreviousItemStore[] = [];


}
