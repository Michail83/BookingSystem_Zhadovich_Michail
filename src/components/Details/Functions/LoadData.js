import  axios  from "axios";

const loadData = async (url, setStateValue)=>{    
    try {
        const result = await axios.get(url);
        setStateValue(result.data);        
    } catch (error) {
        console.log(error);
    } finally {
        
    }
};
export default loadData;