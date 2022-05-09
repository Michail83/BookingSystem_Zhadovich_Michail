import {initialState } from '../initialState';
import * as actionTypeList from "../Actions/actionTypeList"
import { act } from '@testing-library/react';

function stateReducer(state = initialState, action) {
    switch(action.type) {        
        case actionTypeList.iSmodalLoginWindowActive: return { ...state, iSmodalLoginWindowActive: action.iSmodalLoginWindowActive };
        case actionTypeList.SetArtEventItems: return {...state, artEventItems: action.artEventItems};
        case actionTypeList.setFilteringData: return {...state, filteringData: action.filteringData}
        
        default: return state;
    }
}
export default stateReducer;