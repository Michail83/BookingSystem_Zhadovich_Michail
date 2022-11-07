import React, {useState, useEffect} from "react";
import { connect } from "react-redux";
import axios from "axios";
import "./Cart.css"
import urls from "../../API_URL"   
import actionCreator from "../../Store/ActionsCreators/actionCreator";
import { mapToOrderData } from "../../function/mapToOrderData";
import CartArtEventView from "./CartArtEventView";
import styled from "styled-components";
import { useNavigate } from "react-router-dom"

const Flexblock = styled.div`
 box-sizing: border-box;
    display: flex;
    flex-flow: row wrap;   
`;
const BadResult = styled.div`
    padding: 2rem;
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

const Cart = ({setIsSuccess, cartMap, fullCartArray, setFullCartArray,isAuthenticated, setNewCart})=>{

    const [isLoading, setIsLoading] = useState(true);                
    const [errorMessage, setErrorMessage] = useState(null);
    const [message, setMessage] = useState("");
    
    
    const CreateOrderHandler = async ()=>{
        // const clearMessageAfter5Sec =()=>setTimeout(() => {setMessage("")}, 5000); 

        try {     
            setMessage("processing...")      
          let result =   await axios.post(urls.createOrder(), mapToOrderData(cartMap));

            if (result.status==200) {
                setNewCart();                 
                setIsSuccess(true);                       
            }

        } catch (error) {
            setIsSuccess(false);            
            // clearMessageAfter5Sec();
        }       
    }

    useEffect(async ()=>{
        try {
            if (cartMap === undefined || cartMap.size === 0) {
                return;
            }
            setIsLoading(true);
            let arrayOfKeys = Array.from(cartMap.keys(), (key) => key); 
            console.log(arrayOfKeys)  ;  
            let url =  urls.getFullCheckedListForCart(arrayOfKeys)   ;   
            console.log(url)  ;
            const result = await axios.get(url);
            if (result.status === 200) {
                setFullCartArray(result.data); 
                
                let newCartMapArray = result.data.map((artEvent)=>[artEvent.id, cartMap.get(artEvent.id) ]);                
                let newMap = new Map(newCartMapArray);                
                setNewCart(newMap);
            } 

        } catch (error) {      

            setErrorMessage(error);
        }
        finally {
            setIsLoading(false);
        }
    },[]);

    const createElements = ()=>{
        let elemenList=[];
    let button = "";

    //кошмар какой то 
    if (isLoading) {
        elemenList = <BadResult>Loading....</BadResult>
    } else {
         if (    errorMessage   ) {
        elemenList=<BadResult>"fail"</BadResult>;  
              
        } else{
            if (cartMap === undefined || cartMap.size=== 0) {    
                elemenList = <BadResult>Your cart is empty</BadResult>    
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
    elemenList = <>
    {elemenList}
    {button}
    </>
    return  elemenList ;

    }
    

        return(
            <Flexblock>
            <AbsoluteMessage>{message}</AbsoluteMessage>       
            {createElements()}            
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
    setNewCart: (newMap) => dispatch(actionCreator.clearCart(newMap))
});

let Cart_ReduxWrapped = connect(mapStateToProps, mapDispatchToProps)(Cart);
export default Cart_ReduxWrapped;
