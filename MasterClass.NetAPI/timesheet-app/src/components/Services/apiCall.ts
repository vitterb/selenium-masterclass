import axios from 'axios';
import { User } from "../Interfaces/UserInterface"
import { TimeRegistration } from '../Interfaces/TimeRegistrationInterface';
import { Company } from '../Interfaces/CompanyInterface';

export const fetchAllData = (
    setCompanies: React.Dispatch<React.SetStateAction<Company[]>>,
    setUsers: React.Dispatch<React.SetStateAction<User[]>>,
    setTimeRegistrations: React.Dispatch<React.SetStateAction<TimeRegistration[]>>
) => {
    axios
        .get<Company[]>("https://localhost:7118/api/companies")
        .then((response) => {
            setCompanies(response.data);
            return axios.get<User[]>("https://localhost:7118/api/users");
        })
        .then((userResponse) => {
            setUsers(userResponse.data);
            return axios.get<TimeRegistration[]>("https://localhost:7118/api/timeRegistrations");
        })
        .then((timeRegistrationResponse) => {
            setTimeRegistrations(timeRegistrationResponse.data);
        })
        .catch((error) => {
            console.error("Error fetching data:", error);
        });
};

export const fetchUserAndTimeRegistrationData = (
    setUsers: React.Dispatch<React.SetStateAction<User[]>>,
    setTimeRegistrations: React.Dispatch<React.SetStateAction<TimeRegistration[]>>
) => {
    axios
        .get<User[]>("https://localhost:7118/api/users")
        .then((userResponse) => {
            setUsers(userResponse.data);
            return axios.get<TimeRegistration[]>("https://localhost:7118/api/timeRegistrations");
        })
        .then((timeRegistrationResponse) => {
            setTimeRegistrations(timeRegistrationResponse.data);
        })
        .catch((error) => {
            console.error("Error fetching user and time registration data:", error);
        });
};

export const fetchUsersAndCompanies = (
    setUsers: React.Dispatch<React.SetStateAction<User[]>>,
    setCompanies: React.Dispatch<React.SetStateAction<Company[]>>
) => {
    axios
        .get<User[]>("https://localhost:7118/api/users")
        .then((userResponse) => {
            setUsers(userResponse.data);
            return axios.get<Company[]>("https://localhost:7118/api/companies");
        })
        .then((companyResponse) => {
            setCompanies(companyResponse.data);
        })
        .catch((error) => {
            console.error("Error fetching users and companies:", error);
        });
};


export const fetchTimeRegistrations = (
    setTimeRegistrations: React.Dispatch<React.SetStateAction<TimeRegistration[]>>
) => {
    axios
        .get<TimeRegistration[]>("https://localhost:7118/api/timeRegistrations")
        .then((timeRegistrationResponse) => {
            setTimeRegistrations(timeRegistrationResponse.data);
        })
        .catch((error) => {
            console.error("Error fetching time registrations:", error);
        });
};

export const fetchCompanies = (
    setCompanies: React.Dispatch<React.SetStateAction<Company[]>>
) => {
    axios
        .get<Company[]>("https://localhost:7118/api/companies")
        .then((companyResponse) => {
            setCompanies(companyResponse.data);
        })
        .catch((error) => {
            console.error("Error fetching Companies:", error);
        });
};

export const fetchUsers = (
    setUsers: React.Dispatch<React.SetStateAction<User[]>>
) => {
    axios
        .get<User[]>("https://localhost:7118/api/users")
        .then((userResponse) => {
            setUsers(userResponse.data);
        })
        .catch((error) => {
            console.error("Error fetching users:", error);
        });
};







