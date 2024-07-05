import React from 'react'
import ReactDOM from 'react-dom/client'
import App from './App.tsx'
import './index.css'
import {SWRConfig} from "swr";
import Auth0ProviderWithNavigation from './Services/Auth0ProviderWithNavigation.tsx';
import { BrowserRouter as Router } from 'react-router-dom';

ReactDOM.createRoot(document.getElementById('root') as HTMLElement).render(
  <React.StrictMode>
    <SWRConfig value={{ fetcher: (resource, init) => fetch(resource, init).then(res => res.json())}}>
    <Auth0ProviderWithNavigation>
      <Router>
        <App />
      </Router>
      </Auth0ProviderWithNavigation>
    </SWRConfig>
  </React.StrictMode>,
)
