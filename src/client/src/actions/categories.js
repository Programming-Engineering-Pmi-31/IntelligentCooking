import axios from 'axios'
export const setCategories = () => dispatch => {
    let response = axios
        .get("https://localhost:5001/api/category")
        .then(res => {dispatch({type: 'SET_CATEGORIES',payload: res.data})})

};
