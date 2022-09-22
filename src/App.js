import React, { Fragment, useEffect, useState } from 'react';
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
import CartPage from "./Pages/CartPage/Index";
import OrderPage from "./Pages/OrderPage/index";


import Testpageauth from './testComponent/TestPage';


function App({ authData, addDeleteArtEventButtonToState }) {

    const [routes, setRoutes] = useState("");
    useEffect(() => {
        const head = document.querySelector("head");
        const script = document.createElement('script');
        script.src="https://api-maps.yandex.ru/2.1/?lang=ru_RU&apikey=913cb368-b557-4cb7-9840-91e7dfa600b2";
        script.type="text/javascript";
        script.async=true;        
        head.appendChild(script);


        // localStorage.clear();
        tryLoadAuthData()
    }, []);
    
    useEffect(()=>{
        createRoutes();
    },[authData]);

    const createRoutes=()=>{


        if (authData.isAuthenticated && authData.isAdmin) {
            localStorage.clear();

            addDeleteArtEventButtonToState();
            setRoutes(<Fragment>
                <UniversalHeaderReduxWrapped />
                <Routes>
                    <Route path="/" element={<HomePage />}>      </Route>
                    <Route path="/Create" element={<CreateEvent />}>   </Route>
                    <Route path="/details/:eventid" element={<DetailsPage />}>   </Route>
                    {/* <Route path="/test" element={<Testpageauth />}>     </Route> */}
                    

                    
                    <Route path="/cart" element={<CartPage />}> </Route>
                    <Route path="/orders" element={<OrderPage />}> </Route>
                    <Route path='registration' element={<Registration />} />
                    <Route path='*' element={<HomePage />}> </Route>
    
    
                </Routes>
            </Fragment>);
    
        } else {        
            setRoutes(
                <Fragment>
                    <UniversalHeaderReduxWrapped />
                    <Routes>
                        <Route path="/" element={<HomePage />}>      </Route>
                        {/* <Route path="/Create" element={<CreateEvent />}>   </Route> */}
                        <Route path="/details/:eventid" element={<DetailsPage />}>   </Route>
                        {/* <Route path="/test" element={<Testpageauth />}>     </Route> */}
                        
                        <Route path="/cart" element={<CartPage />}> </Route>
                        <Route path="/orders" element={<OrderPage />}> </Route>
                        <Route path='registration' element={<Registration />} />
                        <Route path='*' element={<HomePage />}> </Route>
                    </Routes>
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
const mapDispatchToProps = dispatch => (
    {
        addDeleteArtEventButtonToState: () => dispatch(actionsCreator.setDeleteArtEventButton(DeleteArtEventButton))
              
    });
var AppReduxWrapped = connect(mapStateToProps, mapDispatchToProps)(App);
export default AppReduxWrapped;

