import { Routes, Route } from 'react-router-dom';

import Projects from '../components/Projects';
import Calendar from '../components/Calendar';
import Dashboard from '../components/Dashboard';
import Documents from '../components/Documents';
import Reports from '../components/Reports';
import Teams from '../components/Teams';



const AppRouter: React.FC = () => {
    return (
            <Routes>
                <Route path="/" element={<Dashboard />} />
                <Route path="/Teams" element={<Teams />} />
                <Route path="/Projects" element={<Projects />} />
                <Route path="/Calendar" element={<Calendar />} />
                <Route path="/Documents" element={<Documents />} />
                <Route path="/Reports" element={<Reports />} />

            </Routes>
    );
};

export default AppRouter;