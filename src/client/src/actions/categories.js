import axios from 'axios';

export const setCategories = () => dispatch => {
    axios.get('https://localhost:44335/api/category').then(res => {
        dispatch({ type: 'SET_CATEGORIES', payload: res.data });
    });
};
