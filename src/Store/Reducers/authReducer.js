import {initialAuth } from '../initialState';
import * as actionTypeList from "../Actions/actionTypeList";


 function authReducer(state =  initialAuth(), action) {
     switch (action.type) {
         case actionTypeList.setAuth: return {/* ...state, */...action.authData };


        //case actionTypeList.SetIsAuthenticated: return { ...state, isAuthenticated: action.isAuthenticated };
        //case actionTypeList.setUserName:        return { ...state, userName: action.userName };
        //case actionTypeList.setUserEmail:       return { ...state, userEmail: action.userEmail };
        //case actionTypeList.setIsAdmin:         return { ...state, isAdmin: action.isAdmin };
        
        default: return state;
    }
}
export default authReducer;