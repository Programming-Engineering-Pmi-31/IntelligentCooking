const initialState = {
    sortedItem: 'all'
};
export const sort = (state = initialState, action) => {
    switch (action.type) {
        case 'SORT_BY':
            return {
                ...state,
                sortedItem : action.payload
            }
        default:
            return state;
    }
}