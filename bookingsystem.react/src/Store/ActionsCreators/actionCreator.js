import * as actionTypeList from "../Actions/actionTypeList"

export default {
    setIdToken: (token) => ({
        type: actionTypeList.SetIDToken,
        token: token
    }),
    setIsAuthenticated : (isItTrue)=>({
        type:actionTypeList.SetIsAuthenticated,
        isItTrue
    }),
     addToCart: (id) => ({
         type: actionTypeList.addToCart,
         id
     }),
     deleteValueFromCart: (cart)=>({
         type: actionTypeList.deleteValueFromCart,
         cart
     }),
     deleteFromCart : (id)=>({
         type: actionTypeList.deleteFromCart,
         id
     }),
     changeCartItemValue :(cart)=>({
         type: actionTypeList.changeCartItemValue,
         cart
     }),
    setModalWindowForLoginActive: (isActive) => ({
        type: actionTypeList.iSmodalLoginWindowActive,
        isActive
    })
}