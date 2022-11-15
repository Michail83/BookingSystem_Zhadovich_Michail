import React from "react"
import {connect} from "react-redux";
import styled from "styled-components";

const WrapForDiv = styled.div`
    margin:0 0.5rem;

`;
function DisplayUserName({auth })
{
    let element = "";
    if (auth.isAuthenticated) {
        element = auth.userName;
    } 
    return (
        <WrapForDiv>{element}</WrapForDiv>
        )
}
const mapStateToProps = state => ({
    auth: state.auth
});

const DisplayUserName_ReduxWrapped = connect(mapStateToProps, null)(DisplayUserName);

export default DisplayUserName_ReduxWrapped;