import { getCartMapFromLocalStorage } from '../function/getCartMapFromLocalStorage';

export const initialAuth = () => {
    return {
        isAuthenticated: null,
        userName: "",
        userEmail: "",
        isAdmin: false,
        isLocked: null
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
    origin:"",
    artEventItems: [],
    filteringData: { ...partOfInitialState_FilteringData, ...partOfInitialState_PaginationData }
}

export const initialAdmins = {
    DeleteArtEventButton: "",
    userList:[]
}