import {StockTransferNsd} from './StockTransferNsd';

export interface IStockTransferNsdPagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: StockTransferNsd[];
}

export class StockTransferNsdPagination implements IStockTransferNsdPagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: StockTransferNsd[] = [];


}
