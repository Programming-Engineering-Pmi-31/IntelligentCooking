import { connect } from 'react-redux';
import { bindActionCreators } from 'redux';
import orderBy from 'lodash/orderBy';
import * as dishesActions from '../actions/dishes';
import * as categoriesActions from '../actions/categories';
// import * as sortActions from '../actions/sort';
import * as authActions from '../actions/auth';
import AllRecipes from '../components/AllRecipes';

const sortBy = (dishes, sortedItem) => {
    switch (sortedItem) {
        case 'popular':
            return orderBy(dishes, 'rating', 'desc');
        case 'lowesttime':
            return orderBy(dishes, 'time', 'asc');
        case 'lowestcals':
            return orderBy(dishes, 'calories', 'asc');
        default:
            return dishes;
    }
};

const mapDispatchToProps = dispatch => ({
    ...bindActionCreators(categoriesActions, dispatch),
    ...bindActionCreators(dishesActions, dispatch),
    ...bindActionCreators(authActions, dispatch),
    // ...bindActionCreators(sortActions, dispatch),
});
const mapStateToProps = ({ dishes, sort, auth}) => ({
    dishes: sortBy(dishes.dishes, sort.sortedItem),
    isAuth: auth.isAuth,
    token: auth.token,
    isLoading: dishes.isLoading,
    firstLoad: dishes.firstLoad,
    noItems: dishes.noItems,
    skip: dishes.skip,
    sortingCriteria: dishes.sortingCriteria,
    isAscending: dishes.isAscending,
    count: dishes.count,
    dishesPages: dishes.dishesPages,
    dishesToLoad: dishes.dishesToLoad,
});
export default connect(
    mapStateToProps,
    mapDispatchToProps,
)(AllRecipes);
