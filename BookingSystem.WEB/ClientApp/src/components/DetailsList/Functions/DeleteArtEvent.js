import  axios  from "axios";
import urls from '../../../API_URL';
import { useNavigate } from "react-router-dom";

export const deleteArtEvent = async (id)=>{
    let url = urls.getArtEvents(id);
    // url.searchParams.set("id", id);
    let answer = window.confirm("do you want to delete this ART EVENT");    

    //???   error handling
    if (answer) {   
        const result = await axios.delete(url);
    }    
};
