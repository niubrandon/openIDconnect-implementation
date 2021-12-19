import React from 'react';
import { Routes, Route } from 'react-router-dom';
import { Auth0Provider, withAuthenticationRequired } from '@auth0/auth0-react';
import { createBrowserHistory } from 'history';
import Profile from './components/Profile.js';
import Home from './pages/Home.js';

export const history = createBrowserHistory();


const ProtectedRoute = ({ component, ...args }) => (
  <Route component={withAuthenticationRequired(component)} {...args} />
);

//refactor useNavigate replacing createBrowserHistory
const onRedirectCallback = (appState) => {
  // Use the router's history module to replace the url
  history.replace(appState?.returnTo || window.location.pathname);
};

export default function App() {
  return (
    <Auth0Provider
      domain="dev--h1k3jop.us.auth0.com"
      clientId="ae8Yg3yWvzlCB7WGu6fTizFz6ikukY0i"
      redirectUri={window.location.origin}
      onRedirectCallback={onRedirectCallback}
    >
      {/* Don't forget to add the history to your router */}
     
        <Routes>
          <Route path="/" element={<Home />} />
          <Route path="/profile" element={<ProtectedRoute component={Profile} />} />
       
        </Routes>
     
    </Auth0Provider>
  );
}

