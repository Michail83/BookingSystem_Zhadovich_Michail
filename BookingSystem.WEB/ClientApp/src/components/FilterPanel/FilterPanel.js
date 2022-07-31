import React, {useState} from "react";
import { connect } from "react-redux";
import _ from "lodash";


import {ListOfArtEventType} from "../../CONST/ListOfArtEventType";
import {ListOfSortOptions} from "../../CONST/ListOfSortOptions";
import { partOfInitialState_FilteringData } from "../../Store/initialState";
import actionsCreator from "../../Store/ActionsCreators/actionCreator";
// import "./FilterPanel.css";
import styled from "styled-components";


const MainFilterPanelWrapped =styled.div`
    box-sizing: border-box;
    position: fixed;
    top: 13vh;
    width: 100%;
    background-color: white;
`;
const MainFilterPanel =styled.div`
    display: flex;
    flex-direction: row;
    justify-content:center;
    align-items: stretch;
    border-bottom: 1px solid rgba(30, 117, 204, 0.877);    
    padding: 0.5%;
    margin: -5px 0 0 0 ;
    /* background-color: white; */
    height: 40px;     
    & select,input[type="text"],button {
        box-sizing: border-box;
        
        margin: 0.5rem 1%;
    }
    & select{
        padding-right: 25px;
        background-image: url("../../icons/icons8-drop-down24.png");
        background-size: 14%;
        background-repeat: no-repeat;
        background-position-y: center;
        background-position-x: calc(100% - 5px);
        cursor:pointer;
    }
    & button {
        width: 9%;
    }
    & select,
  input[type="text"] {
    width: auto;
    padding: 2px;
    border: 1px solid #ccc;
    font-size: 13px;
    -webkit-appearance: none;
  }
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
        setSort(partOfInitialState_FilteringData.setSort);

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
    // console.log(nameFilter == filteringData.sortBy);

    // console.log(nameFilter);
    // console.log( filteringData.sortBy);

    // console.log(typeFilter == filteringData.nameForFilter);
    // console.log(typeFilter);
    // console.log(filteringData.nameForFilter);

    // console.log(sort == filteringData.typeForFilter);
    // console.log(filteringData.typeForFilter);
    // console.log(sort);


    return (
        <MainFilterPanelWrapped>
            <MainFilterPanel>

                <input className="filterElementSize" placeholder="Event's name..." type="text" value={nameFilter} onChange={(event) => (setNameFilter(event.target.value))} ></input>

                <select className="filterElementSize" value={typeFilter} onChange={(event) => setTypeFilter(event.target.value)}>
                    {createTypeFilterOptions(ListOfArtEventType)}
                </select>

                <select className="filterElementSize" value={sort} onChange={(event) => setSort(event.target.value)}>
                    {createSortOptions(ListOfSortOptions)}
                </select>
                <button type="button" disabled={IsApplyDisabled()} onClick={() => setfilteringData(nameFilter, typeFilter, sort)} >Apply</button>

                <button type="button" disabled={IsResetDisabled()} onClick={() => resetFilter()}>Reset</button>

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