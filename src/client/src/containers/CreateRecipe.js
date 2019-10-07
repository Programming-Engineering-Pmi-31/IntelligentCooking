import { connect } from 'react-redux'
import * as ingridientsActions from "../actions/ingridients"
import * as categoriesAcrions from '../actions/categories'
import CreateRecipe from '../components/CreateRecipe'
import { bindActionCreators } from 'redux';


const mapDispatchToProps = dispatch => ({
    ...bindActionCreators(ingridientsActions, dispatch),
    ...bindActionCreators(categoriesAcrions, dispatch)
})
const mapStateToProps = ({ingridients,categories}) => ({
    ingridients: ingridients.ingridients,
    categories: categories.categories
})

export default connect(mapStateToProps,mapDispatchToProps)(CreateRecipe);
