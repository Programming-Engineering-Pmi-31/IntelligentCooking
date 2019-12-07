import { connect } from 'react-redux';
import { bindActionCreators } from 'redux';
import * as categoriesActions from '../actions/categories';
import { AllCategories } from '../components/AllCategories';

const mapDispatchToProps = dispatch => ({
    ...bindActionCreators(categoriesActions, dispatch),
});
const mapStateToProps = ({ categories, auth }) => ({
    categories: categories.categories,
    isAuth: auth.isAuth,
});
export default connect(
    mapStateToProps,
    mapDispatchToProps,
)(AllCategories);
