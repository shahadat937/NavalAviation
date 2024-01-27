import {AllDocument} from './AllDocument';

export interface IAllDocumentPagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: AllDocument[];
}

export class AllDocumentPagination implements IAllDocumentPagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: AllDocument[] = [];


}
