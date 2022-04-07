import React, { Fragment } from 'react';
import { Routes, Route } from "react-router-dom";
import { Provider } from 'react-redux';

import store from './Store/store'

import HomePage from './Pages/Home/Index';
import CreateEvent from './Pages/Create/Index';
import DetailsPage from './Pages/Details/index'
import Testpageauth from './testComponent/TestPage';
import UniversalHeader from './components/UniversalHeader/UniversalHeader.js';
import LoginPage from './Pages/Login/index'
import LoginCallback from './Pages/LoginCallback/index'
import CartPage from "./Pages/CartPage/Index"


function App() {
    return (
        //<p>   test  </p>
        <Provider store={store}>
            <UniversalHeader />
            <Routes>                
                <Route path="/" element={<HomePage />}>      </Route>
                <Route path="/Create" element={<CreateEvent />}>   </Route>
                <Route path="/details/:eventid" element={<DetailsPage />}>   </Route>
                <Route path="/test" element={<Testpageauth />}>     </Route>
                <Route path="/login" element={<LoginPage />}>     </Route>
                <Route path="/logincallback/:string" element={<LoginCallback />}>   </Route>
                <Route path="/cart" element={<CartPage />}> </Route>
            </Routes>
        </Provider>
        
    );
}
export default App;