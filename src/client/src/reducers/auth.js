import { actionTypes } from '../actions/actionTypes';

const initialState = {
    isAuth: false,
    email: '',
    unique_name: '',
    role: '',
    token: '',
    isProccesing: false,
};
export const auth = (state = initialState, action) => {
    switch (action.type) {
        case actionTypes.authTypes.REGISTER_API_REQUEST:
            return {
                ...state,
                isProccesing: true,
            };
        case actionTypes.authTypes.REGISTER_API_SUCCESS:
            return {
                ...state,
                isProccesing: false,
            };
        case actionTypes.authTypes.REGISTER_API_ERROR:
            return {
                ...state,
                isProccesing: false,
            };
        case actionTypes.authTypes.LOGIN_API_REQUEST:
            return {
                ...state,
                isProccesing: true,
            };
        case actionTypes.authTypes.LOGIN_API_ERROR:
            return {
                ...state,
                isProccesing: false,
            };
        case actionTypes.authTypes.LOGIN_API_SUCCESS:
            return {
                ...state,
                email: action.payload.email,
                unique_name: action.payload.unique_name,
                role: action.payload.role,
                isAuth: true,
                isProccesing: false,
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
