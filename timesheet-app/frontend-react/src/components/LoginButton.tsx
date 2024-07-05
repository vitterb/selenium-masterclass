import * as React from 'react'; // Import React
import { useAuth0 } from '@auth0/auth0-react';

const LoginButton: React.FC = () => {
  const { loginWithRedirect, isAuthenticated } = useAuth0();

  return (
    !isAuthenticated ? (
      <button 
      onClick={() => loginWithRedirect()}
      role="button"
      type="button"
      className="ml-3 inline-flex items-center rounded-md bg-indigo-600 px-3 py-2 text-sm font-semibold text-white shadow-sm hover:bg-indigo-500 focus-visible:outline focus-visible:outline-2 focus-visible:outline-offset-2 focus-visible:outline-indigo-600"
      >
        Sign In
      </button>
    ) : null
  );
};

export default LoginButton;


