const initialState = {
    isLoading: true,
    dishes: [],
    sortedItem: 'all',
};
export const dishes = (state = initialState, action) => {
    switch (action.type) {
        case 'ADD_RECIPE':
            return {};

        case 'SET_RECIPES':
            return {
                ...state,
                dishes: action.payload,
                isLoading: false,
            };
        default:
            return state;
    }
};
