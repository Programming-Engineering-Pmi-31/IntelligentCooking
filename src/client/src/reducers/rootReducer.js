import { combineReducers } from 'redux';
import { dishes } from './dishes';
import { categories } from './categories';
import { sort } from './sort';
import { auth } from './auth';
import { ingredients } from './ingredients';

export default combineReducers({
    auth,
    dishes,
    categories,
    sort,
    ingredients,
});
