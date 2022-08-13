import React from "react"
import {connect} from "react-redux";

function DisplayUserName({auth })
{
    let element = "Guest";
    if (auth.isAuthenticated) {
        element = auth.userName;
    } else{
        element = "Guest";
    }
    return (
        <div>{element}</div>
        )
}

const mapStateToProps = state => ({
    auth: state.auth
});

const mapDispatchToProps = dispatch => (
    {
        // isAuthenticated: result => dispatch(SetIsAuthenticated(result)),
    });

const DisplayUserName_ReduxWrapped = connect(mapStateToProps, mapDispatchToProps)(DisplayUserName);

export default DisplayUserName_ReduxWrapped;