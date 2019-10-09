import { connect } from 'react-redux'
import * as dishesActions from "../actions/dishes"
import * as categoriesActions from "../actions/categories"
import * as sortActions from "../actions/sort"
import AllRecipes from '../components/AllRecipes'
import { bindActionCreators } from 'redux';

import orderBy from "lodash/orderBy";


const sortBy = (dishes, sortedItem) => {
    switch (sortedItem) {
        case 'popular':
            return orderBy(dishes, "rating", 'desc');
        case 'lowesttime':
            return orderBy(dishes, "time", 'asc');
        case 'lowestcals':
            return orderBy(dishes, "cals", 'asc');
        default:
            return dishes;
    }
};

const mapDispatchToProps = dispatch => ({
    ...bindActionCreators(categoriesActions,dispatch),
    ...bindActionCreators(dishesActions, dispatch),
    ...bindActionCreators(sortActions, dispatch)
})
const mapStateToProps = ({ dishes,sort}) => ({
    dishes: sortBy(dishes.dishes,sort.sortedItem)
})
export default connect(mapStateToProps, mapDispatchToProps)(AllRecipes);
