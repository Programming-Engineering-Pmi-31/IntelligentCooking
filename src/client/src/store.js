import { createStore, applyMiddleware } from 'redux';
import { logger } from 'redux-logger';
import { composeWithDevTools } from 'redux-devtools-extension';
import thunk from 'redux-thunk';
import rootReducer from './reducers/rootReducer';

export default () => {
    const store = createStore(rootReducer, composeWithDevTools(applyMiddleware(logger, thunk)));
    return store;
};
