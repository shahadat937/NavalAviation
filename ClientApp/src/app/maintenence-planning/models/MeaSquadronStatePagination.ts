import {MeaSquadronState} from './MeaSquadronState';

export interface IMeaSquadronStatePagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: MeaSquadronState[];
}

export class MeaSquadronStatePagination implements IMeaSquadronStatePagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: MeaSquadronState[] = [];


}
