import axios from 'axios'
export const setIngridients = () => dispatch => {
    let response = axios
        .get("/ingridients.json")
        .then(res => {dispatch({type: 'SET_INGRIDIENTS',payload: res.data})})

};
