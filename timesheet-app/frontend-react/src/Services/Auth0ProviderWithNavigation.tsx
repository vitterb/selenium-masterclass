import React from 'react';
import { Auth0Provider } from '@auth0/auth0-react';

const Auth0ProviderWithNavigation: React.FC<{ children: React.ReactNode }> = ({ children }) => {

    const domain = import.meta.env.VITE_REACT_APP_AUTH0_DOMAIN
    const clientId = import.meta.env.VITE_REACT_APP_AUTH0_CLIENT_ID


    console.log(import.meta.env.VITE_REACT_APP_AUTH0_DOMAIN)
    if (!domain || !clientId) {
        throw new Error("Auth0 domain and clientId are not defined in your environment.");
    }

    return (
        <Auth0Provider
            domain={domain}
            clientId={clientId}
            authorizationParams={{ redirect_uri: window.location.origin }}
        >
            {children}
        </Auth0Provider>
    );
};

export default Auth0ProviderWithNavigation;
