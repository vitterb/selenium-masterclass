import React, { useEffect, useState } from "react";
import axios from "axios";
import { AddUserFormProps } from "../Interfaces/AddUserFormProps";
import { Company } from "../Interfaces/CompanyInterface";
import { fetchCompanies } from "../Services/apiCall";


function AddUserForm({ onUserAdded }: AddUserFormProps) {
    const [userName, setUserName] = useState("");
    const [companyId, setCompanyId] = useState("");
    const [companies, setCompanies] = useState<Company[]>([]);

    useEffect(() => {
        fetchCompanies(setCompanies);
    }, []);

    const handleSubmit = async (e: React.FormEvent) => {
        e.preventDefault();

        try {
            const response = await axios.post("https://localhost:7118/api/users", {
                name: userName,
                companyId: parseInt(companyId),
            });

            console.log("User added successfully:", response.data);

            setUserName("");
            setCompanyId("");

            onUserAdded(response.data);
        } catch (error) {
            console.error("Error adding user:", error);
        }
    };

    return (
        <div>
            <h2 className="title is-4 tag is-info is-light">Add User</h2>
            <form onSubmit={handleSubmit}>
                <table>
                    <tbody>
                        <tr>
                            <td>
                                <label className="title is-5" htmlFor="userName">User Name:</label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <input
                                    type="text"
                                    id="userName"
                                    value={userName}
                                    onChange={(e) => setUserName(e.target.value)}
                                    required
                                    style={{ backgroundColor: 'lightblue', color: 'black' }}
                                />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label className="title is-5" htmlFor="companyId">Company: </label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <select
                                    id="companyId"
                                    value={companyId}
                                    onChange={(e) => setCompanyId(e.target.value)}
                                    required
                                    style={{ backgroundColor: "lightblue", color: "black" }}
                                >
                                    <option value="" disabled>
                                        Select a company
                                    </option>
                                    {companies.map((company) => (
                                        <option key={company.id} value={company.id}>
                                            {company.name}
                                        </option>
                                    ))}
                                </select>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <button className="button is-primary" type="submit">Add User</button>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </form>
        </div>
    );
}

export default AddUserForm;
