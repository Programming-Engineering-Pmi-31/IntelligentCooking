import { connect } from 'react-redux';
import { bindActionCreators } from 'redux';
import * as dishesActions from '../actions/dishes';
import * as categoriesActions from '../actions/categories';
import * as sortActions from '../actions/sort';
import RecipeCard from '../components/RecipeCard';

const mapDispatchToProps = dispatch => ({
    ...bindActionCreators(dishesActions, dispatch),
    ...bindActionCreators(categoriesActions, dispatch),
    ...bindActionCreators(sortActions, dispatch),
});
const mapStateToProps = ({ dishes, categories }) => ({
    categories: categories.categories,
    dishes: dishes,
    isLoading: dishes.isLoading,
});
export default connect(
    mapStateToProps,
    mapDispatchToProps,
)(RecipeCard);
