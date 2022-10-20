import React, { Fragment, useState, useEffect } from "react";
// import styled from "styled-components";
import { BlueButton } from "../StyledComponent/Button/BlueButton";
import { BigSuccessful } from "../StyledComponent/WrapWithSuccessHandler/BigResult";
import { BigError } from "../StyledComponent/WrapWithSuccessHandler/BigResult";


const WrapWithSuccessHandler = (props) => {    
    
    const [statusOfCreating, setStatusOfCreating] = useState(null);
    
        let result = <BigSuccessful>Event was created successfully. Do you want to create <BlueButton onClick={() => setStatusOfCreating(null)}>More </BlueButton> </BigSuccessful>

        if (statusOfCreating==null) result = <props.Form {...props} setStatusOfCreating={setStatusOfCreating} />
        else if (statusOfCreating==false) result= <BigError>Event was not created. Something wrong in data that you entered<BlueButton onClick={() => setStatusOfCreating(null)}>Again </BlueButton> </BigError>
        
    return (
        <Fragment>
            {result}
        </Fragment>
    )
}
export default WrapWithSuccessHandler;