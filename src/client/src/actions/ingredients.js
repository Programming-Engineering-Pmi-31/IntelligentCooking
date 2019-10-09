import axios from 'axios'
export const setIngredients = () => dispatch => {
    let response = axios
        .get("https://localhost:44335/api/ingredient")
        .then(res => {dispatch({type: 'SET_INGREDIENTS',payload: res.data})})

};
