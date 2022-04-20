import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { useParams } from "react-router-dom";
import urls from '../../API_URL'
import CartList from '../../components/Cart/Cart'
import  Orders from '../../components/Orders/Orders';

const OrderPage = ()=>{
    return (<Orders/>)
}
export default OrderPage;