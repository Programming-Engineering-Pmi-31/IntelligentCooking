import axios from 'axios';

const baseURL = axios.create({
    baseURL: 'https://intelligentcookingweb.azurewebsites.net/api/',
});

const dishesApi = {
    getRecipes(skip, take, criteria, order) {
        return baseURL
            .get('Dish/', {
                params: { skip: skip, take: take, sortingCriteria: criteria, isAscending: order },
            })
            .then(res => res);
    },
    getRecommended(amount) {
        return baseURL
            .get('Dish/top', {
                params: { amount: amount },
            })
            .then(res => res);
    },
    getRecipe(id) {
        return baseURL.get(`Dish/${id}`).then(res => res);
    },
    searchDish(name, includeIngredients, excludeIngredients) {
        return baseURL
            .post('Dish/search', {
                name: name,
                includeIngredients: includeIngredients,
                excludeIngredients: excludeIngredients,
            })
            .then(res => res);
    },
    createDish(formData) {
        return baseURL.post('Dish/', formData).then(res => res);
    },
    updateDish(formData, id) {
        return baseURL.put(`Dish/${id}`, formData).then(res => res);
    },
    deleteDish(id) {
        return baseURL.delete(`Dish/${id}`).then(res => res);
    },
    getDishesByCategory(id) {
        return baseURL.get(`Dish/category/${id}`).then(res => res);
    },
    rateDish(id, rating, token) {
        return baseURL
            .post(
                'Rating/',
                {
                    dishId: id,
                    rate: rating,
                },
                {
                    headers: { Authorization: `bearer ${token}` },
                },
            )
            .then(res => res)
            .catch(e => e.response);
    },
    likeDish(id) {
        const token = localStorage.getItem('token');
        return baseURL
            .post(
                'Favourite/',
                { dishId: id },
                {
                    headers: { Authorization: `bearer ${token}` },
                },
            )
            .then(res => res)
            .catch(e => e.response);
    },
};

const authApi = {
    registrateNewUser(email, login, password) {
        return baseURL
            .post('Auth/register', {
                email: email,
                userName: login,
                password: password,
            })
            .then(res => res);
    },
    loginUser(email, password) {
        return baseURL
            .post('Auth/login', {
                email: email,
                password: password,
            })
            .then(res => res)
            .catch(e => {
                alert('Your password is wrong');
            });
    },
    refreshToken(token, oldRefresh) {
        return baseURL
            .post('Auth/refresh', {
                token: token,
                refreshToken: oldRefresh,
            })
            .then(res => res);
    },
};

const categoriesAPI = {
    getCategories() {
        return baseURL.get('Category/').then(res => res);
    },
};

const ingredientsAPI = {
    getIngredients() {
        return baseURL.get('Ingredient/').then(res => res);
    },
};
export { dishesApi, authApi, categoriesAPI, ingredientsAPI };
