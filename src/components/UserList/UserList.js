import React, { useEffect } from "react";
import axios from "axios";
import api_url from "../../API_URL";
import { connect } from "react-redux";
import actionsCreater from "../../Store/ActionsCreators/actionCreator";
import User from "../User/User";


import styled from "styled-components";

const MainUserList = styled.div`
    display:flex;
    flex-flow: column nowrap;    
    min-width:500px;
    margin: 1rem auto 0 auto; 
    border: 1px solid lightskyblue;
    box-sizing: border-box;
`;
const UserList = ({ userList, setUserList }) => {
   
    useEffect(() => {
        try {             
            loadData();
        } 
        catch (error) {
            console.log(error);
        }
    }, []);
    const loadData = async () => {
        let users = await axios.get(api_url.getUsers()); 
        setUserList(users.data);
    };
    const toRender = () => {
        if (userList.length===0) {
            return <div>Loading</div>
        } else {              
            let result = userList.map((user) => (<User key={user.id}  {...user} loadData={loadData} />));
            return result;
        }
    };
    return (        
        <MainUserList>
            {toRender()}
        </MainUserList>       
    )
}
const mapStateToProps = state => ({
    userList: state.admins.userList,
});

const mapDispatchToProps = dispatch => (
    {
        setUserList: (userList) => dispatch(actionsCreater.setUsersList(userList)),
    });
var UserList_ReduxWrapped = connect(mapStateToProps, mapDispatchToProps)(UserList);
export default UserList_ReduxWrapped;
