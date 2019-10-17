const initialState = {
    isLoading: false,
    dishes: [],
    sortedItem: 'all',
};
export const dishes = (state = initialState, action) => {
    switch (action.type) {
        case 'ADD_RECIPE':
            return {
                ...state,
                dishes: [...state.dishes, action.payload],
            };

        case 'SET_RECIPES':
            return {
                ...state,
                dishes: [...state.dishes, ...action.payload],
                isLoading: true,
            };
        default:
            return state;
    }
};
