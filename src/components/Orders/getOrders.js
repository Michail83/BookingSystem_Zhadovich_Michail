import api_url from "../../API_URL";
import axios from "axios";
export const getOrders = async (setOrders) => {
    try {
        let result = await axios.get(api_url.getOrders());
        setOrders(result.data);

    } catch (error) {
        console.log("Orders.getOrders  error =  " + error)
    }
}