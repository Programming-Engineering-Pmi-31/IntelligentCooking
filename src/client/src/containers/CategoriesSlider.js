import { connect } from 'react-redux';
import { bindActionCreators } from 'redux';
import * as categoriesActions from '../actions/categories';
import CategoriesSlider from '../components/CategoriesSlider';

const mapDispatchToProps = dispatch => ({
    ...bindActionCreators(categoriesActions, dispatch),
});
const mapStateToProps = ({ categories }) => ({
    categories: categories.categories,
});
export default connect(
    mapStateToProps,
    mapDispatchToProps,
)(CategoriesSlider);
