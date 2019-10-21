import { connect } from 'react-redux';
import { bindActionCreators } from 'redux';
import * as ingredientsActions from '../actions/ingredients';
import * as categoriesAcrions from '../actions/categories';
import * as dishesActions from '../actions/dishes';
import CreateRecipe from '../components/CreateRecipe';

const mapDispatchToProps = dispatch => ({
    ...bindActionCreators(ingredientsActions, dispatch),
    ...bindActionCreators(categoriesAcrions, dispatch),
    ...bindActionCreators(dishesActions, dispatch),
});
const mapStateToProps = ({ ingredients, categories, dishes }) => ({
    ingredientsList: ingredients.ingredients,
    categoriesList: categories.categories,
    soloDish: dishes.soloDish,
    skip: dishes.skip,
});

export default connect(
    mapStateToProps,
    mapDispatchToProps,
)(CreateRecipe);
