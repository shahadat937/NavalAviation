import {PrincipalName} from './PrincipalName';

export interface IPrincipalNamePagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: PrincipalName[];
}

export class PrincipalNamePagination implements IPrincipalNamePagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: PrincipalName[] = [];


}
