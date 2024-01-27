import {ItemType} from './ItemType';

export interface IItemTypePagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: ItemType[];
}

export class ItemTypePagination implements IItemTypePagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: ItemType[] = [];


}
