import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import Home from './components/Home';
import Users from './components/Users';
import TimeRegistrations from './components/TimeRegistrations';
import Companies from './components/Companies';



function App() {
  return (
    <Router>
      <Routes>
        <Route path="/" element={<Home />} />
        <Route path="/users" element={<Users />} />
        <Route path="/companies" element={<Companies />} />
        <Route path="/timeregistrations" element={<TimeRegistrations />} />
      </Routes>
    </Router>
  );
}

export default App;