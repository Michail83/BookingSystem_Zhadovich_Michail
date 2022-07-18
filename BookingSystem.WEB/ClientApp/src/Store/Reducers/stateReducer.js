import {initialState, partOfInitialState_FilteringData } from '../initialState';
import * as actionTypeList from "../Actions/actionTypeList"
import { act } from '@testing-library/react';

function stateReducer(state = initialState, action) {
    switch(action.type) {        
        case actionTypeList.iSmodalLoginWindowActive: return { ...state, iSmodalLoginWindowActive: action.iSmodalLoginWindowActive };
        case actionTypeList.SetArtEventItems: return {...state, artEventItems: action.artEventItems};
        case actionTypeList.setFilteringData: return {...state, filteringData: action.filteringData};
        case actionTypeList.setFilteringDataToDefault: return {...state, filteringData: partOfInitialState_FilteringData }
        
        default: return state;
    }
}
export default stateReducer;