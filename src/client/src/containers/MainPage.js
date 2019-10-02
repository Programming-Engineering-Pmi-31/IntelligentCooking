import { connect } from 'react-redux'
import * as dishesActions from "../actions/dishes"
import * as categoriesActions from "../actions/categories"
import * as sortActions from "../actions/sort"
import MainPage from '../components/MainPage'

import { bindActionCreators } from 'redux';

const mapDispatchToProps = dispatch => ({
  ...bindActionCreators(dishesActions, dispatch),
  ...bindActionCreators(categoriesActions, dispatch),
  ...bindActionCreators(sortActions, dispatch),
})
const mapStateToProps = ({ dishes,categories,sort }) => ({
  categories: categories.categories,
  dishes: dishes,
  isLoading: dishes.isLoading
})
export default connect(mapStateToProps, mapDispatchToProps)(MainPage);
