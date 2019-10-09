import axios from 'axios'
import { trackPromise } from 'react-promise-tracker';

export const setRecipes = () => dispatch => {
    trackPromise( axios
        .get("https://localhost:44335/api/Dish")
        .then(res => {dispatch({type: 'SET_RECIPES',payload: res.data})}))
};