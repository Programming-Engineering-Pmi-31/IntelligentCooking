import React from 'react';
import ReactDOM from 'react-dom';
import { createBrowserHistory } from 'history';
import { Provider } from 'react-redux';
import { Router, Route, Switch } from 'react-router-dom';
import { faHeart } from '@fortawesome/free-regular-svg-icons';
import { library } from '@fortawesome/fontawesome-svg-core';
import createStore from './store';
import MainPage from './containers/MainPage';
import CreateRecipe from './containers/CreateRecipe';
import RecipeCard from './containers/RecipeCard';
import './script';
import NoMatch from './components/NotFound';
import EditRecipe from './containers/EditRecipe';
import { PrivateRoute } from './helpers/PrivateRoute';
import AllIngredients from './containers/AllIngredients';
import AllCategories from './containers/AllCategories';

const history = createBrowserHistory();
library.add(faHeart);

const store = createStore();

ReactDOM.render(
    <Provider store={store}>
        <Router history={history}>
            <Switch>
                <PrivateRoute path="/recipe/:id/edit" component={EditRecipe} />
                <Route path="/recipe/:id" component={RecipeCard} />
                <PrivateRoute exact path="/create" component={CreateRecipe} />
                <Route exact path="/allingredients" component={AllIngredients} />
                <Route exact path="/allcategories" component={AllCategories} />
                <Route exact path="/" component={MainPage} />
                <Route path="*" component={NoMatch} />
            </Switch>
        </Router>
    </Provider>,
    document.getElementById('root'),
);
