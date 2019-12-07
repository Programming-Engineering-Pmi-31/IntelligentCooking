import { actionTypes } from '../actions/actionTypes';

const initialState = {
    ingredients: [],
    isLoading: true,
};
export const ingredients = (state = initialState, action) => {
    switch (action.type) {
        case actionTypes.ingredientsTypes.SET_INGREDIENTS:
            return {
                ...state,
                ingredients: action.payload,
                isLoading: false,
            };
        case actionTypes.ingredientsTypes.CREATE_INGREDIENT:
            return {
                ...state,
                ingredients: [action.payload, ...state.ingredients],
            }

        case actionTypes.ingredientsTypes.DELETE_INGREDIENT:
            return {
                ...state,
                ingredients: state.ingredients.filter(item => item.id !== action.payload),
            };
        default:
            return state;
    }
};
