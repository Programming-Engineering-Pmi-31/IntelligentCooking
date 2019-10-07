const initialState = {
    ingridients: []
};
export const ingridients = (state = initialState, action) => {
    switch (action.type) {
        case "SET_INGRIDIENTS":
            return{
                ...state,
                ingridients: action.payload
            }

        default:
            return state;
    }
}