import React, { useState, useEffect }  from 'react';
import UniversalHeader from '../../components/UniversalHeader/UniversalHeader.js';
import OpenAirCreateForm from '../../components/CreateDifferentArtEvent/OpenAirCreateForm.js';
import PartiesCreateForm from '../../components/CreateDifferentArtEvent/PartiesCreateForm.js'
import ClassicMusicCreateForm from '../../components/CreateDifferentArtEvent/ClassicMusicCreateForm'
// import './Index.css';
import styled from 'styled-components';
import OpenAirCreateForm3 from '../../components/CreateDifferentArtEvent/HookFormCreateEvent/OpenAirCreateForm3.js';



// ///////////////////////////////////////////////////////////////////////////////////////
import OpenAirCreateFormNew from '../../components/CreateDifferentArtEvent/OpenAirCreateFormNew';

const MainBlock = styled.div`
/* margin-top: 15vh; */
max-width: 500px;
margin: 15vh auto 0 auto; 
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
`;
const ActiveTabsItem = styled(TabsItem)`
    background-color: aquamarine;
    
`;
const TabBlock = styled.div`
    /* width: 60vw; */
    margin: auto;
`;

function CreateEvent() {
const [currentTab, setcurrentTab ] = useState(0);
// const [Element, setElement ] = useState();

let Element;
switch (currentTab) {        
    case 0: Element = OpenAirCreateForm3;    
    break;  
    case 1: Element = PartiesCreateForm; 
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
            <TabBlock>
                {currentTab!=0?
                <TabsItem onClick={()=>setcurrentTab(0)}>Open Airs</TabsItem>
                :<ActiveTabsItem onClick={()=>setcurrentTab(0)}>Open Airs</ActiveTabsItem>}

                {currentTab!=1?
                <TabsItem  onClick={()=>setcurrentTab(1)}>Parties</TabsItem>
                : <ActiveTabsItem  onClick={()=>setcurrentTab(1)}>Parties</ActiveTabsItem>}
                
                {currentTab!=2?
                <TabsItem  onClick={()=>setcurrentTab(2)}>Classic Music</TabsItem>
                :<ActiveTabsItem  onClick={()=>setcurrentTab(2)}>Classic Music</ActiveTabsItem>
                }
                
            </TabBlock>
            <Element/>           
        </MainBlock>
    );
}
export default CreateEvent;
