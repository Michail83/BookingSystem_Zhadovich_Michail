import urls from "../API_URL";
import store from "../Store/store";
import axios from "axios";
import actionsCreator from "../Store/ActionsCreators/actionCreator"; 

export const tryLoadAuthData = async () => {
    try {
        const result = await axios.get(urls.getLoginInfo());
        if (result.status == 200) {
            store.dispatch(actionsCreator.setAuth(result.data));
        }           
    } catch (e) {
        console.log(`tryLoadAuthData    ${e}`)
    }
}