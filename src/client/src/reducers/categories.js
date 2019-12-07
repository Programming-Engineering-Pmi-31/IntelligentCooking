import { actionTypes } from '../actions/actionTypes';

const initialState = {
    isLoading: true,
    categories: [],
};
export const categories = (state = initialState, action) => {
    switch (action.type) {
        case actionTypes.categoriesTypes.SET_CATEGORIES:
            return {
                ...state,
                categories: action.payload,
                isLoading: false,
            };
        case actionTypes.categoriesTypes.CREATE_CATEGORY:
            return {
                ...state,
                categories: [action.payload, ...state.categories],
            }

        case actionTypes.categoriesTypes.DELETE_CATEGORY:
            return {
                ...state,
                categories: state.categories.filter(item => item.id !== action.payload),
            };
        default:
            return state;
    }
};
