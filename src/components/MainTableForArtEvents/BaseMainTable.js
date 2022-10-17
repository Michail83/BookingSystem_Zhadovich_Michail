import React, { useEffect, Fragment } from "react";
import { useStateIfMounted } from "use-state-if-mounted";

// import HomeArtEventView from '../HomeArtEventView/HomeArtEventView';
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
    margin-top: 9rem;
`;
const NoResult = styled.div`
    padding: 1rem;
    font-size: 4rem;
    font-weight: bold;
    margin: 0 auto;
`;
const ShowLoading = styled.div`
    position: absolute;
    top: 50%;
    left: 25%;
    z-index: 1000;
    font-size: 10rem;
    opacity: 0.3;
`;

const BaseMainTable = ({
    artEventItems, setArtEventItems, setPaginationData,
    sortBy, nameForFilter, typeForFilter,
    currentPage, pageSize, ArtEventType
}) => {
    const [loading, setLoading] = useStateIfMounted(true);
    const [error, setError] = useStateIfMounted(undefined);

    const loadArtEvents = async (filteringData) => {
        try {
            setLoading(true); 
            let artEventsUrl = urls.getArtEventWithFilterQuery(filteringData);
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
        let content = <NoResult>Error when loading art event</NoResult>;
        if (loading) {
            return <ShowLoading>Loading...</ShowLoading>
        } else {
            if (error != undefined) {
                console.log("Create component error");
                return content;
            }
        }
        if (artEventItems.length) {
            content = artEventItems.map((item) => (<ArtEventType key={item.id} {...item} />));
            content = <>
                {content}
                <PaginationPanel_ReduxWrapped />
            </>
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
                {/* <PaginationPanel_ReduxWrapped /> */}
            </Flexblock>
        </Fragment>
    )
}

const mapStateToProps = state => ({
    artEventItems: state.state.artEventItems,   

    sortBy: state.state.filteringData.sortBy,
    nameForFilter: state.state.filteringData.nameForFilter,
    typeForFilter: state.state.filteringData.typeForFilter,

    currentPage: state.state.filteringData.currentPage,
    pageSize: state.state.filteringData.pageSize, 
});

const mapDispatchToProps = dispatch => (
    {
        setArtEventItems: (artItems) => dispatch(actionCreator.SetArtEventItems(artItems)),

        setPaginationData: (paginationData) => dispatch(actionCreator.setPaginationData(paginationData))
    });

var BaseMainTable_ReduxWrapped = connect(mapStateToProps, mapDispatchToProps)(BaseMainTable);

export default BaseMainTable_ReduxWrapped;

