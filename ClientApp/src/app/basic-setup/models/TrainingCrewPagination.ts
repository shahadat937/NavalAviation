import {TrainingCrew} from './TrainingCrew';

export interface ITrainingCrewPagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: TrainingCrew[];
}

export class TrainingCrewPagination implements ITrainingCrewPagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: TrainingCrew[] = [];


}
