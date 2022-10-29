import React from 'react';
import { Routes, Route } from 'react-router-dom';
import { ReactComponent as Logo } from './assets/images/logo.svg';

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

const Loading = () => <p>Loading ...</p>;



export default function Main() {
  return (
    <div className="App-content">
      <header className="App-header">
        <main>
          <nav>
            <ul className="App-menu">
              <Logo className="App-menu-item--logo"></Logo>
              <li className="App-menu-item"><a href="/Books">Books</a></li>
              <li className="App-menu-item"><a href="/CreateVoteList">Create Vote List</a></li>
              <li className="App-menu-item"><a href="/Vote">Vote</a></li>
            </ul>
          </nav>
        </main>
      </header>
      <React.Suspense fallback={<Loading />}>

        <Routes>
          {/* <Route path='/' element={<Home />} /> */}
          <Route path="/" element={<BookList />} />
          <Route path='/topics' element={<Topics />} />
          <Route path='/settings' element={<Settings />} />
          <Route path='/profile' element={<Profile />} />


          {/* <Route path="/public/" exact component={BookList} />
          <Route path="/public/Books" exact component={BookList} />
          <Route path="/public/CreateVoteList" exact component={CreateVoteList} />
          <Route path="/public/Vote" exact component={Vote} />
          <Route path="/public/vote/:id" component={VoteListDetail} />
          <Route path="/public/sign-in" exact component={SignIn} /> */}
        </Routes>

      </React.Suspense>
    </div>
  )
}
