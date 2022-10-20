// import axios from "axios";
// import api_url from "../../../API_URL";

// const EditFormLoadEventAsync =(id, artEventType)=>{

//     consolr.log(artEventType);
//     let url;

//     switch (artEventType) {
//         case "ClassicMusic":           
//         url = api_url.classicmusics(id);
//         break;

//         case "Party":
//             url = api_url.parties(id); 
//             break;

//         case "OpenAir": 
//         url = api_url.openairs(id);      
//             break;
    

//         default:
//             break;
//     }

//     const getArtEvent = async()=>{

//         try {
//             const result = await axios.get(url)
//             return result.data;
//         } catch (error) {
//             return null;
//         }        
//     };
//     return getArtEvent();
// }
// export default EditFormLoadEventAsync;