const initialState = {
    isLoading: false,
    dishes: [],
    sortedItem: 'all',
    error: false,
};
export const dishes = (state = initialState, action) => {
    switch (action.type) {
        case 'ADD_RECIPE':
            return {
                ...state,
                dishes: [...state.dishes, action.payload],
            };
        case 'GET_RECIPE':
            return {
                ...state,
                dishes: action.payload,
                isLoading: true,
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
            };
        default:
            return state;
    }
};
