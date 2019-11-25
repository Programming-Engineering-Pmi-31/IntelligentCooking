import { connect } from 'react-redux';
import { bindActionCreators } from 'redux';
import * as dishesActions from '../actions/dishes';
import * as ingredientsActions from '../actions/ingredients';
import * as authActions from '../actions/auth';
import Header from '../components/Header';

const mapDispatchToProps = dispatch => ({
    ...bindActionCreators(dishesActions, dispatch),
    ...bindActionCreators(authActions, dispatch),
    ...bindActionCreators(ingredientsActions, dispatch),
});
const mapStateToProps = ({ dishes, auth, ingredients}) => ({
    ingredientsList: ingredients.ingredients,
    dishes: dishes.dishes,
    isLoading: dishes.isLoading,
    isAuth: auth.isAuth,
    login: auth.unique_name,
});
export default connect(
    mapStateToProps,
    mapDispatchToProps,
)(Header);
