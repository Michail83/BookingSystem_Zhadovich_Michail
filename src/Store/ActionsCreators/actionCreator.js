import * as actionTypeList from "../Actions/actionTypeList"

 const actionsCreater  = {
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
    clearCart: (cartMap)=>({        
        type: actionTypeList.clearCart,
        payload: cartMap
    }),
    SetArtEventItems: (artEventItems)=>({
        type: actionTypeList.SetArtEventItems,
        artEventItems
    }),
    setFilteringData: (filteringData)=>({
        type: actionTypeList.setFilteringData,
        filteringData
    }),
    setDeleteArtEventButton:(DeleteArtEventButton)=>({
        type: actionTypeList.setDeleteArtEventButton,
        DeleteArtEventButton
    }),
    clearAdmins: ()=>({
        type: actionTypeList.clearAdmins
    }),
    
    setBaseCreatingData:(additionData)=>({
        type: actionTypeList.setBaseCreatingData,
        payload:additionData
    }),    
    setFilteringDataToDefault:()=>({
        type: actionTypeList.setFilteringDataToDefault
    }),
    setCurrentPage:(number)=>({
        type:actionTypeList.setCurrentPage,
        payload:number
    }),
    setPaginationData:(paginationData)=>({
        type:actionTypeList.setPaginationData,
        payload:paginationData
    })


}

export default  actionsCreater;