import { connect } from 'react-redux'
import * as categoriesActions from "../actions/categories"
import CategoriesSlider from '../components/CategoriesSlider'
import { bindActionCreators } from 'redux';


const mapDispatchToProps = dispatch => ({
    ...bindActionCreators(categoriesActions, dispatch)
})
const mapStateToProps = ({ categories }) => ({
    categories: categories.categories
})
export default connect(mapStateToProps, mapDispatchToProps)(CategoriesSlider);
