import axios from 'axios';

export const setRecipesEmpty = () => dispatch => {
    dispatch({ type: 'SET_RECIPES_EMPTY' });
};
export const setExactRecipeEmpty = () => dispatch => {
    dispatch({ type: 'SET_EXACT_RECIPE_EMPTY' });
};

export const setRecipe = skip => dispatch => {
    dispatch({ type: 'SET_RECIPES_REQUEST' });
    axios
        .get('https://localhost:44335/api/Dish', {
            params: { skip: skip, take: 1, byCalories: false },
        })
        .then(res => {
            dispatch({ type: 'SET_RECIPE_SUCCESS', payload: res.data });
        });
};
export const setRecipes = (skip, take) => dispatch => {
    dispatch({ type: 'SET_RECIPES_REQUEST' });
    axios
        .get('https://localhost:44335/api/Dish', {
            params: { skip: skip, take: take, byCalories: false },
        })
        .then(res => {
            dispatch({ type: 'SET_RECIPES_SUCCESS', payload: res.data });
            if (res.data.length === 0) dispatch({ type: 'NO_MORE_ITEMS' });
        });
};

export const getRecipe = id => dispatch => {
    axios.get(`https://localhost:44335/api/Dish/${id}`).then(res => {
        dispatch({ type: 'GET_RECIPE', payload: res.data });
    });
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
    for (const [i, val] of obj.img.entries()) {
        console.log(val);
        if (val !== null) formData.append('images', val);
    }

    for (const [i, val] of obj.ingredients.entries()) formData.append(`ingredients[${i}]`, val);

    for (const [i, val] of obj.categories.entries()) formData.append(`categories[${i}]`, val);

    for (const [i, val] of obj.ingredientAmounts.entries())
        formData.append(`ingredientAmounts[${i}]`, val);

    return axios({
        method: 'POST',
        url: 'https://localhost:44335/api/Dish',
        data: formData,
    }).then(res => {
        dispatch({ type: 'ADD_RECIPE', payload: res.data });
        return res;
    });
};
