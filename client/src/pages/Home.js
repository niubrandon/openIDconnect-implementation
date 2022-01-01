import React from 'react';
import LoginButton from '../components/LoginButton';
import LogoutButton from '../components/LogoutButton';
import Profile from '../components/Profile';
import Post from '../components/Post';

function Home() {

  return (
      <>
        <LoginButton />
        <LogoutButton />
        <Profile />
        <Post />
      </>
  )
}

export default Home;