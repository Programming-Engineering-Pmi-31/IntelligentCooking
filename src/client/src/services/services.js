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
    getRecipe(id) {
        return baseURL.get(`Dish/${id}`).then(res => res);
    },
    filterByIngredients(includeIngredients, excludeIngredients) {
        return baseURL
            .post('Dish/search', {
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
            .then(res => res);
    },
};

const authApi = {
    registrateNewUser(email, login, password) {
        return baseURL.post('Auth/register', {
            email: email,
            userName: login,
            password: password,
        });
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
}
export { dishesApi, authApi, categoriesAPI, ingredientsAPI };
