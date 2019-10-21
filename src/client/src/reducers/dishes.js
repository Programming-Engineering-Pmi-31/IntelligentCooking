const initialState = {
    isLoading: false,
    dishes: [],
    noItems: false,
    sortedItem: 'all',
    error: false,
    soloDish: [],
    firstLoad: false,
    skip: 0,
};
export const dishes = (state = initialState, action) => {
    switch (action.type) {
        case 'ADD_RECIPE':
            return {
                ...state,
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
                noItems: false,
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
        case 'SET_RECIPE_SUCCESS':
            return {
                ...state,
                dishes: [...state.dishes, action.payload],
                skip: state.skip + 1,
                noItems: false,
            };
        case 'SET_RECIPES_SUCCESS':
            return {
                ...state,
                dishes: [...state.dishes, ...action.payload],
                isLoading: false,
                firstLoad: true,
                noItems: false,
                skip: state.skip + 8,
            };
        default:
            return state;
    }
};
