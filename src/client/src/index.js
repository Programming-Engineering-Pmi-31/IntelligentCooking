import React from 'react';
import ReactDOM from 'react-dom';
import { Provider } from 'react-redux';
import { BrowserRouter as Router, Route, Switch } from 'react-router-dom';
import { faHeart } from '@fortawesome/free-regular-svg-icons';
import { library } from '@fortawesome/fontawesome-svg-core';
import createStore from './store';
import MainPage from './containers/MainPage';
import CreateRecipe from './containers/CreateRecipe';
import RecipeCard from './containers/RecipeCard';
import './script';
import NoMatch from './components/NotFound';

library.add(faHeart);

const store = createStore();

ReactDOM.render(
    <Provider store={store}>
        <Router>
            <Switch>
                <Route path="/recipe/:id" component={RecipeCard} />
                <Route path="/create" component={CreateRecipe} />
                <Route exact path="/" component={MainPage} />
                <Route component={NoMatch} />
            </Switch>
        </Router>
    </Provider>,
    document.getElementById('root'),
);
