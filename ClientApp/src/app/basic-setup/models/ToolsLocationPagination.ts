import {ToolsLocation} from './ToolsLocation';

export interface IToolsLocationPagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: ToolsLocation[];
}

export class ToolsLocationPagination implements IToolsLocationPagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: ToolsLocation[] = [];
}
