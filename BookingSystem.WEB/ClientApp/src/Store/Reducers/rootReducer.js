import {combineReducers} from 'redux';

import authReducer from "./authReducer";
import cartReducer from "./cartReducer";
import stateReducer from "./stateReducer";
import admins from "./adminsReducer";
import creatingTempDataReducer from './Creating/baseReducer';
import openAirReducer from './Creating/openAirReducer';

export const rootReducer = combineReducers({
    auth: authReducer ,
    cart: cartReducer ,
    state: stateReducer,
    admins: admins,
    // creatingBaseData:creatingTempDataReducer,
    // creatingOpenAir:openAirReducer

});