import React, { Fragment, useEffect } from 'react';
import { Routes, Route } from "react-router-dom";
import { connect } from 'react-redux';

import actionsCreator from "../src/Store/ActionsCreators/actionCreator";
import { tryLoadAuthData } from "./function/tryLoadAuthData";
import Registration from './components/OwnLogin/Registration';
import { DeleteArtEventButton } from './components/Details/DeleteArtEventButton';
import UniversalHeaderReduxWrapped from './components/UniversalHeader/UniversalHeader.js';


import HomePage from './Pages/Home/Index';
import CreateEvent from './Pages/Create/Index';
import DetailsPage from './Pages/Details/index';
import LoginPage from './Pages/Login/index';
import CartPage from "./Pages/CartPage/Index";
import OrderPage from "./Pages/OrderPage/index";


import Testpageauth from './testComponent/TestPage';


function App({ authData, addDeleteArtEventButtonToState }) {
    useEffect(() => {
        // localStorage.clear();
        tryLoadAuthData()
    }, [])

    let routes;
    if (authData.isAuthenticated && authData.isAdmin) {

        addDeleteArtEventButtonToState();
        routes = (<Fragment>
            <UniversalHeaderReduxWrapped />
            <Routes>
                <Route path="/" element={<HomePage />}>      </Route>
                <Route path="/Create" element={<CreateEvent />}>   </Route>
                <Route path="/details/:eventid" element={<DetailsPage />}>   </Route>
                <Route path="/test" element={<Testpageauth />}>     </Route>
                <Route path="/login" element={<LoginPage />}>     </Route>                
                <Route path="/cart" element={<CartPage />}> </Route>
                <Route path="/orders" element={<OrderPage />}> </Route>
                <Route path='registration' element={<Registration />} />
                <Route path='*' element={<HomePage />}> </Route>


            </Routes>
        </Fragment>);

    } else {        
        routes = (
            <Fragment>
                <UniversalHeaderReduxWrapped />
                <Routes>
                    <Route path="/" element={<HomePage />}>      </Route>
                    <Route path="/Create" element={<CreateEvent />}>   </Route>
                    <Route path="/details/:eventid" element={<DetailsPage />}>   </Route>
                    <Route path="/test" element={<Testpageauth />}>     </Route>
                    <Route path="/login" element={<LoginPage />}>     </Route>                    
                    <Route path="/cart" element={<CartPage />}> </Route>
                    <Route path="/orders" element={<OrderPage />}> </Route>
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


const mapStateToProps = state => ({
    authData: state.auth,    
});
const mapDispatchToProps = dispatch => (
    {
        addDeleteArtEventButtonToState: () => dispatch(actionsCreator.setDeleteArtEventButton(DeleteArtEventButton))
              
    });
var AppReduxWrapped = connect(mapStateToProps, mapDispatchToProps)(App);
export default AppReduxWrapped;

