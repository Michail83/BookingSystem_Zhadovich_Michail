import React, { useState } from 'react';
import styled from 'styled-components';

import ClassicMusicCreateForm from "../../components/CreateDifferentArtEvent/CreateForm/ClassicMusicCreateForm";
import PartyCreateForm from '../../components/CreateDifferentArtEvent/CreateForm/PartyCreateForm';
import OpenAirCreateForm from "../../components/CreateDifferentArtEvent/CreateForm/OpenAirCreateForm"

import { BigSuccessful } from '../../components/StyledComponent/WrapWithSuccessHandler/BigResult';
import { BigError } from '../../components/StyledComponent/WrapWithSuccessHandler/BigResult';
import { BlueButton } from '../../components/StyledComponent/Button/BlueButton';
import { MainBlock } from '../../components/StyledComponent/MainBlock';

const MainCreate = styled.div`
    background-color: white;
    margin:-0.5rem;
`;

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
   
    background-color: lightskyblue;
    margin: auto;    
`;
const BorderBlock = styled.div`
    margin: 3rem  auto;
    max-width: 90%;
`;
function CreateEvent() {
    const [currentTab, setcurrentTab] = useState(0);    

    let Element;
    switch (currentTab) {
        case 0: Element = <OpenAirCreateForm  setStatusOfCreating={setcurrentTab} />;
            break;
        case 1: Element = <PartyCreateForm setStatusOfCreating={setcurrentTab} />;
            break;
        case 2: Element = <ClassicMusicCreateForm setStatusOfCreating={setcurrentTab} />;
            break;
        case true: Element = <BigSuccessful>
            Event was created successfully. Do you want to create <BlueButton onClick={() => setcurrentTab(0)}>More </BlueButton> 
            </BigSuccessful>;
            break;
        case false: Element = <BigError>
            Event was not created. Something wrong in data that you entered<BlueButton onClick={() => setcurrentTab(0)}>Again </BlueButton> 
            </BigError>;
            break;
        default:  Element = <OpenAirCreateForm  setStatusOfCreating={setcurrentTab}/>
            
            break;
    }
    return (
        <MainCreate>
            <MainBlock>
            <BorderBlock>

                <TabBlock>
                    {currentTab !== 0 ?
                        <TabsItem onClick={() => setcurrentTab(0)}>Open Airs</TabsItem>
                        : <ActiveTabsItem onClick={() => setcurrentTab(0)}>Open Airs</ActiveTabsItem>}

                    {currentTab !== 1 ?
                        <TabsItem onClick={() => setcurrentTab(1)}>Parties</TabsItem>
                        : <ActiveTabsItem onClick={() => setcurrentTab(1)}>Parties</ActiveTabsItem>}

                    {currentTab !== 2 ?
                        <TabsItem onClick={() => setcurrentTab(2)}>Classic Music</TabsItem>
                        : <ActiveTabsItem onClick={() => setcurrentTab(2)}>Classic Music</ActiveTabsItem>}

                </TabBlock>

                {Element}

            </BorderBlock>
        </MainBlock>
        </MainCreate>
    );
}
export default CreateEvent;
