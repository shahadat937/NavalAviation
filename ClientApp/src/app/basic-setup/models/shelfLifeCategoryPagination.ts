import {ShelfLifeCategory} from './shelfLifeCategory';

export interface IShelfLifeCategoryPagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: ShelfLifeCategory[];
}

export class ShelfLifeCategoryPagination implements IShelfLifeCategoryPagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: ShelfLifeCategory[] = [];


}
