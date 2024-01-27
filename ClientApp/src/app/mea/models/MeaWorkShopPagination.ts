import {MeaWorkShop} from './MeaWorkShop';

export interface IMeaWorkShopPagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: MeaWorkShop[];
}

export class MeaWorkShopPagination implements IMeaWorkShopPagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: MeaWorkShop[] = [];


}
