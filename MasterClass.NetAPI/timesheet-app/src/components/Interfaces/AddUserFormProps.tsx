import { User } from "./UserInterface";

export interface AddUserFormProps {
    onUserAdded: (user: User) => void;
}