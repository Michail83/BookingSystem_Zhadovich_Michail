import React, { useState, useEffect } from "react";
import { Link, useNavigate } from "react-router-dom"
import "../UniversalHeader/UniversalHeader"
// import axios from "axios";
import LogoutBtn from "../Logout/LogoutBtn"
// import urls from "../../API_URL"
// import state from '../../Store/store'
import { connect } from "react-redux";
import store from "../../Store/store"
import actionsCreator from "../../Store/ActionsCreators/actionCreator"

// import { bindActionCreators } from "redux";
// import SetIsAuthenticated from "../../Store/ActionsCreators/SetIsAuthenticated";
// import store from "../../Store/store";



const LogInOutManager = ({ auth }) => {

    const showButton = () => {
        let element;        
        if (auth.isAuthenticated) {
            element =   
                            <LogoutBtn />
                        
        } else {
            element =
                
                    <button onClick={() => store.dispatch(actionsCreator.setModalWindowForLoginActive(true))} > Login </button>
                           
        }
        return element;
    }
    return showButton();
}
const mapStateToProps = state => ({
    auth: state.auth
});

const mapDispatchToProps = dispatch => (
    {
        // isAuthenticated: result => dispatch(SetIsAuthenticated(result)),
    });

var LogInOutManager_connected = connect(mapStateToProps, mapDispatchToProps)(LogInOutManager);

export default LogInOutManager_connected;




















///////////////////////////////////////////////////////


////import React, {useState, useEffect} from "react";
////import { Link, useNavigate } from "react-router-dom"
////import "../UniversalHeader/UniversalHeader"
////// import axios from "axios";
////import LogoutBtn from "../Logout/LogoutBtn"
////// import urls from "../../API_URL"
////// import state from '../../Store/store'
////import { connect } from "react-redux";
////// import { bindActionCreators } from "redux";
////// import SetIsAuthenticated from "../../Store/ActionsCreators/SetIsAuthenticated";
////// import store from "../../Store/store";


////const LogInOutManager= ({isAuthenticated}) => {
////    // const [loginData, SetloginData] = useState(null);
////    // useEffect(()=>{
////    //     // loadLogInfo();
////    // },[]);

////    // const loadLogInfo = async ()=>{
////    //     try {
////    //         let result = await axios.get(urls.getLoginInfo()) 
////    //         SetloginData(result.data);
            
////    //     } catch (error) {
////    //         console.log("LoginOutManager line 20 =  "+error)
            
////    //     }
////    // }
////   const showButton=() =>{
////       let element;
////    //      this.props.isAuthenticated
////    // console.log("LoginOutManager   = " + isAuthenticated);
////       if (isAuthenticated) {   
////            element = <LogoutBtn/>
////        } else {
////           element = <div className="nav-block"><Link to="/login">Login</Link></div>           
////        }
////       return element;
////   }
////   return showButton();

////}
////const mapStateToProps=state=> ({    
////    isAuthenticated: state.isAuthenticated        
////});

////const mapDispatchToProps=dispatch=> (
////    {        
////        // isAuthenticated: result => dispatch(SetIsAuthenticated(result)),
////    });

////var LogInOutManager_connected = connect(mapStateToProps, mapDispatchToProps)(LogInOutManager);

////// export default LogInOutManager;
////export default LogInOutManager_connected;