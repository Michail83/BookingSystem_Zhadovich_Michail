import axios from "axios";
import store from "../../Store/store"

const createNewArtEvent =async (url, type)=>{
    let data =  {...store.getState()[type],...store.getState().creatingBaseData};
    
    try {
        let result= await axios.post(url,data);
        
        if ( result.status==200) { 
            return result.status;           
        }

    } catch (error) {
        console.log(error);  
    }
}
export default createNewArtEvent;