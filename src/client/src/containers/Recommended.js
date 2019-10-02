import { connect } from 'react-redux'
import * as dishesActions from "../actions/dishes"
import Recommended from '../components/Recommended'
import { bindActionCreators } from 'redux';


const mapDispatchToProps = dispatch => ({
    ...bindActionCreators(dishesActions, dispatch)
})
const mapStateToProps = ({ dishes }) => ({
    dishes: dishes.dishes
})
export default connect(mapStateToProps, mapDispatchToProps)(Recommended);
