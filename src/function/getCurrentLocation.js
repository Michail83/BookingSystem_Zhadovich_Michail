import store from "../Store/store";
import actionsCreator from "../Store/ActionsCreators/actionCreator";

export const getCurrentLocation =  () => {
    
    let location = window.location.origin;
    
        store.dispatch(actionsCreator.setOriginLocation(location));    
}