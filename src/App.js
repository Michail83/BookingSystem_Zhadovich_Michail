import React, { Fragment, useEffect, useState } from 'react';
import { Routes, Route } from "react-router-dom";
import { connect } from 'react-redux';

import actionsCreator from "../src/Store/ActionsCreators/actionCreator";
import { tryLoadAuthData } from "./function/tryLoadAuthData";
import { getCurrentLocation } from './function/getCurrentLocation';
import Registration from './components/OwnLogin/Registration';

import UserHeader_ReduxWrapped from './components/UniversalHeader/UserHeader.js';
import AdminHeader_ReduxWrapped from './components/UniversalHeader/AdminHeader';


import HomePage from './Pages/Home/Index';
import CreateEvent from './Pages/Create/Index';
import DetailsPage from './Pages/Details/index';
import CartPage from "./Pages/CartPage/Index";
import OrderPage from "./Pages/OrderPage/index";

import HomeAdminPage from './Pages/Admins/Home/Index';
import AdminDetailsPage from './Pages/Admins/Details/AdminDetailsPage';
import UsersPage from './Pages/Admins/Users/UsersPage';

import LockedUser from './Pages/LockedUser/LockedUser';

import {MainContent} from "./components/StyledComponent/MainContent"

import Testpageauth from './testComponent/TestPage';

function App({ authData}) {

    const [routes, setRoutes] = useState("");
    useEffect(() => {
        getCurrentLocation();        
        
        const head = document.querySelector("head");
        const script = document.createElement('script');
        script.src="https://api-maps.yandex.ru/2.1/?lang=ru_RU&apikey=913cb368-b557-4cb7-9840-91e7dfa600b2";
        script.type="text/javascript";
        script.async=true;        
        head.appendChild(script);        
        tryLoadAuthData()
    }, []);
    
    useEffect(()=>{
        createRoutes();
    },[authData]);

    const createRoutes=()=>{

        if (authData.isAuthenticated && authData.isAdmin) {
            // localStorage.clear();

            setRoutes(<Fragment>
                <AdminHeader_ReduxWrapped />
                <MainContent>
                <Routes>
                    <Route path="/" element={<HomeAdminPage />}>      </Route>
                    <Route path="/Create" element={<CreateEvent />}>   </Route>
                    <Route path="/details/:eventid" element={<AdminDetailsPage />}>   </Route>
                    {/* <Route path="/test" element={<Testpageauth />}>     </Route> */}
                    <Route path="/users" element={<UsersPage/>} /> 
              
                    {/* <Route path='registration' element={<Registration />} /> */}
                    <Route path='*' element={<HomeAdminPage />}> </Route> 
                </Routes>
                </MainContent>
            </Fragment>);
    
        } else if (authData.isAuthenticated && authData.isLocked==true) {
            setRoutes(
                <Fragment>                
                <MainContent>
                <Routes>                    
                    <Route path='*' element={<LockedUser />}> </Route>
                </Routes>
                </MainContent>
            </Fragment>

            );
            
        } else {
                setRoutes(
                    <Fragment>
                        <UserHeader_ReduxWrapped />
                        <MainContent>
                        <Routes>
                            <Route path="/" element={<HomePage />}>      </Route>                        
                            <Route path="/details/:eventid" element={<DetailsPage />}>   </Route> 
                            <Route path="/cart" element={<CartPage />}> </Route>
                            <Route path="/orders" element={<OrderPage />}> </Route>
                            <Route path='registration' element={<Registration />} />
                            <Route path='*' element={<HomePage />}> </Route>
                        </Routes>
                        </MainContent>
                    </Fragment>
                )           
            
        }
    } 
    return (
        <Fragment>
            {routes}
        </Fragment>

    );
}
const mapStateToProps = state => ({
    authData: state.auth,    
});
var AppReduxWrapped = connect(mapStateToProps, null)(App);
export default AppReduxWrapped;

