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
        default:
            return state;
    }
};
