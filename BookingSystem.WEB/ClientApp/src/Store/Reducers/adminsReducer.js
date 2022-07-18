import {initialAdmins } from '../initialState';
import * as actionTypeList from "../Actions/actionTypeList";

 function adminsReducer(state =  initialAdmins, action) {
     switch (action.type) {
         case actionTypeList.setDeleteArtEventButton: return {...state, DeleteArtEventButton:action.DeleteArtEventButton };
         case actionTypeList.clearAdmins : return {...initialAdmins};
       
        default: return state;
    }
}
export default adminsReducer;