import React, {useState, useEffect} from "react";
import { connect } from "react-redux";
import axios from "axios";

import ChangeValueInCartButton_ReduxWrapped from "./cartButton/changeValueInCartButton"
import "./Cart.css"
import urls from "../../API_URL"
// import RowInMainTable from "../RowInMainTable/RowInMainTable";    
import actionCreator from "../../Store/ActionsCreators/actionCreator";
import { mapToOrderData } from "../../function/mapToOrderData";
import CartArtEventView from "./CartArtEventView";
import styled from "styled-components";


import { useNavigate } from "react-router-dom"

const Flexblock = styled.div`
 box-sizing: border-box;
    display: flex;
    flex-flow: row wrap;
    margin-top: 16vh;
    /* background-color: rgba(87, 169, 252, 0.822); */
`;

const AbsoluteMessage = styled.div`
    position: absolute;
    z-index:1000;
    opacity:0.4;
    font-size: 10vw;
    color: pink;
    top:20%;
    left: 25%;
`;
const CreateOrderBuntton = styled.button`
margin: 3px auto;

font-size: 2rem;
`;
const NeedAuthMessage = styled.div`
    display: inline-block;
    margin: 3px auto;
    font-size: 2rem;
    color: red;

`;


const Cart = ({ cartMap, fullCartArray, setFullCartArray,isAuthenticated, clearCart})=>{

    const [isLoading, setIsLoading] = useState(true);                
    const [errorMessage, setErrorMessage] = useState(null);
    const [message, setMessage] = useState("");
    const navigate = useNavigate();
    
    const CreateOrderHandler = async ()=>{
        const clearMessageAfter5Sec =()=>setTimeout(() => {setMessage("")}, 5000); 

        try {     
            setMessage("processing...")      
          let result =   await axios.post(urls.createOrder(), mapToOrderData(cartMap));

            if (result.status==200) {                
                setMessage("ORDER WAS CREATED");
                clearCart();
                clearMessageAfter5Sec();
                         
            }

        } catch (error) {
            setMessage("Error");
            console.log("CreateOrderHandler =          " + error);
            clearMessageAfter5Sec();

        }       
    }

    useEffect(async ()=>{
        try {
            if (cartMap === undefined || cartMap.size === 0) {
                return;
            }
            setIsLoading(true);
            let arrayOfKeys = Array.from(cartMap.keys(), (key) => key);            
            const result = await axios.get(urls.getFullCheckedListForCart(arrayOfKeys));
            if (result.status === 200) {
                setFullCartArray(result.data); 
                
                let newCartMapArray = result.data.map((artEvent)=>[artEvent.id, cartMap.get(artEvent.id) ]);
                console.log(newCartMapArray);
                let newMap = new Map(newCartMapArray);
                console.log(newMap);
                
                clearCart(newMap);

            }
            


        } catch (error) {      

            setErrorMessage(error);
        }
        finally {
            setIsLoading(false);
        }
    },[]);



    let elemenList=[];
    let button = "";

    //кошмар какой то 
    if (isLoading) {
        elemenList = <div>Loading....</div>  ;
             
    } else {
         if (    errorMessage   ) {
        elemenList="fail";  
              
        } else{
            if (cartMap === undefined || cartMap.size=== 0) {    
                elemenList = <div>Your cart is empty</div>    
            } else {
                elemenList = fullCartArray.map((item) => (<CartArtEventView key={item.id} {...item}/>));
                if (isAuthenticated) {
                    button = <CreateOrderBuntton onClick={CreateOrderHandler}>Create Order</CreateOrderBuntton>
                } else {
                    button = <NeedAuthMessage>Need Authentication</NeedAuthMessage>;  
                }                                                      
            }
        }            
    }
        return(
            <Flexblock>
            <AbsoluteMessage>{message}</AbsoluteMessage>       
            {elemenList}   
            {button}
            </Flexblock>
    )
}

const mapStateToProps=(state)=> ({ 
    isAuthenticated:state.auth.isAuthenticated,
    cartMap:        state.cart.cartMap,
    fullCartArray:  state.cart.fullCartArray
}); 
const mapDispatchToProps = dispatch => ({
    setFullCartArray: (fullCartArray) => dispatch(actionCreator.setFullCartArray(fullCartArray)),
    clearCart: (newMap) => dispatch(actionCreator.clearCart(newMap))
});

let Cart_ReduxWrapped = connect(mapStateToProps, mapDispatchToProps)(Cart);
export default Cart_ReduxWrapped;
