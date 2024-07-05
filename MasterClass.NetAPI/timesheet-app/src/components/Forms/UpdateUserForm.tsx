import React, { useEffect, useState } from 'react';
import axios from 'axios';
import { User } from '../Interfaces/UserInterface';
import { fetchCompanies } from '../Services/apiCall';
import { Company } from '../Interfaces/CompanyInterface';

interface UpdateUserFormProps {
    user: User;
    onUpdateUser: (updatedUser: User) => void;
    onCancelEdit: () => void;
}

function UpdateUserForm({ user, onUpdateUser, onCancelEdit }: UpdateUserFormProps) {
    const [editedUser, setEditedUser] = useState(user);
    const [companies,setCompanies] =useState<Company[]>([]);
    const [selectedCompanyId, setSelectedCompanyId] = useState(editedUser.companyId);

    useEffect(() =>{
        fetchCompanies(setCompanies);
    }, []);

    const handleSubmit = async (e: React.FormEvent) => {
        e.preventDefault();

        try {
            const response = await axios.put(
                `https://localhost:7118/api/users`,
                editedUser,
                {
                    headers: {
                        'Content-Type': 'application/json'
                    }
                }
            );

            console.log('User updated successfully:', response.data);

            onUpdateUser(response.data);
        } catch (error) {
            console.error('Error updating user:', error);
        }
    };

    const handleCompanyChange = (e: React.ChangeEvent<HTMLSelectElement>) => {
        const companyId = parseInt(e.target.value);
        setSelectedCompanyId(companyId);
        setEditedUser({ ...editedUser, companyId });
    };

    return (
        <div>
            <h2>Edit User</h2>
            <form onSubmit={handleSubmit}>
                <table>
                    <tbody>
                    <tr>
                        <td>
                            <label htmlFor="editedUserName">User Name:</label>
                        </td>
                        <td>
                            <input
                                type="text"
                                id="editedUserName"
                                value={editedUser.name}
                                onChange={(e) => setEditedUser({ ...editedUser, name: e.target.value })}
                                required
                            />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <label htmlFor="editedCompanyId">Company ID:</label>
                        </td>
                        <td>
                        <select
                                id="editedCompanyId"
                                value={selectedCompanyId}
                                onChange={handleCompanyChange}
                                required
                            >
                                <option value="" disabled>Select a company</option>
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
                            <button className='button is-warning' type="submit">Update User</button>
                        </td>
                        <td>
                            <button className='button is-success' type="button" onClick={onCancelEdit}>Cancel</button>
                        </td>
                    </tr>
                    </tbody>
                </table>
            </form>
        </div>
    );
}

export default UpdateUserForm;
