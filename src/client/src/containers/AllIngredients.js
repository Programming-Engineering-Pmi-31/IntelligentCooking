import { connect } from 'react-redux';
import { bindActionCreators } from 'redux';
import * as ingredientsActions from '../actions/ingredients';
import { AllIngredients } from '../components/AllIngredients';

const mapDispatchToProps = dispatch => ({
    ...bindActionCreators(ingredientsActions, dispatch),
});
const mapStateToProps = ({ ingredients, auth }) => ({
    ingredients: ingredients.ingredients,
    isAuth: auth.isAuth,
});
export default connect(
    mapStateToProps,
    mapDispatchToProps,
)(AllIngredients);
