import React, { Fragment, useEffect } from 'react';
import { Routes, Route } from "react-router-dom";
import { Provider } from 'react-redux';

import axios from "axios";
import urls from "../src/API_URL";
import actionsCreator from "../src/Store/ActionsCreators/actionCreator"




import store from './Store/store'

import HomePage from './Pages/Home/Index';
import CreateEvent from './Pages/Create/Index';
import DetailsPage from './Pages/Details/index'
import Testpageauth from './testComponent/TestPage';
import UniversalHeader from './components/UniversalHeader/UniversalHeader.js';
import LoginPage from './Pages/Login/index'
import LoginCallback from './Pages/LoginCallback/index'
import CartPage from "./Pages/CartPage/Index"
import OrderPage from "./Pages/OrderPage/index"


function App() {
    useEffect(() => {
        tryLoadAuthData()
    }, [])

    const tryLoadAuthData = async () => {
        try {
            const result = await axios.get(urls.getLoginInfo());
            if (result.status == 200) {
                store.dispatch(actionsCreator.setAuth(result.data));
            }           
        } catch (e) {
            console.log(`APP -    tryLoadAuthData    ${e}`)
        }
    }


    return (
        // <Fragment>
        <Provider store={store}>
        <UniversalHeader/>
        <Routes>
            <Route path="/"                     element={<HomePage/>}>      </Route> 
            <Route path="/Create"               element={<CreateEvent/>}>   </Route> 
            <Route path ="/details/:eventid"    element={<DetailsPage/>}>   </Route> 
            <Route path="/test"                 element={<Testpageauth/>}>     </Route>
            <Route path="/login"                element={<LoginPage/>}>     </Route>
            <Route path ="/logincallback/:string" element={<LoginCallback/>}>   </Route>  
            <Route path ="/cart"                element={<CartPage/>}> </Route>
            <Route path ="/orders"                element={<OrderPage/>}> </Route>  
            <Route path='*'                       element={<HomePage/>}> </Route>    

        </Routes>
        </Provider>
        // </Fragment>
    );
}
export default App;