import {FiscalYear} from './FiscalYear';

export interface IFiscalYearPagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: FiscalYear[];
}

export class FiscalYearPagination implements IFiscalYearPagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: FiscalYear[] = [];


}
