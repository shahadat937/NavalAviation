export interface CallibrationState {
    callibrationStateId: number;
    itemDetailId: number;
    departmentNameId: number;
    tradeId:number;
    serNo:string;
    itemName:string;
    lastDateofCalibrated:Date;
    nextDueDate:Date;
    presentState:string;
    remarks:string;
    isActive: boolean;
   
}