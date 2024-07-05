import { Link } from "react-router-dom";
import TimeRegistrationsList from "./Time-calendar/TimeRegistrationsList";

function TimeRegistrations() {
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
          <Link to="/Companies">Companies</Link>
        </button>
      </nav>
      <TimeRegistrationsList />
    </div>
  );
}

export default TimeRegistrations;