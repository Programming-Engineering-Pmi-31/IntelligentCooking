import axios from 'axios';

export const setCategories = () => dispatch => {
    axios.get('https://intelligentcookingweb.azurewebsites.net//api/Category').then(res => {
        dispatch({ type: 'SET_CATEGORIES', payload: res.data });
    });
};
