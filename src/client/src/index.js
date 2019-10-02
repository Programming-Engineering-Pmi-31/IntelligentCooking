import React from 'react';
import ReactDOM from 'react-dom';
import { Provider } from 'react-redux'
import createStore from "./store"
import MainPage from "./containers/MainPage"
import {BrowserRouter as Router,Route} from "react-router-dom"
import "@fortawesome/free-regular-svg-icons"
import { library } from '@fortawesome/fontawesome-svg-core'
import {faHeart} from "@fortawesome/free-regular-svg-icons"
library.add(faHeart)

const store = createStore();

ReactDOM.render(
    <Provider store={store}>
        <Router>
            <Route path="/" component={MainPage} />
        </Router>
    </Provider>,
    document.getElementById('root')
);

