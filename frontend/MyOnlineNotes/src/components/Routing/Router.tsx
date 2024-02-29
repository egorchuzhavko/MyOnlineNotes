import { BrowserRouter, Route, Routes } from 'react-router-dom';
import Login from '../screens/login/Login';
import Mainpage from '../screens/main-page/Mainpage';
import Registration from '../screens/registration/Registration';

const Router = () => {
  return (
    <BrowserRouter>
      <Routes>
        <Route element={<Login />} path='/login' />
        <Route element={<Registration />} path='/registration' />
        <Route element={<Mainpage />} path='/mynotes' />

        <Route element={<div>Not found</div>} path='*' />
      </Routes>
    </BrowserRouter>
  );
};

export default Router;
