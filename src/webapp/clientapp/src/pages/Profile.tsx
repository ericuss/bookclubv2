import React from "react";
import { withAuth, useAuth } from "react-oidc-context";
import { Requests } from '../services/serviceCore';
import { CodeSnippet } from "../components/code-snippet";

// const Profile = () => {
//     const auth = useAuth();

//     Requests.get('/api/settings/auth');

//     return <div>Hello {auth.user?.profile.sub}</div>;
// }
// export default withAuth(Profile);

export const Profile = () => {
  const { user } = useAuth();

  if (!user) {
    return null;
  }

  return (
    <article>
      <div className="content-layout">
        <h1 id="page-title" className="content__title">
          Profile Page
        </h1>
        <div className="content__body">
          <p id="page-description">
            <span>
              You can use the <strong>ID Token</strong> to get the profile
              information of an authenticated user.
            </span>
            <span>
              <strong>Only authenticated users can access this page.</strong>
            </span>
          </p>
          <div className="profile-grid">
            {/* <div className="profile__header">
              <img
                src={user.picture}
                alt="Profile"
                className="profile__avatar"
              />
              <div className="profile__headline">
                <h2 className="profile__title">{user.name}</h2>
                <span className="profile__description">{user.email}</span>
              </div>
            </div> */}
            <div className="profile__details">
              <CodeSnippet
                title="Decoded ID Token"
                code={JSON.stringify(user, null, 2)}
              />
            </div>
          </div>
        </div>
      </div>
    </article>
  );
};

export default withAuth(Profile);
