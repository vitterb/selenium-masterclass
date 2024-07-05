import { useEffect, useState } from "react";
import axios from "axios";
import { TimeRegistration } from "../Interfaces/TimeRegistrationInterface";
import { Calendar, momentLocalizer } from "react-big-calendar";
import moment from "moment";
import "react-big-calendar/lib/css/react-big-calendar.css";
import UpdateRegistrationForm from "../Forms/UpdateRegistration";
import { User } from "../Interfaces/UserInterface";
import { fetchUserAndTimeRegistrationData } from "../Services/apiCall";

const localizer = momentLocalizer(moment);

function TimeRegistrationsList() {
  const [timeRegistrations, setTimeRegistrations] = useState<TimeRegistration[]>([]);
  const [users, setUsers] = useState<User[]>([]);
  const [newRegistration, setNewRegistration] = useState({
    description: "",
    start: "",
    stop: "",
    userId: ""
  });
  const [selectedUserId, setSelectedUserId] = useState("");
  const [editingRegistrationId, setEditingRegistrationId] = useState<number | null>(null);

  useEffect(() => {
    fetchUserAndTimeRegistrationData(setUsers, setTimeRegistrations);
  }, []);

  const handleInputChange = (event: React.ChangeEvent<HTMLInputElement | HTMLSelectElement>) => {
    const { name, value } = event.target;
    setNewRegistration((prevRegistration) => ({
      ...prevRegistration,
      [name]: value
    }));
  };

  const handleSubmit = (event: React.FormEvent<HTMLFormElement>) => {
    event.preventDefault();

    axios
      .post("https://localhost:7118/api/timeregistrations", newRegistration)
      .then((response) => {
        setTimeRegistrations([...timeRegistrations, response.data]);
        setNewRegistration({
          description: "",
          start: "",
          stop: "",
          userId: ""
        });
      })
      .catch((error) => {
        console.error("Error adding time registration:", error);
      });
  };

  const handleUserSelectChange = (event: React.ChangeEvent<HTMLSelectElement>) => {
    setSelectedUserId(event.target.value);
  };

  const filteredTimeRegistrations = timeRegistrations.filter(
    (registration) => registration.userId === parseInt(selectedUserId, 10)
  );

  const handleDeleteRegistration = (registrationId: number) => {

    axios
      .delete(`https://localhost:7118/api/timeregistrations/${registrationId}`)
      .then(() => {
        setTimeRegistrations(timeRegistrations.filter((registration) => registration.id !== registrationId));
      })
      .catch((error) => {
        console.error("Error deleting time registration:", error);
      });
  };
  const handleEditRegistration = (registrationId: number) => {
    setEditingRegistrationId(registrationId);
  };

  const handleCancelEdit = () => {
    setEditingRegistrationId(null);
  };

  const handleUpdateRegistration = (updatedRegistration: TimeRegistration) => {
    setTimeRegistrations((prevRegistrations) =>
      prevRegistrations.map((registration) => (registration.id === updatedRegistration.id ? updatedRegistration : registration))
    );

    setEditingRegistrationId(null);
  };

  return (
    <div style={{ display: "flex" }}>
      <div style={{ flex: 1 }}>
        <h1 className="title is-1 tag is-info" id="title">Time Registrations</h1>
        <div>
          <label>
            Select a user:
            <br />
            <select
              name="selectedUser"
              value={selectedUserId}
              onChange={handleUserSelectChange}
              style={{ backgroundColor:'lightblue', color:'black' }}
            >
              <option value="" disabled>
                Select a user
              </option>
              {users.map((user) => (
                <option key={user.id} value={user.id.toString()}>
                  {user.name}
                </option>
              ))}
            </select>
          </label>
        </div>
        <form onSubmit={handleSubmit}>
          <table>
            <tbody>
              <tr>
                <td className="title is-4">
                  Add a TimeRegistration
                </td>
              </tr>
              <tr>
                <td className="title is-5">
                  Description:
                </td>
              </tr>
              <tr>
                <td>
                  <input
                    type="text"
                    name="description"
                    value={newRegistration.description}
                    onChange={handleInputChange}
                    required
                    style={{ width: '300%', height: '100px', backgroundColor:'lightblue', color:'black' }}
                  />
                </td>
              </tr>
              <tr>
                <td className="title is-5">
                  Start:
                </td>
              </tr>
              <tr>
                <td>
                  <input
                    type="datetime-local"
                    name="start"
                    value={newRegistration.start}
                    onChange={handleInputChange}
                    required
                    style={{ backgroundColor:'lightblue', color:'black' }}
                  />
                </td>
              </tr>
              <tr>
                <td className="title is-5">
                  Stop:
                </td>
              </tr>
              <tr>
                <td>
                  <input
                    type="datetime-local"
                    name="stop"
                    value={newRegistration.stop}
                    onChange={handleInputChange}
                    required
                    style={{ backgroundColor:'lightblue', color:'black' }}
                  />
                </td>
              </tr>
              <tr>
                <td className="title is-5">
                  User:
                </td>
              </tr>
              <tr>
                <td>
                  <select
                    name="userId"
                    value={newRegistration.userId}
                    onChange={handleInputChange}
                    required
                    style={{ backgroundColor:'lightblue', color:'black' }}
                  >
                    <option value="" disabled>
                      Select a user
                    </option>
                    {users.map((user) => (
                      <option key={user.id} value={user.id.toString()}>
                        {user.name}
                      </option>
                    ))}
                  </select>
                </td>
              </tr>
              <tr>
                <td>
                  <button className="button is-primary" type="submit">Add Registration</button>
                </td>
              </tr>
            </tbody>
          </table>
        </form>
        <ul>
          {filteredTimeRegistrations.map((registration) => (
            <li key={registration.id}>
              {editingRegistrationId === registration.id ? (
                <UpdateRegistrationForm
                  registration={registration}
                  onUpdateRegistration={handleUpdateRegistration}
                  onCancelEdit={handleCancelEdit}
                />
              ) : (
                <>
                  <strong>Description:</strong> {registration.description}<br />
                  <strong>Start:</strong> {registration.start}<br />
                  <strong>Stop:</strong> {registration.stop}<br />
                  <strong>User:</strong> {users.find((user) => user.id === registration.userId)?.name}<br />
                  <button className="button is-warning" onClick={() => handleDeleteRegistration(registration.id)}>Delete</button>
                  <button className="button is-success" onClick={() => handleEditRegistration(registration.id)}>Update</button>
                </>
              )}
            </li>
          ))}
        </ul>
      </div>
      <div style={{ flex: 2 }} className="box">
        <Calendar
          localizer={localizer}
          events={filteredTimeRegistrations.map((registration) => ({
            title: registration.description,
            start: new Date(registration.start),
            end: new Date(registration.stop),
          }))}
          startAccessor="start"
          endAccessor="end"
          style={{ height: 500 }}
        />
      </div>
    </div>
  );

}
export default TimeRegistrationsList;

