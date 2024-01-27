import {ItemCategoryType} from './ItemCategoryType';

export interface IItemCategoryTypePagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: ItemCategoryType[];
}

export class ItemCategoryTypePagination implements IItemCategoryTypePagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: ItemCategoryType[] = [];


}
