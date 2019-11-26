import { actionTypes } from '../actions/actionTypes';

const initialState = {
    sortingCriteria: null,
    isAscending: null,
    isLoading: false,
    isEditing: false,
    dishes: [],
    noItems: false,
    sortedItem: 'all',
    error: false,
    soloDish: [],
    firstLoad: false,
    skip: 0,
    count: 0,
    dishesCount: 0,
    dishesPages: 0,
    dishesToLoad: 0,
};
export const dishes = (state = initialState, action) => {
    switch (action.type) {
        case actionTypes.dishesTypes.ADD_RECIPE:
            return {
                ...state,
                soloDish: action.payload,
            };
        case actionTypes.dishesTypes.GET_RECIPE:
            return {
                ...state,
                soloDish: action.payload,
            };
        case actionTypes.dishesTypes.SET_RECIPES_EMPTY:
            return {
                ...state,
                firstLoad: false,
                dishes: [],
            };
        case actionTypes.dishesTypes.SET_EXACT_RECIPE_EMPTY:
            return {
                ...state,
                soloDish: [],
                noItems: false,
            };
        case actionTypes.dishesTypes.UPDATE_RECIPE_REQUEST:
            return {
                ...state,
                isEditing: true,
            };
        case actionTypes.dishesTypes.UPDATE_RECIPE_FINISH:
            return {
                ...state,
                isEditing: false,
            };
        case actionTypes.dishesTypes.DELETE_RECIPE:
            return {
                ...state,
                skip: state.skip - 1,
                dishesCount: state.dishesCount - 1,
                dishes: state.dishes.filter(item => item.id !== action.payload),
            };
        case actionTypes.dishesTypes.UPDATE_RECIPE_SUCCESS:
            return {
                ...state,
                isEditing: false,
            };
        case actionTypes.dishesTypes.NO_MORE_ITEMS:
            return {
                ...state,
                noItems: true,
            };
        case actionTypes.dishesTypes.SET_SORT:
            return {
                ...state,
                dishes: [],
                firstLoad: false,
                skip: 0,
                count: 0,
                isLoading: false,
                noItems: false,
                sortingCriteria: action.payload.criteria,
                isAscending: action.payload.order,
            };
        case actionTypes.dishesTypes.SET_RECIPES_REQUEST:
            return {
                ...state,
                isLoading: true,
            };
        case actionTypes.dishesTypes.SET_DISHES_BY_FILTER:
            return {
                ...state,
                dishes: action.payload,
            };
        case actionTypes.dishesTypes.SET_RECIPE_SUCCESS:
            return {
                ...state,
                dishes: [...state.dishes, ...action.payload.dishes],
                isLoading: false,
                dishesCount: state.dishesCount + 1,
                skip: state.skip + 1,
                noItems: false,
            };
        case actionTypes.dishesTypes.SET_RECIPES_SUCCESS:
            return {
                ...state,
                dishes: [...state.dishes, ...action.payload.dishes],
                isLoading: false,
                firstLoad: true,
                noItems: false,
                skip: state.skip + action.payload.load,
                count: state.count + 1,
            };
        case actionTypes.dishesTypes.SET_DISHES_COUNT:
            return {
                ...state,
                dishesCount: action.payload,
                dishesPages: Math.floor(action.payload / 8),
                dishesToLoad: action.payload % 8,
            };
        case actionTypes.dishesTypes.RATE_DISH:
            return {};
        default:
            return state;
    }
};
