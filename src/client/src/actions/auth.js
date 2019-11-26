import axios from 'axios';
import jwt_decode from 'jwt-decode';
import { authApi } from '../services/services';
import { actionTypes } from './actionTypes';

export const registrateNewUserAPI = ({ email, login, password }) => async dispatch => {
    await authApi.registrateNewUser(email, login, password);
};
export const authorizeWithStorage = () => dispatch => {
    const token = localStorage.getItem('token');
    const refreshToken = localStorage.getItem('refreshToken');
    const user = jwt_decode(token);
    dispatch({ type: actionTypes.authTypes.SET_TOKEN, payload: token });
    dispatch({ type: actionTypes.authTypes.LOGIN_API, payload: user });
};
export const Logout = () => dispatch => {
    localStorage.removeItem('token');
    localStorage.removeItem('refreshToken');
    dispatch({ type: actionTypes.authTypes.LOGOUT_API });
};
export const loginUserAPI = ({ email, password }) => async dispatch => {
    const authorizedUser = await authApi.loginUser(email, password);
    localStorage.setItem('refreshToken', authorizedUser.data.refreshToken);
    localStorage.setItem('token', authorizedUser.data.token);
    const user = jwt_decode(authorizedUser.data.token);
    dispatch({ type: actionTypes.authTypes.SET_TOKEN, payload: authorizedUser.data.token });
    dispatch({ type: actionTypes.authTypes.LOGIN_API, payload: user });
};
