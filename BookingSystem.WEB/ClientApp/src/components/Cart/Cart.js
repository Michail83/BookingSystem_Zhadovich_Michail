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


import { Link, useNavigate } from "react-router-dom"

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
    top:35%;
    left: 55%;
`;

const Cart = ({ cartMap, fullCartArray, setFullCartArray,isAuthenticated})=>{

    const [isLoading, setIsLoading] = useState(true);                
    const [errorMessage, setErrorMessage] = useState(null);
    const [message, setMessage] = useState("");
    const navigate = useNavigate();
    
    const CreateOrderHandler = async ()=>{
        try {
            // console.log(mapToOrderData(cartMap));

          let result =   await axios.post(urls.createOrder(), mapToOrderData(cartMap));

            if (result.status==200) {
                console.log("ORDER WAS CREATED");
                setMessage("ORDER WAS CREATED");
                setTimeout(() => {setMessage("")
                    
                }, 5000);               
                
                // navigate("/")                
            }

        } catch (error) {
            console.log("CreateOrderHandler =          " + error);
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
            setFullCartArray(result.data);            

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
                    button = <button onClick={CreateOrderHandler}>Create Order</button>
                } else {
                    button = <div>Need Authentication</div>;  
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
    cartMap: state.cart.cartMap,
    fullCartArray: state.cart.fullCartArray
}); 
const mapDispatchToProps = dispatch => ({
    setFullCartArray: (fullCartArray) => dispatch(actionCreator.setFullCartArray(fullCartArray))
});

let Cart_ReduxWrapped = connect(mapStateToProps, mapDispatchToProps)(Cart);
export default Cart_ReduxWrapped;
