import { TimeRegistration } from "./TimeRegistrationInterface";

export interface User {
    id: number;
    companyId: number;
    name: string;
    timeRegistrations: TimeRegistration[];
}