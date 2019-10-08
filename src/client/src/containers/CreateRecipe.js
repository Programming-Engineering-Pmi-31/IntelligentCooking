import { connect } from 'react-redux'
import * as ingredientsActions from "../actions/ingredients"
import * as categoriesAcrions from '../actions/categories'
import CreateRecipe from '../components/CreateRecipe'
import { bindActionCreators } from 'redux';


const mapDispatchToProps = dispatch => ({
    ...bindActionCreators(ingredientsActions, dispatch),
    ...bindActionCreators(categoriesAcrions, dispatch)
})
const mapStateToProps = ({ingredients,categories}) => ({
    ingredientsList: ingredients.ingredients,
    categoriesList: categories.categories
})

export default connect(mapStateToProps,mapDispatchToProps)(CreateRecipe);
