import * as keys from "../CONST/KeysForLocalStorage";

export const getCartMapFromLocalStorage = () => {
    let cartMap = new Map();
    try {
        let jsonData = localStorage.getItem(keys.localStorage_cartMap);

        let cartMap_obj = JSON.parse(jsonData);   

             let cartMap_array=[];
               Object.keys(cartMap_obj).forEach((key) => {

            let keyNumber = Number.parseInt(key);
            let quantity = Number.parseInt(cartMap_obj[key]);

            if ((keyNumber===0 || keyNumber) &&  quantity) {
                cartMap_array.push([keyNumber, quantity]);
            }
        });

         cartMap = new Map(cartMap_array);
        
    } catch (e) {
        console.log(`No Local data`);
    } 
    return cartMap;
}
