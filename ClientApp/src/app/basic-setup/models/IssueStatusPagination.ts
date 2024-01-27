import {IssueStatus} from './IssueStatus';

export interface IIssueStatusPagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: IssueStatus[];
}

export class IssueStatusPagination implements IIssueStatusPagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: IssueStatus[] = [];


}
