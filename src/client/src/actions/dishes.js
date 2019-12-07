import axios from 'axios';
import { actionTypes } from './actionTypes';
import { authApi, dishesApi } from '../services/services';

export const setRecipesEmpty = () => dispatch => {
    dispatch({ type: actionTypes.dishesTypes.SET_RECIPES_EMPTY });
};
export const setExactRecipe = item => dispatch => {
    dispatch({ type: actionTypes.dishesTypes.SET_EXACT_RECIPE, payload: item });
};
export const setExactRecipeEmpty = () => dispatch => {
    dispatch({ type: actionTypes.dishesTypes.SET_EXACT_RECIPE_EMPTY });
};
export const updateRecipeRequest = id => dispatch => {
    dispatch({ type: actionTypes.dishesTypes.UPDATE_RECIPE_REQUEST });
};
export const updateRecipe = (id, obj) => async dispatch => {
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
    const imgUrls = [];
    const imgFiles = [];
    for (const [i, val] of obj.img.entries()) {
        if (val !== null && typeof val === 'string') {
            imgUrls.push({ priority: i + 1, value: val });
        } else if (val !== null && val instanceof File) {
            imgFiles.push({ priority: i + 1, value: val });
        }
    }
    for (const i in imgUrls) {
        formData.append(`imageUrls[${i}].Url`, imgUrls[i].value);
        formData.append(`imageUrls[${i}].Priority`, imgUrls[i].priority);
    }

    for (const i in imgFiles) {
        formData.append(`imageFiles[${i}].File`, imgFiles[i].value);
        formData.append(`imageFiles[${i}].Priority`, imgFiles[i].priority);
    }

    for (const [i, val] of obj.ingredients.entries()) formData.append(`ingredients[${i}]`, val);

    for (const [i, val] of obj.categories.entries()) formData.append(`categories[${i}]`, val);

    for (const [i, val] of obj.ingredientAmounts.entries())
        formData.append(`ingredientAmounts[${i}]`, val);
    console.log(formData);
    const updatedDish = await dishesApi.updateDish(formData, id);
    dispatch({ type: actionTypes.dishesTypes.CHANGE_AFTER_UPDATE, payload: updatedDish.data });
    return updatedDish;
};
export const updateRecipeFinish = id => dispatch => {
    dispatch({ type: actionTypes.dishesTypes.UPDATE_RECIPE_FINISH });
};
export const deleteRecipe = id => async dispatch => {
    const deleted = await dishesApi.deleteDish(id);
    dispatch({ type: actionTypes.dishesTypes.DELETE_RECIPE, payload: id });
};

export const setRecipe = (skip, take, criteria, order) => dispatch => {
    dispatch({ type: actionTypes.dishesTypes.SET_RECIPES_REQUEST });
    axios
        .get('https://intelligentcookingweb.azurewebsites.net/api/Dish', {
            params: { skip: skip, take: take, sortingCriteria: criteria, isAscending: order },
        })
        .then(res => {
            dispatch({ type: actionTypes.dishesTypes.SET_RECIPE_SUCCESS, payload: res.data });
        });
};
export const setSort = (criteria, order) => dispatch => {
    dispatch({
        type: actionTypes.dishesTypes.SET_SORT,
        payload: { criteria: criteria, order: order },
    });
};

export const setRecipes = (skip, take, criteria, order) => async dispatch => {
    dispatch({ type: actionTypes.dishesTypes.SET_RECIPES_REQUEST });
    const recipes = await dishesApi.getRecipes(skip, take, criteria, order);
    dispatch({ type: actionTypes.dishesTypes.SET_DISHES_COUNT, payload: recipes.data.count });
    dispatch({
        type: actionTypes.dishesTypes.SET_RECIPES_SUCCESS,
        payload: { dishes: recipes.data.dishes, load: take },
    });
    if (recipes.data.length === 0) dispatch({ type: actionTypes.dishesTypes.NO_MORE_ITEMS });
};

