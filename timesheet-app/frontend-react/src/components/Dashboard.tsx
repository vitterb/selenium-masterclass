import { useAuth0 } from "@auth0/auth0-react";
import { useEffect, useState } from "react";
import { Employee } from "./Interfaces/EmployeeInterface";
import { fetchEmployees } from "../data/APICall";


export default function Dashboard() {

  const {isAuthenticated, user } = useAuth0();
  const [employees, setEmployees] = useState<Employee[]>([]);
  const [isUserInDatabase, setIsUserInDatabase] = useState<boolean | null>(null);
  
  useEffect(() => {
    if (isAuthenticated && user) {

      const isUserInDB = employees.some((employee) => employee.email === user.email);

      setIsUserInDatabase(isUserInDB);
    }
  }, [isAuthenticated, user, employees]);

  useEffect(() => {
    fetchEmployees(setEmployees);
  }, []);
    return (
      <div>
        {isAuthenticated && (
        <div>
          <p>Welcome, {user?.name}</p>
          <p>Email: {user?.email}</p>
          {isUserInDatabase ? (
            <p>User is in the database.</p>
          ) : (
            <p>User is not in the database.</p>
          )}
        </div>
      )}
      {!isAuthenticated && (
        <div>
          <p>Welcome, guest</p>
          <p>Please sign in</p>
        </div>
      )}

      </div>
    )
  }