import * as actionList from '../Actions/actionTypeList';
/*import { mapToJson }  from "../../function/stringifyMap";*/
import { setCartMapToLocalStorage } from "../../function/setCartMapToLocalStorage.js";

export const syncLocalStorageMidlleware = store => next => action => {
    next(action);
    if ((action.type == actionList.addToCart || action.type == actionList.changeCartItemValue || action.type == actionList.deleteFromCart)) {
        let cartMap = store.getState().cart.cartMap;
        setCartMapToLocalStorage(cartMap);
    }    
}