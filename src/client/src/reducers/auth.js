export const initialState = {
    isAuth: false,
    email: '',
    unique_name: '',
    role: '',
    token: '',
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
        case 'LOGOUT_API':
            return {
                ...state,
                isAuth: false,
                email: '',
                unique_name: '',
                role: '',
            }
        case 'SET_TOKEN':
            return{
                ...state,
                token: action.payload,
            }
        default:
            return state;
    }
};
