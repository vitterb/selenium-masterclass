import { Registration } from "./RegistrationInterface";

export interface Timesheet {
    id: number;
    year: number;
    month: number;
    registrations: Registration[];
}