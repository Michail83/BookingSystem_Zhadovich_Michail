import {initialState, partOfInitialState_FilteringData, partOfInitialState_PaginationData } from '../initialState';
import * as actionTypeList from "../Actions/actionTypeList"
import { act } from '@testing-library/react';

function stateReducer(state = initialState, action) {
    switch (action.type) {
        case actionTypeList.iSmodalLoginWindowActive:
            return { ...state, iSmodalLoginWindowActive: action.iSmodalLoginWindowActive };
        case actionTypeList.SetArtEventItems:
            return { ...state, artEventItems: action.artEventItems };

        case actionTypeList.setFilteringData:
            return { ...state, filteringData: { ...state.filteringData, ...action.filteringData } };

        case actionTypeList.setFilteringDataToDefault:
            return { ...state, filteringData:{...partOfInitialState_FilteringData, ...partOfInitialState_PaginationData} };
       
            case actionTypeList.setCurrentPage:
            return {...state, filteringData: {
                 ...state.filteringData,
                  currentPage:validatePage(state.filteringData.totalPages, action.payload)   }}

            case actionTypeList.setPaginationData:
                return{...state, filteringData: { ...state.filteringData, ...action.payload }}

        default: return state;
    }
}
export default stateReducer;


//middleware?
function validatePage(total, newPage){
    if (newPage<1) {
        return 1;
    }
    if (newPage>total) {
        return total;
    }
    return newPage;
}