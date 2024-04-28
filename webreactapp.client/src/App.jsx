import { Fragment, useEffect, useState } from 'react';
import './App.css';
import Login from './components/Login';
import Register from './components/Register';
import CreateOrder from './components/CreateOrder';
import OrderList from './components/OrderList';

function App() {
    return (
        <Fragment>
            <Register />
            <Login />
            <CreateOrder />
            <OrderList />
        </ Fragment>
    );
}

export default App;