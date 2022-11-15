import axios from "axios";
import api_url from "../../../API_URL";
import { unAuthorizedHandler } from "../../../function/unAuthorizedHandler";
import { createBaseFormData } from "./createBaseFormData";

const onSubmitPartyEditFunction = (setStatusOfCreating, id) => {
    
    return async function createFunction(data, event){
        event.preventDefault();
    const config = {
        headers: {
          'content-type': 'multipart/form-data',
        },
      };
      const formData = createBaseFormData(data);
    
      formData.append('Id', id);
      formData.append('AgeLimitation', data.ageLimitation);
      formData.append('Image', data.image[0]??null) 
      console.log(formData.entries())       

    try {
        let result = await axios.put(api_url.parties(), formData, config );
        if (result.status == 200) {
            setStatusOfCreating(true);
            
        }
    } catch (error) {
        unAuthorizedHandler(error.response.status);
        setStatusOfCreating(false);
    }
    }  
}
export default onSubmitPartyEditFunction;