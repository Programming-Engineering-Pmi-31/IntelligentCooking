import { connect } from 'react-redux';
import { bindActionCreators } from 'redux';
import * as dishesActions from '../actions/dishes';
import * as categoriesActions from '../actions/categories';
import * as sortActions from '../actions/sort';
import * as authActions from '../actions/auth';
import MainPage from '../components/MainPage';

const mapDispatchToProps = dispatch => ({
    ...bindActionCreators(dishesActions, dispatch),
    ...bindActionCreators(authActions, dispatch),
    ...bindActionCreators(categoriesActions, dispatch),
    ...bindActionCreators(sortActions, dispatch),
});
const mapStateToProps = ({ dishes, categories, sort }) => ({
    categories: categories.categories,
    dishes: dishes,
    isLoading: dishes.isLoading,
    favourite: dishes.favourite,
});
export default connect(
    mapStateToProps,
    mapDispatchToProps,
)(MainPage);
