import React from 'react';
import { Routes, Route } from 'react-router-dom';

const Home = React.lazy(
  () => import('./pages/Home').then(module => ({ default: module.Home }))
);
const Topics = React.lazy(
  () => import('./pages/Topics').then(module => ({ default: module.Topics }))
);
const Settings = React.lazy(
  () => import('./pages/Settings').then(module => ({ default: module.Settings }))
);
const Profile = React.lazy(
  () => import('./pages/Profile')
);

const Loading = () => <p>Loading ...</p>;



export default function Main() {
  return (
        <React.Suspense fallback={<Loading />}>

          <Routes>
            <Route path='/' element={<Home />} />
            <Route path='/topics' element={<Topics />} />
            <Route path='/settings' element={<Settings />} />
            <Route path='/profile' element={<Profile />} />
          </Routes>

        </React.Suspense>
  )
}
