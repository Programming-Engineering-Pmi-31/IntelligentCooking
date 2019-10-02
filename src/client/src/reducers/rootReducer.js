import { combineReducers } from 'redux'
import { dishes } from './dishes'
import { categories } from './categories'
import {sort} from './sort'

export default combineReducers({
    dishes,
    categories,
    sort
})