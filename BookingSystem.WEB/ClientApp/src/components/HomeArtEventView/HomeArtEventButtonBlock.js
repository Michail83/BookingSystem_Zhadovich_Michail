import React from "react";

import AddButton_ReduxWrapped from "../Cart/cartButton/AddButton";
import { useNavigate } from "react-router-dom";

const HomeArtEventButtonBlock = (props) => {
    const navigate = useNavigate();
    return <div>
        <AddButton_ReduxWrapped/>
        <button onClick={()=>navigate(`/details/${props.item.id}`)}>Details</button>
    </div>
} 
export default HomeArtEventButtonBlock;