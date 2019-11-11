import axios from 'axios';
import jwt_decode from 'jwt-decode';

export const registrateNewUserAPI = userInfo => dispatch => {
    axios.post('https://intelligentcookingweb.azurewebsites.net/api/Auth/register', {
        email: userInfo.email,
        userName: userInfo.login,
        password: userInfo.password,
    });
};
export const loginUserAPI = userInfo => dispatch => {
    axios
        .post('https://intelligentcookingweb.azurewebsites.net/api/Auth/login', {
            email: userInfo.email,
            password: userInfo.password,
        })
        .then(res => {
            const user = jwt_decode(res.data.token);
            dispatch({ type: 'LOGIN_API', payload: user });
        });
};
