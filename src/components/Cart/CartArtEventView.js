
import { Link, useNavigate } from "react-router-dom"
// import AddButton_ReduxWrapped from "../Cart/cartButton/AddButton"
// import "./HomeArtEventView.css"
// import ChangeValueInCartButton_ReduxWrapped from "../Cart/cartButton/changeValueInCartButton";
import ArtEventView from "../ArtEventView/ArtEventView";
import ChangeValueInCartButton_ReduxWrapped from "./cartButton/changeValueInCartButton"  


function CartArtEventView(props) {
    let newProps ={...props,buttonBlock: ChangeValueInCartButton_ReduxWrapped } 
    return (
        <ArtEventView {...newProps}/>
    )
}
export default CartArtEventView;