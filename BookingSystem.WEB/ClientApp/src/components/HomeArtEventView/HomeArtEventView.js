
import { Link, useNavigate } from "react-router-dom"
// import AddButton_ReduxWrapped from "../Cart/cartButton/AddButton"
import "./HomeArtEventView.css"
// import ChangeValueInCartButton_ReduxWrapped from "../Cart/cartButton/changeValueInCartButton";
import ArtEventView from "../ArtEventView/ArtEventView";
import HomeArtEventButtonBlock from "./HomeArtEventButtonBlock"; 


function HomeArtEventView(props) {   
    let newProps ={...props,buttonBlock: HomeArtEventButtonBlock } 

    return (
        <ArtEventView {...newProps}/>
    )
}
export default HomeArtEventView;