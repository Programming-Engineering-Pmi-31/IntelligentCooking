import { createStore, applyMiddleware} from 'redux'
import {logger} from 'redux-logger'
import { composeWithDevTools } from 'redux-devtools-extension';
import rootReducer from './reducers/rootReducer'
import thunk from 'redux-thunk';

export default () =>{
    const store = createStore(rootReducer,composeWithDevTools(applyMiddleware(logger,thunk)))
    return store;
}

