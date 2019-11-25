import axios from 'axios';
import jwt_decode from 'jwt-decode';

export const registrateNewUserAPI = userInfo => dispatch => {
    axios.post('https://intelligentcookingweb.azurewebsites.net/api/Auth/register', {
        email: userInfo.email,
        userName: userInfo.login,
        password: userInfo.password,
    });
};
export const authorizeWithStorage = () => dispatch => {
    const token = localStorage.getItem('token');
    const refreshToken = localStorage.getItem('refreshToken');
    const user = jwt_decode(token);
    dispatch({ type: 'SET_TOKEN', payload: token });
    dispatch({ type: 'LOGIN_API', payload: user });
};
export const Logout = () => dispatch => {
    localStorage.removeItem('token');
    localStorage.removeItem('refreshToken');
    dispatch({ type: 'LOGOUT_API' });
};
export const loginUserAPI = userInfo => dispatch => {
    axios
        .post('https://intelligentcookingweb.azurewebsites.net/api/Auth/login', {
            email: userInfo.email,
            password: userInfo.password,
        })
        .then(res => {
            localStorage.setItem('refreshToken', res.data.refreshToken);
            localStorage.setItem('token', res.data.token);
            const user = jwt_decode(res.data.token);
            dispatch({ type: 'SET_TOKEN', payload: res.data.token });
            dispatch({ type: 'LOGIN_API', payload: user });
        });
};
