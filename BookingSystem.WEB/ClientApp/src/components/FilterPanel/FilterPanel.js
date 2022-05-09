import React, {useState} from "react";
import { connect } from "react-redux";


import {ListOfArtEventType} from "../../CONST/ListOfArtEventType";
import {ListOfSortOptions} from "../../CONST/ListOfSortOptions";
import actionsCreator from "../../Store/ActionsCreators/actionCreator";
import "./FilterPanel.css";



const FilterPanel = ({filteringData, setfilteringData})=>{
    const [nameFilter, setNameFilter] = useState(filteringData.nameForFilter);
    const [typeFilter, setTypeFilter] = useState(filteringData.typeForFilter);
    const [sort, setSort] = useState(filteringData.sortBy);

    console.log(filteringData);
    console.log(nameFilter);
    console.log(typeFilter);
    console.log(sort);


    const createTypeFilterOptions = (listOfArtEventType)=> listOfArtEventType.map((eventType)=><option key={eventType.value} value={eventType.value}> {eventType.name}</option>);
    const createSortOptions = (sortOptions)=>sortOptions.map((sortby)=><option key={sortby.value} value={sortby.value}> {sortby.name}</option>);    

    return (
        <div className="mainFilterPanel">
            <div className="nameFilter">
                <input className="filterElementSize" placeholder="Event's name..." type="text" value={nameFilter} onChange={(event)=>(setNameFilter(event.target.value))} ></input>

            </div>
            <div className="typeFilter">
                <select className="filterElementSize"  value={typeFilter} onChange={(event)=>setTypeFilter(event.target.value)}>
                    {createTypeFilterOptions(ListOfArtEventType)}
                </select>

            </div>
            <div className="SortBy">
            <select className="filterElementSize" value={sort} onChange={(event)=>setSort(event.target.value)}>
                    {createSortOptions(ListOfSortOptions)}
                </select>

            </div>
            <div className="SubmitButton" >
                <button  type="button" onClick={()=>setfilteringData(nameFilter,typeFilter,sort)} >Use</button>
            </div>
        </div>
    )
}



const mapStateToProps = state => ({
    
    filteringData: state.state.filteringData
});

const mapDispatchToProps = dispatch => (
    {
        setfilteringData:(nameFilter,typeFilter,sort)=> dispatch(actionsCreator.setFilteringData({nameForFilter:nameFilter, typeForFilter:typeFilter, sortBy:sort}))        
    });

var FilterPanel_ReduxWrapped = connect(mapStateToProps, mapDispatchToProps)(FilterPanel);

export default FilterPanel_ReduxWrapped;