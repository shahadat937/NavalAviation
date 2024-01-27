export interface MaintenanceSchedule {
    maintenanceScheduleId: number;
    maintenancePlanningId: number;
    airCraftNameId: number;
    slNo: string;
    maintenanceTypeId: number;
    maintenanceCategoryId: number;
    maintenanceSubCategoryId: number;
    maintenancePlanningStatusId: number;
    inspCompleteStatus: number;
    departmentNameId: number;
    startInspDate: Date;
    endInspDate:Date;
    allowedExtension:string;
    extensionGiven: string;
    extensionDay:string;
    requiredDay: string;
    maintenanceDocument:string;
    extensionDocument: string;
    othersDocument:string;
    jobListDocument: string;
    requiredSpearsDoc:string;
    requiredToolsDoc: string;
    requiredConsumablesDoc:string;
    toleranceDocument: string;
    remarks:string;
    isActive: boolean;
    //extensionGiven:
    lastInspectiobFh: string;
    lastInspectiobOh: string;
   
}