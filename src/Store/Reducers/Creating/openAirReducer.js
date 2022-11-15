import {initialCreatingOpenAir } from '../../initialState';
import * as actionTypeList from "../../Actions/actionTypeList"
;

function openAirReducer(state = initialCreatingOpenAir, action) {
    switch(action.type) {        
        case actionTypeList.setAdditionalOpenAirCreatingData: return { ...state, ...action.payload };

        // case actionTypeList.ClearALLCreatingData: return {...initialCreatingOpenAir};        
        default: return state;
    }
}
export default openAirReducer;