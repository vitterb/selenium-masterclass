import { expect, test, vi } from 'vitest'
import { Employee } from '../components/Interfaces/EmployeeInterface';

test('mocked axios', async () => {
    // eslint-disable-next-line @typescript-eslint/no-explicit-any
    const { default: ax } = await vi.importMock<any>('axios')

    const mockEmployee: Employee = {
        id: '1',
        firstName: 'John',
        lastName: 'Doe',
        email: 'john.doe@example.com',
        role: 'Developer',
        timesheets: []
    };

    ax.get.mockResolvedValue({ data : mockEmployee});
    const response = await ax.get('/api/employee');

    expect(ax.get).toHaveBeenCalledWith('/api/employee');
    expect(response.data).toEqual(mockEmployee);
})



