import { Link } from 'react-router-dom';
import Main from './Main';
import { useAuth } from "react-oidc-context";

import './App.css';
import "./index.css"

export default function App() {
  const auth = useAuth();

  switch (auth.activeNavigator) {
    case "signinSilent":
      return <div>Signing you in...</div>;
    case "signoutRedirect":
      return <div>Signing you out...</div>;
  }

  if (auth.isLoading) {
    return <div>Loading...</div>;
  }

  if (auth.error) {
    return <div>Oops... {auth.error.message}</div>;
  }

  return (
    <div className="App">
      <Main />

    </div>
  )
}
