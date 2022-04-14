import {combineReducers} from 'redux';
import authReducer from "./authReducer";
import cartReducer from "./cartReducer";
import stateReducer from "./stateReducer";

export const rootReducer = combineReducers({
    auth: authReducer ,
    cart: cartReducer ,
    state: stateReducer
});