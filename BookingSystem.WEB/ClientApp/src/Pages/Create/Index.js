import React, { useState, useEffect } from 'react';
// import './Index.css';
import styled from 'styled-components';
import OpenAirCreateForm from '../../components/CreateDifferentArtEvent/OpenAirCreateForm.js';
import ClassicMusicCreateForm from '../../components/CreateDifferentArtEvent/ClassicMusicCreateForm';
import PartyCreateForm from '../../components/CreateDifferentArtEvent/PartyCreateForm';



// ///////////////////////////////////////////////////////////////////////////////////////
// import OpenAirCreateFormNew from '../../components/CreateDifferentArtEvent/OpenAirCreateFormNew';

const MainBlock = styled.div`
/* margin-top: 15vh; */
max-width: 600px;
margin: 15vh auto 0 auto; 
border: 1px solid lightskyblue;

border-radius: 4px;
background-color:lightskyblue;
`
const TabsItem = styled.div`
    display: inline-block;
    font-size: 16px;
    width: 33%;
    border: 1px solid black;
    border-radius: 4px;
    box-sizing: border-box;
    padding: 1px;
    text-align: center;
    cursor:pointer;
    background-color: white;
    &:hover{
        background-color: royalblue;

    }
`;
const ActiveTabsItem = styled(TabsItem)`
    background-color: royalblue;
    
`;
const TabBlock = styled.div`
    /* width: 60vw; */
    background-color: lightskyblue;
    margin: auto;
    
`;
const BorderBlock = styled.div`
    margin: 3rem  auto;
    max-width: 90%;
`;

function CreateEvent() {
    const [currentTab, setcurrentTab] = useState(0);
    // const [Element, setElement ] = useState();

    let Element;
    switch (currentTab) {
        case 0: Element = OpenAirCreateForm;
            break;
        case 1: Element = PartyCreateForm;
            break;
        case 2: Element = ClassicMusicCreateForm;
            break;
        default:
            (
                <p>...Loading</p>
            );
            break;
    }
    return (
        <MainBlock>
            <BorderBlock>
                <TabBlock>
                    {currentTab != 0 ?
                        <TabsItem onClick={() => setcurrentTab(0)}>Open Airs</TabsItem>
                        : <ActiveTabsItem onClick={() => setcurrentTab(0)}>Open Airs</ActiveTabsItem>}

                    {currentTab != 1 ?
                        <TabsItem onClick={() => setcurrentTab(1)}>Parties</TabsItem>
                        : <ActiveTabsItem onClick={() => setcurrentTab(1)}>Parties</ActiveTabsItem>}

                    {currentTab != 2 ?
                        <TabsItem onClick={() => setcurrentTab(2)}>Classic Music</TabsItem>
                        : <ActiveTabsItem onClick={() => setcurrentTab(2)}>Classic Music</ActiveTabsItem>
                    }

                </TabBlock>
                <Element />
            </BorderBlock>
        </MainBlock>
    );
}
export default CreateEvent;
