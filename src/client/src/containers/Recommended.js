import { connect } from 'react-redux';
import { bindActionCreators } from 'redux';
import * as dishesActions from '../actions/dishes';
import Recommended from '../components/Recommended';

const mapDispatchToProps = dispatch => ({
    ...bindActionCreators(dishesActions, dispatch),
});
const mapStateToProps = ({ dishes }) => ({
    recommended: dishes.recommended,
});
export default connect(
    mapStateToProps,
    mapDispatchToProps,
)(Recommended);
