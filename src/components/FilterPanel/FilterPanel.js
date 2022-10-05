import React, {useState} from "react";
import { connect } from "react-redux";
import _ from "lodash";

import imageSelect from "../../icons/icons8-drop-down24.png";

import {ListOfArtEventType} from "../../CONST/ListOfArtEventType";
import {ListOfSortOptions} from "../../CONST/ListOfSortOptions";
import { partOfInitialState_FilteringData } from "../../Store/initialState";
import actionsCreator from "../../Store/ActionsCreators/actionCreator";
import styled from "styled-components";


const MainFilterPanelWrapped =styled.div`
    box-sizing: border-box;
    position: fixed;
   
    min-width:500px;
    max-width: 1200px;
    top: 5.9rem;

    width: 100%;
    background-color: white;
`;
const MainFilterPanel =styled.div`
    display: flex;
    min-width:500px;
    flex-flow: row nowrap;
    justify-content:center;
    align-items: flex-start;
    border-bottom: 1px solid rgba(30, 117, 204, 0.877);    
    padding: 0.5rem;
    margin: -2px auto 0 auto ;    
    height: 45px;   

    & select,input[type="text"],button, div {
        box-sizing: border-box;
        
        margin: 0.5rem;
    }

    & select,
  input[type="text"] {
    width: auto;
    padding: 2px;
    border: 1px solid #ccc;
    font-size: 13px;
    -webkit-appearance: none;
  }
    & select{
        padding-right: 25px;
        background-image: url(${imageSelect});
        background-size: 14%;
        background-repeat: no-repeat;
        background-position-y: center;
        background-position-x: calc(100% - 5px);
        cursor:pointer;
    }
    & button {
        width: 3rem;
        display:block;
    }     
`;
const DivWrap = styled.div`
    box-sizing:border-box;
    position: relative; 
`;
const SpanFilter = styled.span`
    position:absolute;
    z-index:100;
    top:-10px;
    left: 0.5rem ;
    font-size: smaller;
    font-style: italic;
`;


const FilterPanel = ({ filteringData, setfilteringData, setfilteringDataToDefault }) => {

    const [nameFilter, setNameFilter] = useState(filteringData.nameForFilter);
    const [typeFilter, setTypeFilter] = useState(filteringData.typeForFilter);
    const [sort, setSort] = useState(filteringData.sortBy);

    const createTypeFilterOptions = (listOfArtEventType) => listOfArtEventType.map((eventType) => <option key={eventType.value} value={eventType.value}> {eventType.name}</option>);
    const createSortOptions = (sortOptions) => sortOptions.map((sortby) => <option key={sortby.value} value={sortby.value}> {sortby.name}</option>);

    const resetFilter=()=>{
        setNameFilter(partOfInitialState_FilteringData.nameForFilter);
        setTypeFilter(partOfInitialState_FilteringData.typeForFilter);
        setSort(partOfInitialState_FilteringData.sortBy);

        setfilteringDataToDefault();
    };
    const IsResetDisabled=()=>(
        partOfInitialState_FilteringData.sortBy === filteringData.sortBy&&
        partOfInitialState_FilteringData.nameForFilter === filteringData.nameForFilter&&
        partOfInitialState_FilteringData.typeForFilter === filteringData.typeForFilter
    )
    const IsApplyDisabled =()=>(
        sort === filteringData.sortBy&&
        nameFilter === filteringData.nameForFilter&&
        typeFilter === filteringData.typeForFilter
    )

    return (
        <MainFilterPanelWrapped>
            <MainFilterPanel>
               

                <DivWrap>
                    <SpanFilter>Filter by name</SpanFilter>
                    <input  placeholder="Event's name..." type="text" value={nameFilter} onChange={(event) => (setNameFilter(event.target.value))}/>
                </DivWrap>

                <DivWrap>
                <SpanFilter>Filter by type </SpanFilter>
                <select  value={typeFilter} onChange={(event) => setTypeFilter(event.target.value)}>
                    {createTypeFilterOptions(ListOfArtEventType)}
                </select>
                </DivWrap>
                
                <DivWrap>
                <SpanFilter>Sort by</SpanFilter>

                <select  value={sort} onChange={(event) => setSort(event.target.value)}>
                    {createSortOptions(ListOfSortOptions)}
                </select>

                </DivWrap>
                
                <DivWrap>
                <button type="button" disabled={IsApplyDisabled()} onClick={() => setfilteringData(nameFilter, typeFilter, sort)} >Apply</button>
                </DivWrap>
                
                <DivWrap>
                <button type="button" disabled={IsResetDisabled()} onClick={() => resetFilter()}>Reset</button>
                </DivWrap>
                

                <div>{IsApplyDisabled()}</div>
            </MainFilterPanel>
        </MainFilterPanelWrapped>
    )
}

const mapStateToProps = state => ({
    
    filteringData: state.state.filteringData
});

const mapDispatchToProps = dispatch => (
    {
        setfilteringData:(nameFilter,typeFilter,sort)=> dispatch(actionsCreator.setFilteringData({nameForFilter:nameFilter, typeForFilter:typeFilter, sortBy:sort})), 
        setfilteringDataToDefault:()=>dispatch(actionsCreator.setFilteringDataToDefault())     
    });

var FilterPanel_ReduxWrapped = connect(mapStateToProps, mapDispatchToProps)(FilterPanel);

export default FilterPanel_ReduxWrapped;