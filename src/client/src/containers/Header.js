import { connect } from 'react-redux'
import * as dishesActions from "../actions/dishes"
import Header from '../components/Header'
import { bindActionCreators } from 'redux';


const mapDispatchToProps = dispatch => ({
  ...bindActionCreators(dishesActions, dispatch)
})
const mapStateToProps = ({ dishes }) => ({
  dishes: dishes.dishes,
  isLoading: dishes.isLoading
})
export default connect(mapStateToProps, mapDispatchToProps)(Header);
