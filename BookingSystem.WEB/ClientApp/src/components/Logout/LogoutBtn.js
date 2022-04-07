import urls from  '../../API_URL'
import  axios from "axios"; 
import React, { useState, useEffect } from "react"
import { connect } from "react-redux";
import actionCreator from "../../Store/ActionsCreators/actionCreator"

function LogoutBtn({ setAuthenticatedFalse }) {
   const  logout= async ()=>{
       try {
           const logoutresult = await axios.get(urls.logout());           
           if (logoutresult) {
               console.log(`logout status ${logoutresult.status}`);
               setAuthenticatedFalse();
           }           
       } catch (error) {
           console.log(error)           
       }
    };
    return(
        <button onClick={logout} >Logout</button>
    );
}

//const mapStateToProps = (state) => ({
//    isAuthenticated: state.isAuthenticated
//});
const mapDispatchToProps = dispatch => (
    {
        setAuthenticatedFalse: () => dispatch(actionCreator.setIsAuthenticated(false))
    });

let LogoutBtn_ReduxWrapped = connect(null, mapDispatchToProps)(LogoutBtn);
export default LogoutBtn_ReduxWrapped;