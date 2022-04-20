import * as actionTypeList from "../Actions/actionTypeList"

export default {
    setIdToken: (token) => ({
        type: actionTypeList.SetIDToken,
        token: token
    }),    
     addToCart: (id) => ({
         type: actionTypeList.addToCart,
         id
     }),     
     deleteFromCart : (id)=>({
         type: actionTypeList.deleteFromCart,
         id
     }),
     changeCartItemValue :(cart)=>({
         type: actionTypeList.changeCartItemValue,
         cart
     }),
    setModalWindowForLoginActive: (iSmodalLoginWindowActive) => ({
        type: actionTypeList.iSmodalLoginWindowActive,
        iSmodalLoginWindowActive
    }),    
    setFullCartArray: (fullCartArray) => ({
        type: actionTypeList.setFullCartArray,
        fullCartArray
    }),
    deleteFromCartArray: (id) => ({
        type: actionTypeList.deleteFromCartArray,
        id
    }),
    setAuth: (authData) => ({
        type: actionTypeList.setAuth,
        authData
    }),
    clearCart: ()=>({
        type: actionTypeList.clearCart
    })
}