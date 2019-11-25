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
export const updateRecipe = (id, obj) => dispatch => {
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
            // formData.append(`imageUrls[${i}].Url`, val);
            // formData.append(`imageUrls[${i}].Priority`, i+1);
        } else if (val !== null && val instanceof File) {
            imgFiles.push({ priority: i + 1, value: val });
            // formData.append(`imageFiles[${i}].File`, val);
            // formData.append(`imageFiles[${i}].Priority`, i+1);
        }
    }

    for (const i in imgUrls) {
        formData.append(`imageUrls[${i}].Url`, imgUrls[i].value);
        formData.append(`imageUrls[${i}].Priority`, imgUrls[i].priority);
    }
    // formData.append(`ImageUrls[${key}]`, imgUrls[key]);
    //
    for (const i in imgFiles) {
        formData.append(`imageFiles[${i}].File`, imgFiles[i].value);
        formData.append(`imageFiles[${i}].Priority`, imgFiles[i].priority);
    }
    // formData.append(`ImageFiles[${key}]`, imgFiles[key]);

    for (const [i, val] of obj.ingredients.entries()) formData.append(`ingredients[${i}]`, val);

    for (const [i, val] of obj.categories.entries()) formData.append(`categories[${i}]`, val);

    for (const [i, val] of obj.ingredientAmounts.entries())
        formData.append(`ingredientAmounts[${i}]`, val);
    console.log(formData);
    return axios({
        method: 'PUT',
        url: `https://intelligentcookingweb.azurewebsites.net/api/Dish/${id}`,
        data: formData,
    }).then(res => {
        return res;
    });
};
export const updateRecipeFinish = id => dispatch => {
    dispatch({ type: 'UPDATE_RECIPE_FINISH' });
};
export const deleteRecipe = id => dispatch => {
    axios.delete(`https://intelligentcookingweb.azurewebsites.net/api/Dish/${id}`).then(res => {
        dispatch({ type: 'DELETE_RECIPE', payload: id });
    });
};

export const setRecipe = (skip, take, criteria, order) => dispatch => {
    dispatch({ type: 'SET_RECIPES_REQUEST' });
    axios
        .get('https://intelligentcookingweb.azurewebsites.net/api/Dish', {
            params: { skip: skip, take: take, sortingCriteria: criteria, isAscending: order },
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
            dispatch({ type: 'SET_DISHES_COUNT', payload: res.data.count });
            dispatch({
                type: 'SET_RECIPES_SUCCESS',
                payload: { dishes: res.data.dishes, load: take },
            });
            if (res.data.length === 0) dispatch({ type: 'NO_MORE_ITEMS' });
        });
};

export const getRecipe = id => dispatch => {
    return axios.get(`https://intelligentcookingweb.azurewebsites.net/api/Dish/${id}`).then(res => {
        dispatch({ type: 'GET_RECIPE', payload: res.data });
        return res.data;
    });
};

export const rateDish = obj => dispatch => {
    return axios
        .post(
            `https://intelligentcookingweb.azurewebsites.net/api/Rating`,
            {
                dishId: obj.id,
                rate: obj.rating,
            },
            {
                headers: { Authorization: `bearer ${obj.token}` },
            },
        )
        .then(res => {
            console.log(res);
        })
        .catch(e => {
            if (e.response.status === 401) {
                return axios
                    .post('https://intelligentcookingweb.azurewebsites.net/api/Auth/refresh', {
                        token: obj.token,
                        refreshToken: obj.refreshToken,
                    })
                    .then(() => {
                        axios
                            .post(
                                `https://intelligentcookingweb.azurewebsites.net/api/Rating`,
                                {
                                    dishId: obj.id,
                                    rate: obj.rating,
                                },
                                {
                                    headers: { Authorization: `bearer ${obj.token}` },
                                },
                            )
                            .then(res => {
                                console.log(res);
                            });
                    });
            }
        });
};

export const filterByIngredient = obj => dispatch => {
    dispatch({ type: 'SET_RECIPES_EMPTY' });
    return axios
        .post(`https://intelligentcookingweb.azurewebsites.net/api/Dish/search`, {
            includeIngredients: obj.includeIngredients,
            excludeIngredients: obj.excludeIngredients,
        })
        .then(res => {
            // console.log(res);
            dispatch({ type: 'SET_DISHES_BY_FILTER', payload: res.data });
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
