import React from "react";
import axios from "axios";
import api_url from "../../../API_URL";
import { unAuthorizedHandler } from "../../../function/unAuthorizedHandler";
import { createBaseFormData } from "./createBaseFormData";


const onSubmitClassicMusicCreateFunction = (setStatusOfCreating) => {
    
    return async function createFunction(data, event){
        event.preventDefault();
    const config = {
        headers: {
          'content-type': 'multipart/form-data',
        },
      };
      let formData= createBaseFormData(data);    

      formData.append('Voice', data.voice);
      formData.append('ConcertName', data.concertName);

      formData.append('Image', data.image[0]) 
         

    try {
        let result = await axios.post(api_url.classicmusics(), formData, config );
        if (result.status == 200) {
            setStatusOfCreating(true);
            
        }
    } catch (error) {
        unAuthorizedHandler(error.response.status);
        setStatusOfCreating(false);
        
        
    }

    }
    
    
}
export default onSubmitClassicMusicCreateFunction;