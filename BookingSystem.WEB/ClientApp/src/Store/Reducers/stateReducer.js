import {initialState } from '../initialState';
import * as actionTypeList from "../Actions/actionTypeList"

function stateReducer(state = initialState, action) {
    switch(action.type) {        
        case actionTypeList.iSmodalLoginWindowActive: return { ...state, iSmodalLoginWindowActive: action.iSmodalLoginWindowActive };
        
        default: return state;
    }
}
export default stateReducer;