import urls from  '../../API_URL'
import  axios from "axios"; 
import React, { useState, useEffect } from "react"
import { connect } from "react-redux";
import actionCreator from "../../Store/ActionsCreators/actionCreator";
import { useNavigate } from 'react-router-dom';

import { initialAuth } from '../../Store/initialState';

function LogoutBtn({ setAuthFalse }) {
    const navigate = useNavigate(); 
   const  logout= async ()=>{
       try {
           const logoutresult = await axios.get(urls.logout());           
           if (logoutresult.status == 200) {
               console.log(`logout status  ok`);
               setAuthFalse();
               navigate("/");
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
            dispatch(actionCreator.setAuth(initialAuth));
            dispatch(actionCreator.clearAdmins());
        }
    });

let LogoutBtn_ReduxWrapped = connect(null, mapDispatchToProps)(LogoutBtn);
export default LogoutBtn_ReduxWrapped;