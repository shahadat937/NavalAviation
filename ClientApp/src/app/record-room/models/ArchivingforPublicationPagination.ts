import {ArchivingforPublication} from './ArchivingforPublication';

export interface IArchivingforPublicationPagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: ArchivingforPublication[];
}

export class ArchivingforPublicationPagination implements IArchivingforPublicationPagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: ArchivingforPublication[] = [];


}
