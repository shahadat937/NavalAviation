import {IssueRegister} from './IssueRegister';

export interface IIssueRegisterPagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: IssueRegister[];
}

export class IssueRegisterPagination implements IIssueRegisterPagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: IssueRegister[] = [];


}
