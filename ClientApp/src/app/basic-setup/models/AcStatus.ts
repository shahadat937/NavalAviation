export interface AcStatus {
    acStatusId: number,
    airCraftNameId:number,
    departmentNameId:number,
    statusId:number;
    excepRelease: string,
    upcomingMaint: string,
    plannedDate: Date,
    requiredDays: string,
    remarks: string,
 isActive: boolean
   
}