import React from "react";
import axios from "axios";
import api_url from "../../../API_URL";
import { unAuthorizedHandler } from "../../../function/unAuthorizedHandler";


const onSubmitOpenAirEditFunction = (setStatusOfCreating, id) => {
    
    return async function createFunction(data, event){
        event.preventDefault();
    const config = {
        headers: {
          'content-type': 'multipart/form-data',
        },
      };
      const formData = new FormData();    
      formData.append('Id', id);

      formData.append('EventName', data.eventName);
      formData.append('Date', data.date);
      formData.append('AmountOfTickets', data.amountOfTickets);
      formData.append('Place', data.place);
      formData.append('Price', data.price);          
      formData.append('Latitude', data.latitude);
      formData.append('Longitude', data.longitude);
      formData.append('HeadLiner', data.headLiner);
      formData.append('Image', data.image[0]) 
      console.log(formData);       

    try {
        let result = await axios.put(api_url.openairs(), formData, config );
        if (result.status == 200) {
            setStatusOfCreating(true);
            
        }
    } catch (error) {
        unAuthorizedHandler(error.response.status);
        setStatusOfCreating(false);
        
        
    }

    }
    
    
}
export default onSubmitOpenAirEditFunction;