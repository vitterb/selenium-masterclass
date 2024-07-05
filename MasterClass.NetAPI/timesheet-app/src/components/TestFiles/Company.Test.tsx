import { expect, test, describe, it } from 'vitest'
import { act } from 'react-dom/test-utils';
import { render, screen } from '@testing-library/react'
import Companies from '../Companies';
import { BrowserRouter as Route } from 'react-router-dom';
import { fetchAllData } from '../Services/apiCall';
import axios from 'axios';
import MockAdapter from 'axios-mock-adapter';




const mock = new MockAdapter(axios);

test('CompanyComponent renders correctly', async () => {
    mock
        .onGet('https://localhost:7118/api/companies')
        .reply(200, [{ id: 1, name: 'Company 1' }]);
    mock
        .onGet('https://localhost:7118/api/users')
        .reply(200, [{ id: 1, name: 'User 1' }]);
    mock
        .onGet('https://localhost:7118/api/timeRegistrations')
        .reply(200, [{ id: 1, hours: 5 }]);

    let companies: any[] = [];
    let users: any[] = [];
    let timeRegistrations: any[] = [];

    render(
        <Route>
            <Companies
                setCompanies={(data: any) => (companies = data)}
                setUsers={(data: any) => (users = data)}
                setTimeRegistrations={(data: any) => (timeRegistrations = data)}
            />
        </Route>
    );

    await act(async () => {
        await fetchAllData(
            (data) => (companies= data),
            (data) => (users = data),
            (data) => (timeRegistrations = data)
        );
    });

    expect(companies).toEqual([{ id: 1, name: 'Company 1' }]);
    expect(users).toEqual([{ id: 1, name: 'User 1' }]);
    expect(timeRegistrations).toEqual([{ id: 1, hours: 5 }]);
});



test('CompanyComponent renders correctly', () => {
    render(<Route><Companies /></Route>);
    expect(screen.getByText('Companies')).toBeInTheDocument();
});