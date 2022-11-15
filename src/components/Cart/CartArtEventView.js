import React from "react";
import ArtEventView from "../ArtEventView/ArtEventView";
import CartArtEventViewButtonBlock from "./CartArtEventViewButtonBlock"; 

function CartArtEventView(props) {
    let newProps ={...props,buttonBlock: CartArtEventViewButtonBlock } 
    return (
        <ArtEventView {...newProps}/>
    )
}
export default CartArtEventView;