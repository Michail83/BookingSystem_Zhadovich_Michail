import createArrayWithPageNumber from "./CreateArrayWithPageNumber";
import { connect } from "react-redux";
import styled from "styled-components";
import actionCreator from "../../Store/ActionsCreators/actionCreator";

const UlPagination = styled.ul`
  display: flex;
  padding-left: 0;
  list-style: none;
  border-radius: 0.25rem;
  margin: 0.5rem auto;
`;
const LiPage = styled.li`
     
    & :first-child{
        margin-left: 0;
  border-top-left-radius: 0.25rem;
  border-bottom-left-radius: 0.25rem;
    }
    & :last-child{
        border-top-right-radius: 0.25rem;
        border-bottom-right-radius: 0.25rem;
    }
`;
const LiPageActive=styled(LiPage)`
  z-index: 1;
  color: #fff;
  background-color: lightgray;
  /* border-color: #007bff; */
  border: 1px solid #007bff;
`;
const ApageLink = styled.a`
    position: relative;
    display: block;
    padding: 0.5rem 0.75rem;
    margin-left: -1px;
    line-height: 1.25;
    color: #007bff;
    /* background-color: #fff; */
    border: 1px solid #dee2e6;
    cursor: pointer;
    :hover{
        z-index: 2;
        color: #0056b3;
        text-decoration: none;
        background-color: lightgray;
        /* background-color: #e9ecef; */
        border-color: #dee2e6;
    }
    
`;

const PaginationPanel =({totalPages, currentPage, pageNeighbours, setCurrentPage})=>{
    // console.log("PaginationPanel");
    // console.log("totalPages "+totalPages );
    // console.log("currentPage "+ currentPage);



    if (totalPages<2) {
        return null;
    }

    const arrayWithPageNumber = createArrayWithPageNumber(totalPages, currentPage, pageNeighbours);
    const element = <UlPagination>
        {arrayWithPageNumber.map((page, index)=>{
        
        if (page ==="LEFT") {
            return (
                <LiPage key={index}>
                    <ApageLink onClick={()=>setCurrentPage(currentPage-pageNeighbours-1)} >
                    <span>&laquo;</span>
                    </ApageLink>

                </LiPage>
            )
        }
        if (page==="RIGHT") {
            return (
                <LiPage key={index}>
                    <ApageLink onClick={()=>setCurrentPage(currentPage+pageNeighbours+1)} >
                    <span>&raquo;</span>
                    </ApageLink>
                </LiPage>
            )             
        }
        const LI_PAGE= page==currentPage? LiPageActive:LiPage;

        return(
            <LI_PAGE key={index}>
            <ApageLink onClick={()=>setCurrentPage(page)}>
            <span>{page}</span>
            </ApageLink>
        </LI_PAGE>
        )
    })}
    </UlPagination>
    ;
    return(
        element
    )    
}

const mapStateToProps = state => ({
    totalPages:state.state.filteringData.totalPages,
    currentPage:state.state.filteringData.currentPage,
    pageNeighbours:state.state.filteringData.pageNeighbours    
});

const mapDispatchToProps = dispatch => (
    {
        setCurrentPage:(number)=> dispatch(actionCreator.setCurrentPage (number)), 
        // setfilteringDataToDefault:()=>dispatch(actionsCreator.setFilteringDataToDefault())     
    });



var PaginationPanel_ReduxWrapped = connect(mapStateToProps, mapDispatchToProps)(PaginationPanel);

export default PaginationPanel_ReduxWrapped;