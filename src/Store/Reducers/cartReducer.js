import { initialCart } from '../initialState';
import * as actionTypeList from "../Actions/actionTypeList";

function cartReducer(state = initialCart, action) {
    switch (action.type) {
        case actionTypeList.addToCart:
            return { ...state, cartMap: addToCart(state.cartMap, action.id) };

        case actionTypeList.changeCartItemValue:
            return { ...state, cartMap: changeCartItemValue(state.cartMap, action.cart) };

        case actionTypeList.deleteFromCart:
            return { ...state, cartMap: deleteFromCart(state.cartMap, action.id) };

        case actionTypeList.setFullCartArray:
            return { ...state, fullCartArray: action.fullCartArray };

        case actionTypeList.deleteFromCartArray:
            return { ...state, fullCartArray: deleteFromCartArrayById(state.fullCartArray, action.id) };

        case actionTypeList.clearCart:   

            return { ...state, cartMap: action.payload || new Map() }

        default: return state;
    }
}

function addToCart(cartMap, id) {
    if (cartMap.has(id)) {
        return cartMap;
    }
    let newCartMap = new Map(cartMap);
    newCartMap.set(id, 1)    
    return newCartMap;
}

function changeCartItemValue(cartMap, cartItem) {

    let newCartMap = new Map(cartMap);
    newCartMap.set(cartItem.id, cartItem.quantity)
   
    return newCartMap;
}

function deleteFromCart(cartMap, id) {    
    let newCartMap = new Map(cartMap);
    if (newCartMap.delete(id)) {        
        return newCartMap;
    }
    return cartMap;
}

function deleteFromCartArrayById(cartArray, id) {
    return cartArray.filter((item) => item.id !== id);
}

export default cartReducer;