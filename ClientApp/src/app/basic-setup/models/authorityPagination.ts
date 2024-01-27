import {Authority} from './authority';

export interface IAuthorityPagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: Authority[];
}

export class AuthorityPagination implements IAuthorityPagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: Authority[] = [];


}
