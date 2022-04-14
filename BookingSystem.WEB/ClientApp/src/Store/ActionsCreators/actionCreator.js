import * as actionTypeList from "../Actions/actionTypeList"

export default {
    setIdToken: (token) => ({
        type: actionTypeList.SetIDToken,
        token: token
    }),
    //setIsAuthenticated: (isAuthenticated)=>({
    //    type:actionTypeList.SetIsAuthenticated,
    //    isAuthenticated
    //}),
     addToCart: (id) => ({
         type: actionTypeList.addToCart,
         id
     }),
     //deleteValueFromCart: (cart)=>({
     //    type: actionTypeList.deleteValueFromCart,
     //    cart
     //}),
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
    //setUserName: (userName) => ({
    //    type: actionTypeList.setUserName,
    //    userName
    //}),
    //setUserEmail: (userEmail) => ({
    //    type: actionTypeList.setUserEmail,
    //    userEmail
    //}),
    //setIsAdmin: (isAdmin) => ({
    //    type: actionTypeList.setIsAdmin,
    //    isAdmin
    //}),
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
}