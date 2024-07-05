import axios from 'axios';
import { Employee } from '../components/Interfaces/EmployeeInterface';

export const fetchEmployees = (
    setEmployees: React.Dispatch<React.SetStateAction<Employee[]>>
): Promise<void> => {
    return axios
        .get<Employee[]>("http://localhost:5292/api/Employees")
        .then((userResponse) => {
            setEmployees(userResponse.data);
        })
        .catch((error) => {
            console.error("Error fetching users:", error);
        });
};
