import { connect } from 'react-redux';
import { bindActionCreators } from 'redux';
import * as categoriesActions from '../actions/categories';
import * as dishesActions from '../actions/dishes';
import CategoriesSlider from '../components/CategoriesSlider';

const mapDispatchToProps = dispatch => ({
    ...bindActionCreators(categoriesActions, dispatch),
    ...bindActionCreators(dishesActions, dispatch),
});
const mapStateToProps = ({ categories }) => ({
    categories: categories.categories,
});
export default connect(
    mapStateToProps,
    mapDispatchToProps,
)(CategoriesSlider);
