import  axios  from "axios";
import urls from '../../../API_URL';

import { unAuthorizedHandler } from "../../../function/unAuthorizedHandler";

export const deleteArtEventAsync = async (id)=>{    
    let answer = window.confirm("do you want to delete this ART EVENT from DB");    

    if (answer) {  
        try {
            const result = await axios.delete(urls.getArtEvents(id));

        if (result.status==200) return true;
        } catch (error) {
            unAuthorizedHandler(error.response.status)
            return false;
        }
    }
    return false;
};
