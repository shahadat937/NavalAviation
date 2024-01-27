import {Manufacture} from './Manufacture';

export interface IManufacturePagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: Manufacture[];
}

export class ManufacturePagination implements IManufacturePagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: Manufacture[] = [];


}
