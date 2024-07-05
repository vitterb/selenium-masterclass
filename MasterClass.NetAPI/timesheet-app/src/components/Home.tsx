import { Link } from 'react-router-dom';
import { TimeRegistration } from './Interfaces/TimeRegistrationInterface';
import { useEffect, useState } from 'react';
import { fetchTimeRegistrations } from './Services/apiCall';

function Home() {
    const [timeRegistrations, setTimeRegistrations] = useState<TimeRegistration[]>([]);

    useEffect(() => {
        fetchTimeRegistrations(setTimeRegistrations);
    }, []);

    // Function to calculate total time from time registrations
    const calculateTotalTime = () => {
        let totalMilliseconds = 0;

        for (const registration of timeRegistrations) {
            const startTime = new Date(registration.start).getTime();
            const stopTime = new Date(registration.stop).getTime();
            const duration = stopTime - startTime;
            totalMilliseconds += duration;
        }

        const totalMinutes = Math.floor(totalMilliseconds / (1000 * 60));
        const totalHours = Math.floor(totalMinutes / 60);
        const remainingMinutes = totalMinutes % 60;

        return { totalHours, remainingMinutes };
    };

    const totalTime = calculateTotalTime();

    return (
        <div className='frame'>
            <h1 className='title tag is-1 is-info' id='title'>Masterclass Time registration app</h1>
            <nav className='content box'>
                <ol type="1">
                    <li>
                        <Link to="/users" id="users">Users</Link>
                    </li>
                    <li>
                        <Link to="/companies" id="companies">Companies</Link>
                    </li>
                    <li>
                        <Link to="/timeregistrations" id="timeRegistrations">Time Registrations</Link>
                    </li>
                </ol>
            </nav>
            <div>
                <h2 className='title is-5 tag is-danger is-light'>Total Time Logged</h2>
                <p className='box'>
                    {totalTime.totalHours} hours and {totalTime.remainingMinutes} minutes
                </p>
            </div>
        </div>
    );
}

export default Home;
