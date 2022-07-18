import urls from  '../../API_URL'
import  axios from "axios"; 
import React, { useState, useEffect } from "react"
import { connect } from "react-redux";
import actionCreator from "../../Store/ActionsCreators/actionCreator"

function LogoutBtn({ setAuthFalse }) {
   const  logout= async ()=>{
       try {
           const logoutresult = await axios.get(urls.logout());           
           if (logoutresult.status == 200) {
               console.log(`logout status  ok`);
               setAuthFalse();
           }           
       } catch (error) {
           console.log(error)           
       }
    };
    return(
        <button onClick={logout} >Logout</button>
    );
}

const mapDispatchToProps = dispatch => (
    {
        setAuthFalse: () => {
            dispatch(actionCreator.setAuth({
                isAuthenticated: false,
                userName: "",
                userEmail: "",
                isAdmin: false
            }));
            dispatch(actionCreator.clearAdmins());
        }
    });

let LogoutBtn_ReduxWrapped = connect(null, mapDispatchToProps)(LogoutBtn);
export default LogoutBtn_ReduxWrapped;