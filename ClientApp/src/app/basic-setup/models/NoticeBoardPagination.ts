import {NoticeBoard} from './NoticeBoard';

export interface INoticeBoardPagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: NoticeBoard[];
}

export class NoticeBoardPagination implements INoticeBoardPagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: NoticeBoard[] = [];
}
