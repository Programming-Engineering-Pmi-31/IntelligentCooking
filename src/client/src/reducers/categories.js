export const initialState = {
    isLoading: true,
    categories: [],
};
export const categories = (state = initialState, action) => {
    switch (action.type) {
        case 'SET_CATEGORIES':
            return {
                ...state,
                categories: action.payload,
                isLoading: false,
            };
        default:
            return state;
    }
};
