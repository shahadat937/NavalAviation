import {ItemStor} from './ItemStor';

export interface IItemStorPagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: ItemStor[];
}

export class ItemStorPagination implements IItemStorPagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: ItemStor[] = [];


}
