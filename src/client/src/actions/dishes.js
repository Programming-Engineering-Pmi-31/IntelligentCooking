import axios from 'axios';

export const setRecipesEmpty = () => dispatch => {
    dispatch({ type: 'SET_RECIPES_EMPTY' });
};
export const setExactRecipeEmpty = () => dispatch => {
    dispatch({ type: 'SET_EXACT_RECIPE_EMPTY' });
};
export const updateRecipeRequest = id => dispatch => {
    dispatch({ type: 'UPDATE_RECIPE_REQUEST' });
};
export const deleteRecipe = id => dispatch => {
    axios.delete(`https://intelligentcookingweb.azurewebsites.net/api/Dish/${id}`).then(res => {
        dispatch({ type: 'DELETE_RECIPE', payload: id });
    });
};

export const setRecipe = skip => dispatch => {
    dispatch({ type: 'SET_RECIPES_REQUEST' });
    axios
        .get('https://intelligentcookingweb.azurewebsites.net/api/Dish', {
            params: { skip: skip, take: 1, byCalories: false },
        })
        .then(res => {
            dispatch({ type: 'SET_RECIPE_SUCCESS', payload: res.data });
        });
};
export const setSort = (criteria, order) => dispatch => {
    dispatch({ type: 'SET_SORT', payload: { criteria: criteria, order: order } });
};

export const setRecipes = (skip, take, criteria, order) => dispatch => {
    dispatch({ type: 'SET_RECIPES_REQUEST' });
    axios
        .get('https://intelligentcookingweb.azurewebsites.net/api/Dish', {
            params: { skip: skip, take: take, sortingCriteria: criteria, isAscending: order },
        })
        .then(res => {
            dispatch({ type: 'SET_RECIPES_SUCCESS', payload: res.data });
            if (res.data.length === 0) dispatch({ type: 'NO_MORE_ITEMS' });
        });
};

export const getRecipe = id => dispatch => {
    return axios.get(`https://intelligentcookingweb.azurewebsites.net/api/Dish/${id}`).then(res => {
        dispatch({ type: 'GET_RECIPE', payload: res.data });
        return res.data;
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
        url: 'https://intelligentcookingweb.azurewebsites.net/api/Dish',
        data: formData,
    }).then(res => {
        dispatch({ type: 'ADD_RECIPE', payload: res.data });
        return res;
    });
};
