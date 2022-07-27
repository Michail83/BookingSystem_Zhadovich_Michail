import React, { Fragment, useEffect } from 'react';
import { Routes, Route } from "react-router-dom";
import { connect } from 'react-redux';

// import { Provider } from 'react-redux';
import store from './Store/store'

import axios from "axios";

import urls from "../src/API_URL";
import actionsCreator from "../src/Store/ActionsCreators/actionCreator";
import {tryLoadAuthData} from "./function/tryLoadAuthData";




import { DeleteArtEventButton } from './components/Details/DeleteArtEventButton';

import HomePage from './Pages/Home/Index';
import CreateEvent from './Pages/Create/Index';
import DetailsPage from './Pages/Details/index'
import Testpageauth from './testComponent/TestPage';
import UniversalHeader from './components/UniversalHeader/UniversalHeader.js';
import LoginPage from './Pages/Login/index'
// import LoginCallback from './Pages/LoginCallback/index'
import CartPage from "./Pages/CartPage/Index"
import OrderPage from "./Pages/OrderPage/index"
import Registration from './components/OwnLogin/Registration';


function App({ authData, addDeleteArtEventButtonToState }) {
    useEffect(() => {
        localStorage.clear();
        tryLoadAuthData()
    }, [])
    
    let routes;
    if (authData.isAuthenticated && authData.isAdmin) {
        
        addDeleteArtEventButtonToState();
        routes = (<Fragment>
            <UniversalHeader isAdmin={authData.isAdmin} />    {/* Redux??? */}  
            
            <Routes>
                <Route path="/" element={<HomePage />}>      </Route>
                <Route path="/Create"               element={<CreateEvent/>}>   </Route> 
            <Route path ="/details/:eventid"    element={<DetailsPage/>}>   </Route> 
            <Route path="/test"                 element={<Testpageauth/>}>     </Route>
                <Route path="/login" element={<LoginPage />}>     </Route>
                {/* <Route path ="/logincallback/:string" element={<LoginCallback/>}>   </Route>   */}
                <Route path ="/cart"                element={<CartPage/>}> </Route>
        <Route path ="/orders"                element={<OrderPage/>}> </Route>  
                <Route path='registration' element={<Registration />} />
                <Route path='*' element={<HomePage />}> </Route>


            </Routes>
        </Fragment>);

    } else {
        // console.log("User routes");
        routes = (
            <Fragment>
                <UniversalHeader />
                <Routes>
                    <Route path="/" element={<HomePage />}>      </Route>
                    <Route path="/Create"               element={<CreateEvent/>}>   </Route> 
                    <Route path ="/details/:eventid"    element={<DetailsPage/>}>   </Route> 
                    <Route path="/test"                 element={<Testpageauth/>}>     </Route>
                    <Route path="/login" element={<LoginPage />}>     </Route>
                    {/* <Route path ="/logincallback/:string" element={<LoginCallback/>}>   </Route>   */}
                    <Route path ="/cart"                element={<CartPage/>}> </Route>
                    <Route path ="/orders"                element={<OrderPage/>}> </Route>  
                    <Route path='registration' element={<Registration />} />
                    <Route path='*' element={<HomePage />}> </Route>
                </Routes>
            </Fragment>
        )
    }
    return (
        <Fragment>
            {routes}
        </Fragment>

    );
}
// export default App;

const mapStateToProps = state => ({
    authData: state.auth,    
    // isActive: state.state.iSmodalLoginWindowActive
});
const mapDispatchToProps = dispatch => (
    {
        addDeleteArtEventButtonToState:()=>dispatch(actionsCreator.setDeleteArtEventButton(DeleteArtEventButton))
        // setNoActive:()=> dispatch(actionCreator.setModalWindowForLoginActive(false))        
    });
var App_ReduxWrapped = connect(mapStateToProps, mapDispatchToProps)(App);
export default App_ReduxWrapped;

