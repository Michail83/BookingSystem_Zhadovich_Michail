import api_url from "../../API_URL";
import axios from "axios";
export const getOrdersForAdmin = async (setOrders, email) => {
    try {
        let result = await axios.get(api_url.getOrdersForAdmin(email));
        setOrders(result.data);

    } catch (error) {
        console.log("Orders.getOrders  error =  " + error)
    }
}