import styled from "styled-components";

export const AboutArtEventDiv = styled.div`
    padding: 3px 3px;
    min-width: ${({currentMinWidth})=>currentMinWidth?currentMinWidth:"55%"} ;
    display: flex;
    flex-direction: column;
    justify-content: flex-start;
    margin-left: 1rem;
    &*{
        margin: 0.4rem
    }
`;