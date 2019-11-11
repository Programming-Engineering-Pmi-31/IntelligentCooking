export const initialState = {
    isAuth: false,
    email: '',
    unique_name: '',
    role: '',
};
export const auth = (state = initialState, action) => {
    switch (action.type) {
        case 'LOGIN_API':
            return {
                ...state,
                email: action.payload.email,
                unique_name: action.payload.unique_name,
                role: action.payload.role,
                isAuth: true,
            };
        default:
            return state;
    }
};
