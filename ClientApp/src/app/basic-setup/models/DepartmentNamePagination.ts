import {DepartmentName} from './DepartmentName';

export interface IDepartmentNamePagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: DepartmentName[];
}

export class DepartmentNamePagination implements IDepartmentNamePagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: DepartmentName[] = [];


}
