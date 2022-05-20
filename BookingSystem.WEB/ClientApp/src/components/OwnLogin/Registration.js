import React, { useState, useEffect } from "react";
import { useNavigate } from "react-router-dom";
import axios from "axios";
import { connect } from "react-redux";
import urls from "../../API_URL"
import actionCreator from "../../Store/ActionsCreators/actionCreator";

import ExternalLoginList from "../ExternalLogin/ExternalLoginList"
import { setFilteringData } from "../../Store/Actions/actionTypeList";


const Registration =  () => {

    const [userName, setUserName] = useState("qwe");
    const [email, setEmail] = useState("Sklif83@tut.by");
    const [password, setPassword] = useState("qwe123");
    const [error, SetError] = useState([]);
    // const [confirmPassword, setConfirmPassword] = useState();
    let navigate = useNavigate();


    const submitHandler = async (event)=>{  
        event.preventDefault();
        // event.stopPropagation();    

        try {
            // console.log(" "+ userName + email + password);
            // console.log(urls.register());
            let result = await axios.post(urls.register(),{
                userName:userName,
                email:email,
                password:password
            });
            navigate("/");
            // console.log(result);
        } catch (error) {

            switch(error.response.status){                                
                case 400:
                    console.log(error.response.data);
                    let data = error.response.data;
                            console.log(error.response.data);
                    let errorsList =data.map((item)=>{
                        return (<li>{item.description} </li>)
                    });
                    console.log(errorsList);
                    SetError(errorsList );
                break;
                case 503:
                    SetError("Mail cannot send, , try later...")                    
                break;
                
            }
            // console.log(error.response.data);
            // console.log(error.response.status);
            // console.log(error.response.headers);
            
        }
    }

    return (
        <div className="Registration" >
            <form  onSubmit={submitHandler}>
                <div><label> Name <input type="text" required  onChange={(event)=>setUserName(event.target.value)}/></label></div>

                <div><label>Email <input type="email" required onChange={(event)=>setEmail(event.target.value)}/></label></div>

                <div><label> Password<input type="password" id="password" required minLength={4} onChange={(event)=>setPassword(event.target.value)} /></label></div>
                <button type="submit"> Register</button>
            </form>
            <ul>
                {error}
            </ul>
        </div>
    )
}

const mapStateToProps = state => ({
    // IsAuthenticated: state.auth.isAuthenticated,    
    // isActive: state.state.iSmodalLoginWindowActive
});
const mapDispatchToProps = dispatch => (
    {
        // setNoActive:()=> dispatch(actionCreator.setModalWindowForLoginActive(false))        
    });
var Registration_ReduxWrapped = connect(mapStateToProps, mapDispatchToProps)(Registration);



export default Registration;