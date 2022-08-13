import * as keys from "../CONST/KeysForLocalStorage";

export const getCartMapFromLocalStorage = () => {
    let cartMap = new Map();
    try {
        let jsonData = localStorage.getItem(keys.localStorage_cartMap);

        let cartMap_obj = JSON.parse(jsonData);
        let cartMap_array = Object.keys(cartMap_obj).map((key) => [Number.parseInt(key), cartMap_obj[key]]);
         cartMap = new Map(cartMap_array);
        
    } catch (e) {
        console.log(`getMapFromLocalStorage. error= ${e}`);
    }
    //console.log("getCartMapFromLocalStorage ");
    return cartMap;
}
/*export default getCartMapFromLocalStorage;*/