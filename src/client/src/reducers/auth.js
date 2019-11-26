import { actionTypes } from '../actions/actionTypes';

const initialState = {
    isAuth: false,
    email: '',
    unique_name: '',
    role: '',
    token: '',
};
export const auth = (state = initialState, action) => {
    switch (action.type) {
        case actionTypes.authTypes.LOGIN_API:
            return {
                ...state,
                email: action.payload.email,
                unique_name: action.payload.unique_name,
                role: action.payload.role,
                isAuth: true,
            };
        case actionTypes.authTypes.LOGOUT_API:
            return {
                ...state,
                isAuth: false,
                email: '',
                unique_name: '',
                role: '',
            };
        case actionTypes.authTypes.SET_TOKEN:
            return {
                ...state,
                token: action.payload,
            };
        default:
            return state;
    }
};
