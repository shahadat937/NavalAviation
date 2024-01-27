import {Supplier} from './Supplier';

export interface ISupplierPagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: Supplier[];
}

export class SupplierPagination implements ISupplierPagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: Supplier[] = [];


}
