export interface IssueRegister {
    issueRegisterId: number;
    itemStoreId: number;
    departmentNameId: number;
    itemDetailId:number;
    issueStatusId: number;
    trainingCrewId:number;
    totalReceivedQty:number;
    issueQty: number;
    issueDate:Date;
    lastMaintenanceDate:number;
    lastCalibrationDate:number;
    issuedTo:string;
    reason: string;
    isRefundable: boolean;
    availableQtyBeforeIssue:number;
    availableQtyAfterIssue:number;
    receivedPerson:string;
    remarks:string;
    status:number;
    isActive: boolean;
   
}