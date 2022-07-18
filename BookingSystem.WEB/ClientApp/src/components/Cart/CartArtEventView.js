
import { Link, useNavigate } from "react-router-dom"
// import AddButton_ReduxWrapped from "../Cart/cartButton/AddButton"
// import "./HomeArtEventView.css"
// import ChangeValueInCartButton_ReduxWrapped from "../Cart/cartButton/changeValueInCartButton";
import ArtEventView from "../ArtEventView/ArtEventView";
import CartArtEventViewButtonBlock from "./CartArtEventViewButtonBlock"; 


function CartArtEventView(props) { 
    console.log(props);  
    let newProps ={...props,buttonBlock: CartArtEventViewButtonBlock } 

    return (
        <ArtEventView {...newProps}/>
    )
}
export default CartArtEventView;