export interface NoticeBoard {
    noticeBoardId:number,
    departmentNameId:number,
    departmentName: string,
    date: Date,
    event: string,
    orderBy: string,
    remarks: string,
    noticeDocument: string,
    isActive: boolean
}