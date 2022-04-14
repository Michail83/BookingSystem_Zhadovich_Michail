import { createStore, applyMiddleware } from 'redux';
import { rootReducer } from "./Reducers/rootReducer";
import { syncLocalStorageMidlleware } from "./Midlleware/syncLocalStorageMidlleware"
import logger from "redux-logger";


export default function configureStore() {
    const store = createStore(rootReducer, applyMiddleware(syncLocalStorageMidlleware, logger));
    return store;
}