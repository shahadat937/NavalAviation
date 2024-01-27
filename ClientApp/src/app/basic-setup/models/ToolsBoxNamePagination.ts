import {ToolsBoxName} from './ToolsBoxName';

export interface IToolsBoxNamePagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: ToolsBoxName[];
}

export class ToolsBoxNamePagination implements IToolsBoxNamePagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: ToolsBoxName[] = [];
}
