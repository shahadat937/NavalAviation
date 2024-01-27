import {NameofPublication} from './NameofPublication';

export interface INameofPublicationPagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: NameofPublication[];
}

export class NameofPublicationPagination implements INameofPublicationPagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: NameofPublication[] = [];


}
