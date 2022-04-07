import urls from  '../../API_URL'
import  axios from "axios"; 
import React, { useState, useEffect } from "react" 
function LogoutBtn() {

   const  logout= async ()=>{
       try {
        const logoutresult = await axios.get(urls.logout());
           
       } catch (error) {
           console.log(error)           
       }
    };
    return(
        <button onClick={logout} >Logout</button>
    );
}
export default LogoutBtn