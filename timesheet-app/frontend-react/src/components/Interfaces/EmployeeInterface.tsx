import { Timesheet } from "./TimesheetInterface";


export interface Employee {
    id: string;
    firstName: string;
    lastName: string;
    email: string;
    role: string;
    timesheets: Timesheet[]; 
}

