import React, { useState } from "react";
import axios from "axios";
import { AddCompanyFormProps } from "../Interfaces/AddCompanyFormProps";



function AddCompanyForm({ onCompanyAdded }: AddCompanyFormProps) {
    const [companyName, setCompanyName] = useState("");

    const handleSubmit = async (e: React.FormEvent) => {
        e.preventDefault();

        try {
            const response = await axios.post("https://localhost:7118/api/companies", {
                name: companyName,
            });

            console.log("Company added successfully:", response.data);

            setCompanyName("");

            onCompanyAdded(response.data);
        } catch (error) {
            console.error("Error adding company:", error);
        }
    };

    return (
        <div>
            <h2 className="title is-4">Add Company</h2>
            <form onSubmit={handleSubmit}>
                <table>
                    <tbody>
                        <tr>
                            <td>
                                <label htmlFor="companyName">Company Name:</label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <input
                                    type="text"
                                    id="companyName"
                                    value={companyName}
                                    onChange={(e) => setCompanyName(e.target.value)}
                                    required
                                    style={{ backgroundColor:'lightblue', color:'black' }}
                                />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <button className="button is-primary" type="submit" id="addCompany">Add Company</button>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </form>
        </div>
    );
}

export default AddCompanyForm;
