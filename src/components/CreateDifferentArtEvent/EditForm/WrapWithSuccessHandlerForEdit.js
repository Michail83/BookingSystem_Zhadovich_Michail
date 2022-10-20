import React, { Fragment, useState, useEffect } from "react";
import { useNavigate } from "react-router-dom";

import { BlueButton } from "../../StyledComponent/Button/BlueButton"; 
import { BigSuccessful } from "../../StyledComponent/WrapWithSuccessHandler/BigResult";
import { BigError } from "../../StyledComponent/WrapWithSuccessHandler/BigResult";

const WrapWithSuccessHandlerForEdit = (props) => {    
    const navigate = useNavigate();
    const [statusOfCreating, setStatusOfCreating] = useState(null);
    
        let result = <BigSuccessful>Event was changed successfully. <BlueButton onClick={() => navigate(`/details/${props.id}`)}>Back to details </BlueButton> </BigSuccessful>

        if (statusOfCreating==null) result = <props.Form {...props} setStatusOfCreating={setStatusOfCreating} />
        else if (statusOfCreating==false) result= <BigError>Event was not created. Something wrong in data that you entered<BlueButton onClick={() => setStatusOfCreating(null)}>Again </BlueButton> </BigError>
        
    return (
        <>
            {result}
        </>
    )
}
export default WrapWithSuccessHandlerForEdit;