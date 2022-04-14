import { createStore } from 'redux';
import reducer from './Reducers/rootReducer'
import initialState from './initialState';
import configureStore from "./configureStore"

const store = configureStore();
 
export default store;