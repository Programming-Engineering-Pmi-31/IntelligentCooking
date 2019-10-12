const initialState = {
    ingredients: [],
    isLoading: true,
};
export const ingredients = (state = initialState, action) => {
    switch (action.type) {
        case 'SET_INGREDIENTS':
            return {
                ...state,
                ingredients: action.payload,
                isLoading: false,
            };

        default:
            return state;
    }
};
