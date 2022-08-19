import React from 'react';

import  Orders from '../../components/Orders/Orders';
import styled from 'styled-components';

const MainBlock = styled.div`
margin-top: 16vh;
`;

const OrderPage = () => {
    return (
        <MainBlock>
            <Orders />
        </MainBlock>)
}
export default OrderPage;