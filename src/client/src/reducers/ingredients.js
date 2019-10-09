const initialState = {
    ingredients: []
};
export const ingredients = (state = initialState, action) => {
    switch (action.type) {
        case "SET_INGREDIENTS":
            return{
                ...state,
                ingredients: action.payload
            }

        default:
            return state;
    }
}