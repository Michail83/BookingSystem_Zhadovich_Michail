import * as keys from "../CONST/KeysForLocalStorage"

export const setCartMapToLocalStorage = (cartMap) => {
    if (cartMap.size) {
        let cart_obj = Object.fromEntries(cartMap.entries());
        localStorage.setItem(keys.localStorage_cartMap, JSON.stringify(cart_obj));
    } else {
        localStorage.removeItem(keys.localStorage_cartMap);
    }

    

}
 
