import axios from 'axios'
export const setIngridients = () => dispatch => {
    let response = axios
        .get("https://localhost:5001/api/ingredient")
        .then(res => {dispatch({type: 'SET_INGRIDIENTS',payload: res.data})})

};
