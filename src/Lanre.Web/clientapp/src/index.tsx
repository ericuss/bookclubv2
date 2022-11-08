import React from 'react';
import ReactDOM from 'react-dom/client';
import './index.css';
import App from './App';
import reportWebVitals from './reportWebVitals';
import { BrowserRouter } from "react-router-dom";
import { AuthProvider } from "react-oidc-context";

import './app/sass/index.scss';

interface Options {
  settings: {},
  auth: {
    audience: string;
    clientId: string;
    domain: string;
  }
}

const root = ReactDOM.createRoot(
  document.getElementById('root') as HTMLElement
);


root.render(
  <React.StrictMode>
    loading ...
  </React.StrictMode>
);

fetch('/api/settings')
  .then((response) => response.json())
  .then((data: Options) => {
    const oidcConfig = {
      authority: data.auth.domain,
      client_id: data.auth.clientId,
      redirect_uri: window.location.origin + "/callback",

      extraQueryParams: { audience: data.auth.audience },
      onSignIn: (user: Object) => {
        // the `user` prop is actually the data the app received from `/userinfo` endpoint.
        console.log("user info")
        console.log(user)
      },
    };

    root.render(
      <React.StrictMode>
        <AuthProvider {...oidcConfig}>
          <BrowserRouter>
            <App />
          </BrowserRouter>
        </AuthProvider>
      </React.StrictMode>
    );

  })
  .catch(e => root.render(
    <React.StrictMode>
      error
    </React.StrictMode>
  ));

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
