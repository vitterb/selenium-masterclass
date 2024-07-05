import React, { useState } from 'react';
import axios from 'axios';
import { TimeRegistration } from '../Interfaces/TimeRegistrationInterface';

interface UpdateRegistrationFormProps {
    registration: TimeRegistration;
    onUpdateRegistration: (updatedRegistration: TimeRegistration) => void;
    onCancelEdit: () => void;
}

function UpdateRegistrationForm({ registration, onUpdateRegistration, onCancelEdit }: UpdateRegistrationFormProps) {
    const [editedRegistration, setEditedRegistration] = useState(registration);

    const handleSubmit = async (e: React.FormEvent) => {
        e.preventDefault();

        try {
            const response = await axios.put(
                `https://localhost:7118/api/timeRegistrations`,
                editedRegistration,
                {
                    headers: {
                        'Content-Type': 'application/json'
                    }
                }
            );

            console.log('Registration updated successfully:', response.data);

            onUpdateRegistration(response.data);
        } catch (error) {
            console.error('Error updating registration:', error);
        }
    };

    return (
        <div>
            <h2 className='title is-5' >Edit Registration</h2>
            <form onSubmit={handleSubmit}>
                <table>
                    <tbody>
                    <tr>
                        <td>
                            <label htmlFor="editedRegistration">Registration Description:</label>
                        </td>
                        <td>
                            <input
                                type="text"
                                id="editedRegistrationName"
                                value={editedRegistration.description}
                                onChange={(e) => setEditedRegistration({ ...editedRegistration, description: e.target.value })}
                                required
                                style={{ backgroundColor:'lightblue', color:'black' }}
                            />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <label htmlFor="editedStart">Start:</label>
                        </td>
                        <td>               
                        <input
                                type="datetime-local"
                                id="editedStart"
                                value={editedRegistration.start}
                                onChange={(e) => setEditedRegistration({ ...editedRegistration, start: e.target.value })}
                                required
                                style={{ backgroundColor:'lightblue', color:'black' }}
                            />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <label htmlFor="editedStop">Stop:</label>
                        </td>
                        <td>               
                        <input
                                type="datetime-local"
                                id="editedStop"
                                value={editedRegistration.stop}
                                onChange={(e) => setEditedRegistration({ ...editedRegistration, stop: e.target.value })}
                                required
                                style={{ backgroundColor:'lightblue', color:'black' }}
                            />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <button className='button is-warning' type="submit">Update Registration</button>
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

export default UpdateRegistrationForm;
