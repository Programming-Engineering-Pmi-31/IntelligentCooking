import { connect } from 'react-redux';
import { bindActionCreators } from 'redux';
import * as dishesActions from '../actions/dishes';
import * as authActions from '../actions/auth';
import Header from '../components/Header';

const mapDispatchToProps = dispatch => ({
    ...bindActionCreators(dishesActions, dispatch),
    ...bindActionCreators(authActions, dispatch),
});
const mapStateToProps = ({ dishes }) => ({
    dishes: dishes.dishes,
    isLoading: dishes.isLoading,
});
export default connect(
    mapStateToProps,
    mapDispatchToProps,
)(Header);
