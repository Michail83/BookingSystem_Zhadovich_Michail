import React,{Fragment} from 'react';
import styled from 'styled-components';
import LogInOutManager_connected from '../../components/LoginOutManager/LoginOutManager';

const MainBlock= styled.main`
    width: 70%;
    min-width: 500px;
    margin: 0 auto;
    font-size: 24px;
`;

function LockedUser() {
    return (
        <MainBlock >  
            <p>This user has been locked. If you want to get more information, contact as by test@test.email </p>   
            <LogInOutManager_connected/>       
            
        </MainBlock>
    );
}
export default LockedUser;