// Companies.tsx
import { useEffect, useState } from "react";
import axios from "axios";
import { Company } from "./Interfaces/CompanyInterface";
import AddCompanyForm from "./Forms/AddCompanyForm";
import { User } from "./Interfaces/UserInterface";
import { TimeRegistration } from "./Interfaces/TimeRegistrationInterface";
import { fetchAllData } from "./Services/apiCall";
import { Link } from 'react-router-dom';

function Companies() {
    const [companies, setCompanies] = useState<Company[]>([]);
    const [users, setUsers] = useState<User[]>([]);
    const [timeRegistrations, setTimeRegistrations] = useState<TimeRegistration[]>([]);

    useEffect(() => {
        fetchAllData(setCompanies, setUsers, setTimeRegistrations);
    }, []);

    const handleCompanyAdded = (newCompany: Company) => {
        setCompanies((prevCompanies) => [...prevCompanies, newCompany]);
    };

    const handleDeleteCompany = async (companyId: number) => {
        try {
            await axios.delete(
                `https://localhost:7118/api/companies/${companyId}`
            );

            console.log(`Company with ID ${companyId} deleted successfully.`);

            setCompanies((prevCompanies) =>
                prevCompanies.filter((company) => company.id !== companyId)
            );
        } catch (error) {
            console.error(`Error deleting company with ID ${companyId}:`, error);
        }
    };

    return (
        <div className="frame">
            <nav>
                <button className="button is-primary">
                <Link to="/">Home</Link>
                </button>
                {(" ")}
                <button className="button is-primary">
                    <Link to="/users">Users</Link>
                </button>
                {(" ")}
                <button className="button is-primary">
                <Link to="/timeregistrations">Time Registrations</Link>
                </button>
            </nav>
            <h1 className="title is-1 tag is-info" id="title">Companies</h1>
            <ul>
                {companies.map((company) => (
                    <li key={company.id} className="box">
                        <div className="title is-3 CompanyName" >
                        {company.name}
                        </div>
                        <ul>
                            {users.filter((user) => user.companyId === company.id)
                                .map((user) => (
                                <li key={user.id}>
                                    <div className="title is-5 EmployeeName">
                                    <strong>{user.name}</strong>
                                    </div>
                                    <ul>
                                        {timeRegistrations.filter((timeRegistration) => timeRegistration.userId === user.id)
                                            .map((timeRegistration) => (
                                            <li key={timeRegistration.id}>
                                                <div className="title is-7">
                                                {timeRegistration.description} -{" "}
                                                {timeRegistration.start} to {timeRegistration.stop}
                                                </div>
                                            </li>
                                        ))}
                                        
                                    </ul>
                                </li>
                            ))}
                            <button className="button is-warning deleteButton" onClick={() => handleDeleteCompany(company.id)}>Delete</button>
                        </ul>
                    </li>
                ))}
            </ul>
            <AddCompanyForm onCompanyAdded={handleCompanyAdded} />
        </div>
    );
}

export default Companies;
