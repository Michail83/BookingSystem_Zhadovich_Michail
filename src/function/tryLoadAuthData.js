import urls from "../API_URL";
import store from "../Store/store";
import axios from "axios";
import actionsCreator from "../Store/ActionsCreators/actionCreator"; 
import {initialAuth} from "../Store/initialState"


export const tryLoadAuthData = async () => {
    let auth;
    try {
        const result = await axios.get(urls.getLoginInfo());
        if (result.status == 200) {
            auth= result.data;            
        }           
    } catch (error) {        
        store.dispatch(actionsCreator.clearAdmins());  
        auth= initialAuth;      
    }
    finally{
        store.dispatch(actionsCreator.setAuth(auth));
    }
}