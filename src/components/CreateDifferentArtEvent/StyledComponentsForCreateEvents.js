import styled from "styled-components";

export const Input = styled.input`
  display: block;
  box-sizing: border-box;
  width: 100%;
  border-radius: 4px;
  border: 1px solid black;
  padding: 10px 15px;
  margin-bottom: 10px;
  font-size: 14px;
`;
export const Select = styled.select`
  display: block;
  box-sizing: border-box;
  width: 100%;
  border-radius: 4px;
  border: 1px solid black;
  padding: 10px 15px;
  margin-bottom: 10px;
  font-size: 14px;
`;


export const Form = styled.form`
  margin: 0 auto;
  width: 500px;  
`;

export const Label=styled.label`
  line-height: 1.5;
  text-align: left;
  display: block;
  margin-bottom: 5px;
  margin-top: 20px;
  font-size: 14px;
  font-weight: 200;

`;

export const ErrorMessage= styled.h4`
    margin-top: -8px;
    color: red;
    position: absolute ;
    `;
export const SubmitButton= styled.button`
  margin-top:13px;
`;
export const MapHeader = styled.h3`
    text-align: center;
`;
