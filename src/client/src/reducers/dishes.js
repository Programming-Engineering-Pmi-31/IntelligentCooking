const initialState = {
    isLoading: false,
    dishes: [],
    noItems: false,
    sortedItem: 'all',
    error: false,
    soloDish: [],
    firstLoad: false,
};
export const dishes = (state = initialState, action) => {
    switch (action.type) {
        case 'ADD_RECIPE':
            return {
                ...state,
                dishes: [...state.dishes, action.payload],
                soloDish: action.payload,
            };
        case 'GET_RECIPE':
            return {
                ...state,
                soloDish: action.payload,
            };
        case 'SET_RECIPES_EMPTY':
            return {
                ...state,
                firstLoad: false,
                dishes: [],
            };
        case 'SET_EXACT_RECIPE_EMPTY':
            return {
                ...state,
                soloDish: [],
            };
        case 'NO_MORE_ITEMS':
            return {
                ...state,
                noItems: true,
            };
        case 'SET_RECIPES_REQUEST':
            return {
                ...state,
                isLoading: true,
            };

        case 'SET_RECIPES_SUCCESS':
            return {
                ...state,
                dishes: [...state.dishes, ...action.payload],
                isLoading: false,
                firstLoad: true,
                noItems: false,
            };
        default:
            return state;
    }
};
