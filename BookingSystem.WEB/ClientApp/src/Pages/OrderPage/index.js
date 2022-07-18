import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { useParams } from "react-router-dom";
import urls from '../../API_URL'
import CartList from '../../components/Cart/Cart'
import  Orders from '../../components/Orders/Orders';
import styled from 'styled-components';

const MainBlock = styled.div`
margin-top: 15vh;
`;

const OrderPage = () => {
    return (
        <MainBlock>
            <Orders />
        </MainBlock>)
}
export default OrderPage;