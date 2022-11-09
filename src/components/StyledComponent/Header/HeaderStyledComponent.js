import styled from "styled-components";

export const BaseNavBarItem = styled.div`
    margin: 5px;
    padding: 2px;
    border: 0px solid black;
    border-radius: 3px;    
`;
export const NavBarItem = styled(BaseNavBarItem)`
    width: 13%;
    cursor: pointer; 
    font-size: 1.5rem;  
    
    background-color: ${({ navPath, currentPath }) => navPath == currentPath ? "royalblue" : "white"};
    &:hover{
        background-color:royalblue
    }
`;

export const MainUniversalHeader = styled.div`
    position: fixed;
    box-sizing: border-box;
    top: 0rem;
    z-index: 1000;
    width: 100%;
    min-width:800px;
    height: 6rem;
    background-color: whitesmoke;
    padding: 0 1rem 1rem 1rem;
    margin: 0;   
`;
export const Navbar = styled.div`
    background-color: lightskyblue;
    text-align: center; 
    display: flex;
    flex-direction: row;
    justify-content: center;
    align-items: center;
    height: 60px;  
    border-radius: 3px; 
   
    & div:first-child{
        margin-left: auto;
    }
    & div:last-child{
        margin-left: auto;
        background-color:lightskyblue; 
    }
`;
export const UserNameField = styled.div`    
    margin: 1rem;
    display: flex;
    flex-direction: row;
    justify-content: end;
    align-items:flex-start
`;

export const LogInOutItem = styled(BaseNavBarItem)`
    display: flex;
    background-color:lightblue;
`;




