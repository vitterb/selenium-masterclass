import { useEffect, useState } from "react";
import { Employee } from "./Interfaces/EmployeeInterface";
import { fetchEmployees } from "../data/APICall";

export default function Teams() {
  const [employees, setEmployees] = useState<Employee[]>([]);
  
  useEffect(() => {
    fetchEmployees(setEmployees)
  }, []);

    return (
      <div>
      <h1>Employee List</h1>
      <table>
        <thead>
          <tr>
            <th>Name</th>
            <th>Role</th>
          </tr>
        </thead>
        <tbody>
          {employees.map((employee) => (
            <tr key={employee.id}>
              <td>{`${employee.firstName} ${employee.lastName}`}</td>
              <td></td>
              <td>{`${employee.role}`}</td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
    )
  }