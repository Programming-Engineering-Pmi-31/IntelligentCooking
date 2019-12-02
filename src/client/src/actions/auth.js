import axios from 'axios';
import jwt_decode from 'jwt-decode';
import { authApi } from '../services/services';
import { actionTypes } from './actionTypes';

export const registrateNewUserAPI = ({ email, login, password }) => async dispatch => {
    try{
        dispatch({ type: actionTypes.authTypes.REGISTER_API_REQUEST });
        const user = await authApi.registrateNewUser(email, login, password);
        dispatch({ type: actionTypes.authTypes.REGISTER_API_SUCCESS});
        return user;
    } catch{
        dispatch({ type: actionTypes.authTypes.REGISTER_API_ERROR });
    }
};
export const authorizeWithStorage = () => dispatch => {
    const token = localStorage.getItem('token');
    const refreshToken = localStorage.getItem('refreshToken');
    const user = jwt_decode(token);
    dispatch({ type: actionTypes.authTypes.SET_TOKEN, payload: token });
    dispatch({ type: actionTypes.authTypes.LOGIN_API_SUCCESS, payload: user });
};
export const Logout = () => dispatch => {
    localStorage.removeItem('token');
    localStorage.removeItem('refreshToken');
    dispatch({ type: actionTypes.authTypes.LOGOUT_API });
};
export const loginUserAPI = ({ email, password }) => async dispatch => {
    try {
        dispatch({ type: actionTypes.authTypes.LOGIN_API_REQUEST });
        const authorizedUser = await authApi.loginUser(email, password);
        localStorage.setItem('refreshToken', authorizedUser.data.refreshToken);
        localStorage.setItem('token', authorizedUser.data.token);
        const user = jwt_decode(authorizedUser.data.token);
        dispatch({ type: actionTypes.authTypes.SET_TOKEN, payload: authorizedUser.data.token });
        dispatch({ type: actionTypes.authTypes.LOGIN_API_SUCCESS, payload: user });
        console.log(authorizedUser);
        return authorizedUser;
    } catch (e) {
        dispatch({ type: actionTypes.authTypes.LOGIN_API_ERROR });
    }
};
