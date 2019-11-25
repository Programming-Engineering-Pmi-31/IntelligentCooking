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
        case 'UPDATE_RECIPE_REQUEST':
            return {
                ...state,
                isEditing: true,
            };
        case 'UPDATE_RECIPE_FINISH':
            return {
                ...state,
                isEditing: false,
            };
        case 'DELETE_RECIPE':
            return {
                ...state,
                skip: state.skip - 1,
                dishesCount: state.dishesCount - 1,
                dishes: state.dishes.filter(item => item.id !== action.payload),
            };
        case 'UPDATE_RECIPE_SUCCESS':
            return {
                ...state,
                isEditing: false,
            };
        case 'NO_MORE_ITEMS':
            return {
                ...state,
                noItems: true,
            };
        case 'SET_SORT':
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
        case 'SET_RECIPES_REQUEST':
            return {
                ...state,
                isLoading: true,
            };
        case 'SET_DISHES_BY_FILTER':
            return{
                ...state,
                dishes: action.payload,
            }
        case 'SET_RECIPE_SUCCESS':
            return {
                ...state,
                dishes: [...state.dishes, ...action.payload.dishes],
                isLoading: false,
                dishesCount: state.dishesCount + 1,
                skip: state.skip + 1,
                noItems: false,
            };
        case 'SET_RECIPES_SUCCESS':
            return {
                ...state,
                dishes: [...state.dishes, ...action.payload.dishes],
                isLoading: false,
                firstLoad: true,
                noItems: false,
                skip: state.skip + action.payload.load,
                count: state.count + 1,
            };
        case 'SET_DISHES_COUNT':
            return {
                ...state,
                dishesCount: action.payload,
                dishesPages: Math.floor(action.payload / 8),
                dishesToLoad: action.payload % 8,
            };
        case 'RATE_DISH':
            return{

            }
        default:
            return state;
    }
};
