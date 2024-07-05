import { useEffect, useState } from "react";
import { Employee } from "./Interfaces/EmployeeInterface";
import { fetchEmployees } from "../data/APICall";
import { useAuth0 } from "@auth0/auth0-react";
import { format } from 'date-fns'

export default function Reports() {
  const { isAuthenticated, user } = useAuth0();
  const [employees, setEmployees] = useState<Employee[]>([]);

  useEffect(() => {
    fetchEmployees(setEmployees);
  }, []);


  const thTdStyle: React.CSSProperties = {
    border: "1px solid #ddd", // Add borders to table cells and headers
    padding: "8px",
    textAlign: "left",
  };

  return (
    <div>
      {isAuthenticated ? (
        <div>
          <h2>Employee Registrations</h2>
          <table>
            <thead>
              <tr>
                <th>Name</th>
                <th>Email</th>
                <th>Registrations</th>
              </tr>
            </thead>
            <tbody>
              {employees
                .filter((employee) => employee.email === user?.email)
                .map((employee) => (
                  <tr key={employee.id}>
                    <td style={thTdStyle}>{employee.firstName} {employee.lastName}</td>
                    <td style={thTdStyle}>{employee.email}</td>
                    <td style={thTdStyle}>
                      <ul>
                        {employee.timesheets.map((timesheet) => (
                          <li key={timesheet.id}>
                            <table>
                              {timesheet.registrations.length > 0 && (
                                <thead>

                                  <tr>
                                    <th colSpan={2} style={{ fontSize: '24px', fontWeight: 'bold' }}>
                                      {`Year: ${timesheet.year}, Month: ${timesheet.month -1}`}
                                    </th>
                                  </tr>
                                  <tr>
                                    <th style={thTdStyle}>Type</th>
                                    <th style={thTdStyle}>Time Slot</th>
                                  </tr>
                                </thead>
                              )}
                              <tbody>
                                {timesheet.registrations.map((registration) => (
                                  <tr key={registration.id}>
                                    <td>{registration.registrationType}</td>
                                    <td>
                                      {`${format(new Date(registration.timeSlot.start), 'HH:mm dd MMM yyyy')} - ${format(new Date(registration.timeSlot.end), 'HH:mm dd MMM yyyy')}`}
                                    </td>
                                  </tr>
                                ))}
                              </tbody>
                            </table>
                          </li>
                        ))}
                      </ul>
                    </td>
                  </tr>
                ))}
            </tbody>
          </table>
        </div>
      ) : (
        <div>
          <p>Welcome, guest.</p>
          <p>Please sign in.</p>
        </div>
      )}
    </div>
  );
}
