import axios from 'axios';

export const registrateNewUserAPI = userInfo => dispatch => {
    // dispatch({ type: 'SET_SORT', payload: { criteria: criteria, order: order}});
    axios.post('https://localhost:44335/api/Auth/register', {
        email: userInfo.email,
        userName: userInfo.login,
        password: userInfo.password,
    });
};
