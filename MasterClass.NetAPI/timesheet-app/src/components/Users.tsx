import { useEffect, useState } from "react";
import axios from "axios";
import { User } from "./Interfaces/UserInterface";
import { Company } from "./Interfaces/CompanyInterface";
import AddUserForm from "./Forms/AddUserForm";
import UpdateUserForm from "./Forms/UpdateUserForm";
import { fetchUsersAndCompanies } from "./Services/apiCall";
import { Link } from "react-router-dom";

function Users() {
    const [companies, setCompanies] = useState<Company[]>([]);
    const [users, setUsers] = useState<User[]>([]);
    const [editingUserId, setEditingUserId] = useState<number | null>(null);

    const handleAddUser = (newUser: User) => {
        setUsers((prevUsers) => [...prevUsers, newUser]);
    };

    useEffect(() => {
        fetchUsersAndCompanies(setUsers, setCompanies);
    }, []);

    const getCompanyName = (companyId: number): string => {
        const company = companies.find((c) => c.id === companyId);
        return company ? company.name : "Unknown Company";
    };

    const handleDeleteUser = async (userId: number) => {
        try {
            await axios.delete(
                `https://localhost:7118/api/users/${userId}`
            );

            console.log(`User with ID ${userId} deleted successfully.`);

            setUsers((prevUsers) => prevUsers.filter((user) => user.id !== userId));
        } catch (error) {
            console.error(`Error deleting user with ID ${userId}:`, error);
        }
    };

    const handleEditUser = (userId: number) => {
        setEditingUserId(userId);
    };

    const handleCancelEdit = () => {
        setEditingUserId(null);
    };

    const handleUpdateUser = (updatedUser: User) => {
        setUsers((prevUsers) =>
            prevUsers.map((user) => (user.id === updatedUser.id ? updatedUser : user))
        );

        setEditingUserId(null);
    };

    return (
        <div className="frame">
            <nav>
                <button className="button is-primary">
                    <Link to="/">Home</Link>
                </button>
                {(" ")}
                <button className="button is-primary">
                    <Link to="/companies">Companies</Link>
                </button>
                {(" ")}
                <button className="button is-primary">
                    <Link to="/timeregistrations">Time Registrations</Link>
                </button>
            </nav>
            <div className="box">
                <h1 className="title is-1 tag is-info" id="title">Users</h1>
                <ul>
                    {users.map((user) => (
                        <li key={user.id}>
                            <table>
                                <tbody>
                                    {editingUserId === user.id ? (
                                        <UpdateUserForm
                                            user={user}
                                            onUpdateUser={handleUpdateUser}
                                            onCancelEdit={handleCancelEdit}
                                        />
                                    ) : (
                                        <>
                                            <tr>
                                                <td className="title is-5">Name:</td>
                                                <td className="title is-5 UserNames" >{user.name}</td>
                                            </tr>
                                            <tr>
                                                <td className="title is-7">Company:</td>
                                                <td className="title is-7 CompanyNames">{getCompanyName(user.companyId)}</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <button className="button is-warning deleteButton" onClick={() => handleDeleteUser(user.id)}>
                                                        Delete
                                                    </button>
                                                </td>
                                                <td>
                                                    <button className="button is-success updateButton" onClick={() => handleEditUser(user.id)}>
                                                        Update
                                                    </button>
                                                </td>
                                            </tr>
                                        </>
                                    )}
                                </tbody>
                            </table>
                        </li>
                    ))}
                </ul>
            </div>
            <div className="box">
                <AddUserForm onUserAdded={handleAddUser} />
            </div>
        </div>
    );
}

export default Users;
