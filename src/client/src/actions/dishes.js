import axios from 'axios';
import { trackPromise } from 'react-promise-tracker';

export const setRecipes = () => dispatch => {
    trackPromise(
        axios
            .get('https://localhost:44335/api/Dish', { params: { skip: 0, take: 24} })
            .then(res => {
                dispatch({ type: 'SET_RECIPES', payload: res.data });
            }),
    );
};

export const createProduct = obj => dispatch => {
    const formData = new FormData();
    for (const val in obj) {
        if (
            val !== 'ingredients' &&
            val !== 'categories' &&
            val !== 'ingredientAmounts' &&
            val !== 'img'
        )
            formData.append(val, obj[val]);
    }
    for (const [i, val] of obj.img.entries())
        if (val !== null) formData.append(`imgages[${i}]`, val);

    for (const [i, val] of obj.ingredients.entries()) formData.append(`ingredients[${i}]`, val);

    for (const [i, val] of obj.categories.entries()) formData.append(`categories[${i}]`, val);

    for (const [i, val] of obj.ingredientAmounts.entries())
        formData.append(`ingredientAmounts[${i}]`, val);

    axios({
        method: 'POST',
        url: 'https://localhost:44335/api/Dish',
        data: formData,
    }).then(res => {
        dispatch({ type: 'ADD_RECIPE', payload: res.data });
        console.log(res);
    });
};
