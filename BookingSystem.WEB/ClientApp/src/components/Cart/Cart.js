import React, {useState, useEffect} from "react";
import { connect } from "react-redux";
import axios from "axios";
import ChangeValueInCartButton_ReduxWrapped from "./cartButton/changeValueInCartButton"
import "./Cart.css"
import urls from "../../API_URL"
import RowInMainTable from "../RowInMainTable/RowInMainTable";    
import actionCreator from "../../Store/ActionsCreators/actionCreator";

const Cart = ({ cartMap, fullCartArray, setFullCartArray})=>{

    const [isLoading, setIsLoading] = useState(true);  
                /*const [fullCartMap, setFullCartMap] = useState(null);*/
    const [errorMessage, setErrorMessage] = useState(null);

    useEffect(async ()=>{
        try {
            if (cartMap === undefined || cartMap.size === 0) {
                return;
            }
            setIsLoading(true);
            let arrayOfKeys = Array.from(cartMap.keys(), (key) => key);            
            const result = await axios.get(urls.getFullCheckedListForCart(arrayOfKeys));
            setFullCartArray(result.data);            

        } catch (error) {            
            setErrorMessage(error);
        }
        finally {
            setIsLoading(false);
        }
    },[]);

    let elemenList=[];

    //кошмар какой то 
    if (isLoading) {
        elemenList = <div>Loading....</div>        
    } else {
         if (    errorMessage   ) {
        elemenList="fail";        
        } else{
            if (cartMap === undefined || cartMap.size=== 0) {    
                elemenList = <div>Your cart is empty</div>    
            } else {
                let itemsInTable = fullCartArray.map((item) => (<RowInMainTable key={item.id} item={item} buttonType={"changebutton"}/>));
                elemenList = <table>
                    <colgroup>
                    <col width="5%"></col>
                    <col width="10%"></col>
                    <col width="15%"></col>
                    <col width="18%"></col>
                    <col width="18%"></col>
                    <col width="20%"></col>
                    <col width="15%"></col>
                    </colgroup>
                        <tbody>
                            {itemsInTable}
                        </tbody>
                    </table>           
            }
        }            
    }
        return(
            <div className="mainCart">            
            {elemenList}                
            </div>
    )
}
const mapStateToProps=(state)=> ({ 
    cartMap: state.cart.cartMap,
    fullCartArray: state.cart.fullCartArray

}); 
const mapDispatchToProps = dispatch => ({
    setFullCartArray: (fullCartArray) => dispatch(actionCreator.setFullCartArray(fullCartArray))
});

let Cart_ReduxWrapped = connect(mapStateToProps, mapDispatchToProps)(Cart);
export default Cart_ReduxWrapped;