import React from "react";
import { DetailsButton } from "../Buttons/DetailsButton"

const AdminArtEventButtonBlock = (props) => {

    return (
        <>            
            <DetailsButton id={props.id}>Details</DetailsButton>
        </>
    )
}
export default AdminArtEventButtonBlock;