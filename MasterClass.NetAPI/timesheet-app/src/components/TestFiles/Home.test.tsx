import { expect, test, vi } from 'vitest'
import {render, screen} from '@testing-library/react'
import Home from '../Home';
import { BrowserRouter as Route } from 'react-router-dom';
import axios from 'axios';

test('mocked axios', async () => {
    const { default: ax } = await vi.importMock<any>('axios')
    await ax.get('string')
    expect(ax.get).toHaveBeenCalledWith('string')
})

test('actual axios is not mocked', async () => {
    expect(vi.isMockFunction(axios.get)).toBe(false)
})

test('HomeComponent renders correctly', () => {
    render(<Route><Home /></Route>);
    expect(screen.getByText('Masterclass Time registration app')).toBeInTheDocument();
});


