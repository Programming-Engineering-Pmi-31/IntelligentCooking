import axios from 'axios';
import { trackPromise } from 'react-promise-tracker';

export const setRecipes = () => dispatch => {
    trackPromise(
        axios.get('https://localhost:44335/api/Dish').then(res => {
            dispatch({ type: 'SET_RECIPES', payload: res.data });
        }),
    );
};

export const createProduct = obj => dispatch => {
    const formData = new FormData();
    for (const val in obj) {
        if (val !== 'ingredients' && val !== 'categories' && val !== 'ingredientAmounts')
            formData.append(val, obj[val]);
    }

    for (const [i, val] of obj.ingredients.entries()) formData.append(`ingredients[${i}]`, val);

    for (const [i, val] of obj.categories.entries()) formData.append(`categories[${i}]`, val);

    for (const [i, val] of obj.ingredientAmounts.entries())
        formData.append(`ingredientAmounts[${i}]`, val);

    axios({
        method: 'POST',
        url: 'https://localhost:44335/api/Dish',
        data: formData,
    });
    console.log(formData);
};
