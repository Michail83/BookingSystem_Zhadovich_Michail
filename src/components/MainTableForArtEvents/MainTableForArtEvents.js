import React, { useEffect, useState, Fragment } from "react";
import { useStateIfMounted } from "use-state-if-mounted";

import HomeArtEventView from '../HomeArtEventView/HomeArtEventView';
// import './MainTableForArtEvents.css';
import urls from '../../API_URL'
import axios from "axios";
import { connect } from "react-redux";
import actionCreator from "../../Store/ActionsCreators/actionCreator.js";
import FilterPanel_ReduxWrapped from "../FilterPanel/FilterPanel";
import PaginationPanel_ReduxWrapped from "../PaginationPanel/PaginationPanel"
import styled from "styled-components";

const Flexblock = styled.div`
 box-sizing: border-box;
    display: flex;
    flex-flow: row wrap;
    margin-top: 19vh;
    /* background-color: rgba(87, 169, 252, 0.822); */
`;
const NoResult = styled.div`
    padding: 1vh 1vw;
    font-size: 4rem;
    font-weight: bold;
`;
const ShowLoading = styled.div`
    position: absolute;
    top: 45vh;
    left: 30vw;
    z-index: 1000;
    font-size: 10rem;
    opacity: 0.3;
`;

const MainTableForArtEvents = ({
    artEventItems, setArtEventItems, setPaginationData,
    sortBy, nameForFilter, typeForFilter,
    currentPage, pageSize
}) => {
    const [loading, setLoading] = useStateIfMounted(true);
    const [error, setError] = useStateIfMounted(undefined);

    const loadArtEvents = async (filteringData) => {
        try {
            setLoading(true); 
            let artEventsUrl = urls.getArtEventWithFilterQuery(filteringData);     
            console.log(artEventsUrl);  
            let result = await axios.get(artEventsUrl);
            let paginationData = JSON.parse(result.headers["pagestateinfo"]);
            
            setPaginationData(paginationData);

            setArtEventItems(result.data);
        } catch (err) {
            console.log("error in MainTableForArtEvents => loadArtEvents  " + err);
            setError(err);
            setArtEventItems([]);
        } finally {
            setLoading(false);
        }
    }

    useEffect(() => {
        loadArtEvents({ sortBy, nameForFilter, typeForFilter,currentPage, pageSize });
    }, [sortBy, nameForFilter, typeForFilter,currentPage, pageSize]);

    const createComponent = () => {
        let content = "NOOOOO";
        if (loading) {
            return <ShowLoading>Loading...</ShowLoading>
        } else {
            if (error != undefined) {
                console.log(error);
                return content;
            }
        }
        if (artEventItems.length) {
            content = artEventItems.map((item) => (<HomeArtEventView key={item.id} {...item} />));
        } else {
            content = <NoResult>No result</NoResult>;
        }
        return content;
    }

    return (
        <Fragment>
            <FilterPanel_ReduxWrapped />
            <Flexblock>
                {createComponent()}
                <PaginationPanel_ReduxWrapped />
            </Flexblock>
        </Fragment>
    )
}

const mapStateToProps = state => ({
    artEventItems: state.state.artEventItems,
    // filteringData: state.state.filteringData,

    sortBy: state.state.filteringData.sortBy,
    nameForFilter: state.state.filteringData.nameForFilter,
    typeForFilter: state.state.filteringData.typeForFilter,

    currentPage: state.state.filteringData.currentPage,
    pageSize: state.state.filteringData.pageSize,
    // totalPages: state.state.filteringData.totalPages,


});

const mapDispatchToProps = dispatch => (
    {
        setArtEventItems: (artItems) => dispatch(actionCreator.SetArtEventItems(artItems)),

        setPaginationData: (paginationData) => dispatch(actionCreator.setPaginationData(paginationData))
    });

var MainTableForArtEvents_ReduxWrapped = connect(mapStateToProps, mapDispatchToProps)(MainTableForArtEvents);

export default MainTableForArtEvents_ReduxWrapped;



// const testData= [
//     {
//         "id": 15,
//         "iventName": "OpenAir",
//         "amounOfTicket": 101,
//         "date": "2012-12-12T00:00:00",
//         "place": "unknown1",
//         "typeOfArtEvent": "OpenAir",
//         "additionalInfo": [
//             "bi-3"
//         ]
//     },
//     {
//         "id": 16,
//         "iventName": "VeryOpenAir",
//         "amounOfTicket": 20,
//         "date": "2022-12-12T00:00:00",
//         "place": "known2",
//         "typeOfArtEvent": "OpenAir",
//         "additionalInfo": [
//             "meettaall"
//         ]
//     },
//     {
//         "id": 17,
//         "iventName": "VeryAgeLimitation",
//         "amounOfTicket": 22,
//         "date": "2022-12-01T00:00:00",
//         "place": "known2222",
//         "typeOfArtEvent": "Party",
//         "additionalInfo": [
//             "15"
//         ]
//     },
//     {
//         "id": 18,
//         "iventName": "Veryssssssssss",
//         "amounOfTicket": 2200,
//         "date": "2023-12-01T00:00:00",
//         "place": "known11111111111111111111111111",
//         "typeOfArtEvent": "Party",
//         "additionalInfo": [
//             "0"
//         ]
//     },
//     {
//         "id": 19,
//         "iventName": "VeryclassicMusic",
//         "amounOfTicket": 500,
//         "date": "2022-11-12T00:00:00",
//         "place": "known2",
//         "typeOfArtEvent": "ClassicMusic",
//         "additionalInfo": [
//             "TheBest",
//             "best"
//         ]
//     }
// ]

