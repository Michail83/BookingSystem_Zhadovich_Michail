import * as actionList from '../Actions/actionTypeList';

import { setCartMapToLocalStorage } from "../../function/setCartMapToLocalStorage.js";

export const syncLocalStorageMidlleware = store => next => action => {
    next(action);
    if ((action.type === actionList.addToCart || action.type === actionList.changeCartItemValue || action.type === actionList.deleteFromCart ||actionList.clearCart)) {
        let cartMap = store.getState().cart.cartMap;

        setCartMapToLocalStorage(cartMap);
    }    
}