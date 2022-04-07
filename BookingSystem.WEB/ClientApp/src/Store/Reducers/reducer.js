// import SetIDToken from '../Actions/SetIDToken'
// import {SetIsAuthenticated} from '../Actions/SetIsAuthenticated'
import initialState from '../initialState';
import * as actionTypeList from "../Actions/actionTypeList"
import actionCreator from '../ActionsCreators/actionCreator';


function addToCart(cartMap, id){

    if (cartMap.has(id)) {
        return cartMap;
    }
    let newCartMap = new Map(cartMap);

    // console.log("Cart is not found" );
        
    newCartMap.set(id,1)
    console.log("reducer-addToCart work ");
    console.log(newCartMap);
    return newCartMap;
}

//ограничивать значения будет кнопка
function changeCartItemValue(cartMap, cartItem) {    
    
    let newCartMap = new Map(cartMap);
    newCartMap.set(cartItem.id, cartItem.quantity)

    console.log("reducer-changeCartItemValue work ");
    console.log(newCartMap);
    
    return newCartMap;
}
function deleteFromCart(cartList, id) {
    let indexOfCart = cartList.findIndex(cart=>cart.id === id);    
    if (indexOfCart == -1 ) {
        return cartList;        
    }
    let newCartList = cartList.slice();
    newCartList.splice(indexOfCart,1) 
    return newCartList;    
}
function reducer(state=initialState, action) {
    switch(action.type) {
        // case actionTypeList.SetIDToken:         return Object.assign({}, state, {IDToken:action.token});
       case actionTypeList.SetIsAuthenticated: return Object.assign({}, state, {isAuthenticated:action.isItTrue});


        // current
        case actionTypeList.addToCart:          return Object.assign({}, state, {cartMap: addToCart(state.cartMap, action.id) });
    
        case actionTypeList.changeCartItemValue:     return Object.assign({}, state, {cartMap:changeCartItemValue(state.cartMap, action.cart) });
        // case actionTypeList.deleteFromCart:     return Object.assign({}, state, {cartList:deleteFromCart(state.cartList, action.id) });
        case actionTypeList.iSmodalLoginWindowActive: return Object.assign({}, state, { iSmodalLoginWindowActive: action.isActive });
        
        default: return state;
    }
}
export default reducer;