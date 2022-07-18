import  axios  from "axios";
import urls from '../../../API_URL';
import { useNavigate } from "react-router-dom";

export const deleteArtEvent = async (id)=>{    
    let answer = window.confirm("do you want to delete this ART EVENT");

    if (answer) {   
        const result = await axios.delete(urls.getArtEvents(id));
        if (result.status==200) {
            return true;        
        } 
    }
    return false
};
