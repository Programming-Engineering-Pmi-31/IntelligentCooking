import { combineReducers } from 'redux'
import { dishes } from './dishes'
import { categories } from './categories'
import {sort} from './sort'
import {ingredients} from "./ingredients";

export default combineReducers({
    dishes,
    categories,
    sort,
    ingredients
})