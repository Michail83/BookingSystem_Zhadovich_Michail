import { getCartMapFromLocalStorage } from '../function/getCartMapFromLocalStorage';
// import { FieldsNameForCreateArtEvent } from '../CONST/FieldsNameForBaseCreateForm';
// import { HEADLINER } from '../CONST/FieldsNameForOPENAIRCreateForm';

export const initialAuth = () => {
    return {
        isAuthenticated: null,
        userName: "",
        userEmail: "",
        isAdmin: false
    }
}
export const initialCart = {
    cartMap: getCartMapFromLocalStorage(),
    fullCartArray: []
}
export const partOfInitialState_FilteringData = {
    sortBy: 'AmountOfTickets',
    nameForFilter: '',
    typeForFilter: '',


}
export const partOfInitialState_PaginationData = {
    totalItemsCount: '',
    pageSize: 5,
    currentPage: 1,
    totalPages: '',
    hasNext: '',
    hasPrevious: '',
    pageNeighbours: 1
}

export const initialState = {
    iSmodalLoginWindowActive: false,
    artEventItems: [],
    filteringData: { ...partOfInitialState_FilteringData, ...partOfInitialState_PaginationData }
}

export const initialAdmins = {
    DeleteArtEventButton: "",
}

// export const initialCreatingTempData={
//     [FieldsNameForCreateArtEvent.AMOUNTOFTICKET]:"",
//     [FieldsNameForCreateArtEvent.ARTEVENTNAME]:"",
//     [FieldsNameForCreateArtEvent.DATETIME]:"",
//     [FieldsNameForCreateArtEvent.LATITUDE]:"",
//     [FieldsNameForCreateArtEvent.LONGITUDE]:"",
//     [FieldsNameForCreateArtEvent.PLACE]:""
// }
// export const initialCreatingParty={

// }
// export const initialCreatingOpenAir={
//     [HEADLINER]:""
// }
// export const initialCreatingClasicMusic={

// }