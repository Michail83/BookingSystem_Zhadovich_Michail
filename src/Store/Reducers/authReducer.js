import {initialAuth } from '../initialState';
import * as actionTypeList from "../Actions/actionTypeList";

 function authReducer(state =  initialAuth(), action) {
     switch (action.type) {
         case actionTypeList.setAuth: return {...action.authData };
        
        default: return state;
    }
}
export default authReducer;