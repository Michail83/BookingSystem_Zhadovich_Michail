
export const mapToOrderData =(MapCart)=> {
    let result = [];

    MapCart.forEach((value, key) => {
        result.push({EventId:key,Quantity:value});        
      });
    return result;
}