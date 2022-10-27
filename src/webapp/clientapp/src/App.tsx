import { Link } from 'react-router-dom';
import Main from './Main';
import { useAuth } from "react-oidc-context";

import './App.css';

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

  // if (auth.isAuthenticated) {
  //   return (
  //     <div>
  //       Hello {auth.user?.profile.sub}{" "}
  //       <button onClick={() => void auth.removeUser()}>Log out</button>
  //     </div>
  //   );
  // }

  return (
    <>
      {
        auth.isAuthenticated
          ? <div>
            Hello {auth.user?.profile.sub}{" "}
            <button onClick={() => void auth.removeUser()}>Log out</button>
          </div>

          : <button onClick={() => void auth.signinRedirect()}>Log in</button>
      }

      <div>
        <ul>
          <li><Link to='/'>Home</Link></li>
          <li><Link to='/topics'>Topics</Link></li>
          <li><Link to='/settings'>Settings</Link></li>
          <li><Link to='/profile'>Profile</Link></li>
        </ul>
        <hr />
        <Main />

      </div>
    </>
  )
}
