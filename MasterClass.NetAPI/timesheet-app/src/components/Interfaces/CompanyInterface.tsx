import { User } from "./UserInterface";

export interface Company {
    id: number;
    name: string;
    users: User[];
}