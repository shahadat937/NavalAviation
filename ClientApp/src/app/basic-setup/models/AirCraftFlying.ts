export interface AirCraftFlying {
    airCraftFlyingId: number,
    airCraftNameId: number,
    departmentNameId: number,
    date:Date,
    typeOfAC:string,
    acNo:string,
    crew:string,
    callSign:string,
    mon:string,
    startUp:string,
    dup:string,
    endurance:string,
    fuel:string,
    opaOff:string,
    pdf:string,
    startupPlanned:string,
    landingTimePlanned:string,
    duration:string;
    remarks:string,
    isActive: boolean,
    startUpStatus:number,
    startUpDelay:string
}