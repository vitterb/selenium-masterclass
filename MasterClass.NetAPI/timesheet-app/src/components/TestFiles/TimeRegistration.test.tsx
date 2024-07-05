import { expect, test } from 'vitest'
import {render, screen} from '@testing-library/react'
import { BrowserRouter as Route } from 'react-router-dom';
import TimeRegistrations from '../TimeRegistrations';



test('TimeRegistrationComponent renders correctly', () => {
    render(<Route><TimeRegistrations /></Route>);
    expect(screen.getByText('Description:')).toBeInTheDocument();
});