import { createStore, applyMiddleware} from 'redux'
import {logger} from 'redux-logger'
import { composeWithDevTools } from 'redux-devtools-extension';
import rootReducer from './reducers/rootReducer'

export default () =>{
    const store = createStore(rootReducer,composeWithDevTools(applyMiddleware(logger)))
    return store;
}

