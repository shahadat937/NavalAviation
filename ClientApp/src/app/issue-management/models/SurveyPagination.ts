import {Survey} from './Survey';

export interface ISurveyPagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: Survey[];
}

export class SurveyPagination implements ISurveyPagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: Survey[] = [];


}
