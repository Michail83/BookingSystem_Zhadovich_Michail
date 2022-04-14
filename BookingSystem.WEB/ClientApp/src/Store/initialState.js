import { getCartMapFromLocalStorage } from '../function/getCartMapFromLocalStorage';

export const initialAuth =  () => {
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
export const initialState = {
    iSmodalLoginWindowActive: false
}