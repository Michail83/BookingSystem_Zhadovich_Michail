import React from "react";
import "../UniversalHeader/UserHeader"
import LogoutBtn from "../Logout/LogoutBtn"
import { connect } from "react-redux";
import store from "../../Store/store"
import actionsCreator from "../../Store/ActionsCreators/actionCreator"

const LogInOutManager = ({ auth }) => {

    const showButton = () => {
        let element;
        if (auth.isAuthenticated) {
            element = <LogoutBtn />
        } else {
            element =
                <button onClick={() => store.dispatch(actionsCreator.setModalWindowForLoginActive(true))} > Login </button>
        }
        return element;
    }
    return showButton();
}
const mapStateToProps = state => ({
    auth: state.auth
});

var LogInOutManager_connected = connect(mapStateToProps, null)(LogInOutManager);

export default LogInOutManager_connected;