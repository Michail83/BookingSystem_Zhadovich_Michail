import React, {useState, useEffect} from "react";
import { Link, useNavigate } from "react-router-dom"
import "../../UniversalHeader/UniversalHeader"


//import urls from "../../API_URL"
// import state from '../../Store/store'
import { connect } from "react-redux";



const LinkToCartFromHeader= ({cartMap}) => {
   

    let element = <div>Empty cart</div>;
    
       if (!cartMap.size == 0) {   
           element = <Link to="/cart">Cart</Link>
        } 
       return element;
   
   

}
const mapStateToProps=state=> ({    
    cartMap: state.cart.cartMap
});

const mapDispatchToProps=dispatch=> (
    {        
        // isAuthenticated: result => dispatch(SetIsAuthenticated(result)),
    });

var LinkToCartFromHeader_ReduxWrapped = connect(mapStateToProps, null)(LinkToCartFromHeader);


export default LinkToCartFromHeader_ReduxWrapped;