import React, { useEffect, useState, Fragment } from "react";
import Countdown from "react-countdown";

import { BlueButton } from "../StyledComponent/Button/BlueButton";

import api_url from "../../API_URL";
import axios from "axios";
////////////////////////////////////////////////////////////////////////////////
const CoutdownToRefreshConfirmation = ({ email }) => {
    const [result, setResult] = useState("");

    let toRender;

    const tryRefreshConfirmation = async () => {
        console.log(email);

        let result = await axios.get(api_url.refreshConfirmationEmail(email));

        console.log(result);

        setResult(result);
    }

    // useEffect(() => {
    //     tryRefreshConfirmation();
    // }, []);

    if (result) {

        if (result.data.success) {
            toRender = <span>Email with confirmation link was sended </span>
        }
        else if (result.data.canTryIn) {
            let time = new Date(result.data.canTryIn);
            toRender = <p>You can try send new confirmation email in  - <Countdown date={time} onComplete={()=>setResult("")} /></p>
        } else {
            toRender = <span>error... </span>
        }
    } else {
        toRender = <Fragment>
            <p>This account is not confirmed</p>
            <p>Do you want to send another email with confirmation link?<BlueButton onClick={tryRefreshConfirmation}>Yes</BlueButton></p>;
        </Fragment> 
        
    }

/////////////////////////////////////////////////////////////////////


    return (
        // <div>test</div>
        <Fragment>{toRender}</Fragment>

    )
}
export default CoutdownToRefreshConfirmation;