export const getRecipe = id => async dispatch => {
    const recipe = await dishesApi.getRecipe(id);
    dispatch({ type: actionTypes.dishesTypes.GET_RECIPE, payload: recipe.data });
    return recipe.data;
};
export const getRecommended = amount => async dispatch => {
    const recipes = await dishesApi.getRecommended(amount);
    dispatch({ type: actionTypes.dishesTypes.GET_RECOMMENDED_DISHES, payload: recipes.data });
    return recipes.data;
};
export const getDishesByCategory = id => async dispatch => {
    try {
        dispatch({ type: actionTypes.dishesTypes.GET_DISHES_BY_CATEGORY_REQUEST });
        const dishes = await dishesApi.getDishesByCategory(id);
        dispatch({
            type: actionTypes.dishesTypes.GET_DISHES_BY_CATEGORY_SUCCESS,
            payload: dishes.data.dishes,
        });
        console.log(dishes.data);
        return dishes.data;
    } catch {}
};
export const rateDish = ({ id, rating, count, totalRating }) => async dispatch => {
    const token = localStorage.getItem('token');
    let ratedDish = await dishesApi.rateDish(id, rating, token);
    console.log('rated', ratedDish);
    if (ratedDish.status === 401) {
        const refreshToken = localStorage.getItem('refreshToken');
        const newToken = await authApi.refreshToken(token, refreshToken);
        if (newToken.status === 200) {
            localStorage.setItem('token', newToken.data.token);
            localStorage.setItem('refreshToken', newToken.data.refreshToken);
            ratedDish = await dishesApi.rateDish(id, rating, newToken.data.token);
            console.log(ratedDish);
        }
    }
    if (ratedDish.data.isNewRate) {
        dispatch({
            type: actionTypes.dishesTypes.SET_RATING,
            payload: { id: id, rating: (count * totalRating + rating) / (count + 1), toAdd: 1 },
        });
    } else {
        dispatch({
            type: actionTypes.dishesTypes.SET_RATING,
            payload: { id: id, rating: ((count * totalRating + rating - ratedDish.data.oldRate) / count), toAdd: 0 },
        });
    }
};

export const searchDish = ({ name, includeIngredients, excludeIngredients }) => async dispatch => {
    dispatch({ type: actionTypes.dishesTypes.SET_RECIPES_EMPTY });
    const recipes = await dishesApi.searchDish(name, includeIngredients, excludeIngredients);
    dispatch({ type: actionTypes.dishesTypes.SEARCH_DISHES, payload: recipes.data });
};
export const setFavourite = () => async dispatch => {
    let favourite = await dishesApi.setFavourite();
    if(favourite.status === 401){
        const token = localStorage.getItem('token');
        const refreshToken = localStorage.getItem('refreshToken');
        const newToken = await authApi.refreshToken(token, refreshToken);
        if (newToken.status === 200) {
            localStorage.setItem('token', newToken.data.token);
            localStorage.setItem('refreshToken', newToken.data.refreshToken);
            favourite = await dishesApi.setFavourite();
        }
    }
    dispatch({ type: actionTypes.dishesTypes.SET_FAVOURITE, payload: favourite });
};
export const addToFavourite = id => async dispatch => {
    const token = localStorage.getItem('token');
    let likedDish = await dishesApi.addToFavourite(id);
    if (likedDish.status === 401) {
        const refreshToken = localStorage.getItem('refreshToken');
        const newToken = await authApi.refreshToken(token, refreshToken);
        if (newToken.status === 200) {
            localStorage.setItem('token', newToken.data.token);
            localStorage.setItem('refreshToken', newToken.data.refreshToken);
            likedDish = await dishesApi.getRecipe(id);
            dispatch({ type: actionTypes.dishesTypes.ADD_FAVOURITE, payload: {id:id, dish: likedDish.data} });
            dishesApi.addToFavourite(id);
            if(likedDish.status === 409){
                const deleted = await dishesApi.deleteFromFavourites(id);
                dispatch({ type: actionTypes.dishesTypes.DELETE_FROM_FAVOURITES, payload: id });
            }
        }
    } else if(likedDish.status === 409){
        const deleted = await dishesApi.deleteFromFavourites(id);
        dispatch({ type: actionTypes.dishesTypes.DELETE_FROM_FAVOURITES, payload: id });
        console.log(deleted);
    } else {
        likedDish = await dishesApi.getRecipe(id);
        dispatch({ type: actionTypes.dishesTypes.ADD_FAVOURITE, payload: {id:id, dish: likedDish.data} });
    }
};

export const createProduct = obj => async dispatch => {
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

    const newDish = await dishesApi.createDish(formData);
    dispatch({ type: actionTypes.dishesTypes.ADD_RECIPE, payload: newDish.data });
    console.log(newDish);
    return newDish;
};
