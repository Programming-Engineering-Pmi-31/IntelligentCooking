import { actionTypes } from '../actions/actionTypes';

const initialState = {
    sortedItem: 'all',
};
export const sort = (state = initialState, action) => {
    switch (action.type) {
        case actionTypes.sortTypes.SORT_BY:
            return {
                ...state,
                sortedItem: action.payload,
            };
        default:
            return state;
    }
};
