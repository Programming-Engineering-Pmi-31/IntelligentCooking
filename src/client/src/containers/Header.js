import { connect } from 'react-redux';
import { bindActionCreators } from 'redux';
import * as dishesActions from '../actions/dishes';
import Header from '../components/Header';

const mapDispatchToProps = dispatch => ({
    ...bindActionCreators(dishesActions, dispatch),
});
const mapStateToProps = ({ dishes }) => ({
    dishes: dishes.dishes,
    isLoading: dishes.isLoading,
});
export default connect(
    mapStateToProps,
    mapDispatchToProps,
)(Header);
