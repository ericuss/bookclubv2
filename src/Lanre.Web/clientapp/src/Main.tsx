import React from 'react';
import { Routes, Route } from 'react-router-dom';
import { ReactComponent as Logo } from './assets/images/logo.svg';

import { useAuth } from "react-oidc-context";

const Home = React.lazy(
  () => import('./app/pages/Home').then(module => ({ default: module.Home }))
);
const Topics = React.lazy(
  () => import('./app/pages/Topics').then(module => ({ default: module.Topics }))
);
const Settings = React.lazy(
  () => import('./app/pages/Settings').then(module => ({ default: module.Settings }))
);
const Profile = React.lazy(
  () => import('./app/pages/Profile')
);
const BookList = React.lazy(
  () => import('./app/pages/books/book-list').then(module => ({ default: module.BookList }))
);
const CreateVoteList = React.lazy(
  () => import('./app/pages/create-vote-list/create-vote-list').then(module => ({ default: module.CreateVoteList }))
);
const Vote = React.lazy(
  () => import('./app/pages/vote/vote').then(module => ({ default: module.Vote }))
);
const VoteListDetail = React.lazy(
  () => import('./app/pages/vote-list-detail/vote-list-detail').then(module => ({ default: module.VoteListDetail }))
);
const Public = React.lazy(
  () => import('./app/pages/public').then(module => ({ default: module.Public }))
);

const Loading = () => <p>Loading ...</p>;



export default function Main() {
  const auth = useAuth();

  return (
    <>

      {
        !auth.isAuthenticated
          ? <></>
          : <header className="App-header">
            <main>
              <nav>
                <ul className="App-menu">
                  <Logo className="App-menu-item--logo"></Logo>
                  <li className="App-menu-item"><a href="/Books">Books</a></li>
                  <li className="App-menu-item"><a href="/CreateVoteList">Create Vote List</a></li>
                  <li className="App-menu-item"><a href="/Vote">Vote</a></li>
                  <li className="App-menu-item">
                    {
                      auth.isAuthenticated &&
                      <div>
                        Hello {auth.user?.profile.sub}{" "}
                        <button onClick={() => void auth.removeUser()}>Log out</button>
                      </div>
                    }
                  </li>
                </ul>
              </nav>
            </main>
          </header>
      }

      <div className="App-content">

        <React.Suspense fallback={<Loading />}>

          <Routes>
            {/* <Route path='/' element={<Home />} /> */}
            <Route path="/" element={<BookList />} />
            <Route path="/Books" element={<BookList />} />
            <Route path="/sign-in" element={<Public />} />
            <Route path='/profile' element={<Profile />} />

            <Route path="/CreateVoteList" element={<CreateVoteList />} />
            <Route path="/Vote" element={<Vote />} />
            <Route path="/vote/:id" element={<VoteListDetail />} />
          </Routes>

        </React.Suspense>
      </div>
    </>
  )
}
