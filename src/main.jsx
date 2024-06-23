import React from 'react';
import ReactDOM from 'react-dom/client';
import { ParallaxProvider } from 'react-scroll-parallax';
import { createBrowserRouter, RouterProvider } from 'react-router-dom';
import 'swiper/css';
import 'swiper/swiper-bundle.css';
import './CSS/input.css';
import './CSS/output.css';
import Login from './pages/Login.jsx'
import Dashboard from './pages/Dashboard.jsx';

import App from './App.jsx';


const routers = createBrowserRouter([
  {
    path: '/',
    element: <App />,

    children: [
      {
        path: '/',
        element: <Login />,
      },
      {
        path: '/dashboard',
        element: <Dashboard />,
      }
    ],
  },
]);

ReactDOM.createRoot(document.getElementById('root')).render(
  <React.StrictMode>
    <ParallaxProvider>
      <RouterProvider router={routers} />
    </ParallaxProvider>
  </React.StrictMode>
);
