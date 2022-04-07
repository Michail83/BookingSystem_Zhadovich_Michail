import axios from "axios";
import apiUrls from "../../../API_URL"

async function  CheckCartItemQuerry(cart) {
    let checkResult;
    try {
         checkResult = await axios.get(apiUrls.CheckCartItemQuerry(cart))
        
    } catch (error) {
      console.log(error)  
    }
    return checkResult;
}
export default CheckCartItemQuerry;