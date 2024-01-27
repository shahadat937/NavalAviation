import {ItemCategory} from './ItemCategory';

export interface IItemCategoryPagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: ItemCategory[];
}

export class ItemCategoryPagination implements IItemCategoryPagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: ItemCategory[] = [];
}
