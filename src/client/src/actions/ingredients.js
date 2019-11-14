import axios from 'axios';

export const setIngredients = () => dispatch => {
    axios.get('https://intelligentcookingweb.azurewebsites.net/api/Ingredient').then(res => {
        dispatch({ type: 'SET_INGREDIENTS', payload: res.data });
    });
};
