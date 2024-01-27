import {ItemDetail} from './itemDetail';

export interface IItemDetailPagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: ItemDetail[];
}

export class ItemDetailPagination implements IItemDetailPagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: ItemDetail[] = [];


}
