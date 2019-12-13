import axios from 'axios';
import { ingredientsAPI} from '../services/services';
import { actionTypes } from './actionTypes';

export const setIngredients = () => async dispatch => {
    const ingredients = await ingredientsAPI.getIngredients();
    dispatch({ type: actionTypes.ingredientsTypes.SET_INGREDIENTS, payload: ingredients.data });
};
export const createIngredient = name => async dispatch => {
    const formData = new FormData();
    formData.append('Name', name);
    const ingredient = await ingredientsAPI.createIngredient(formData);
    dispatch({ type: actionTypes.ingredientsTypes.CREATE_INGREDIENT, payload: ingredient.data });
};
export const deleteIngredient = (id) => async dispatch => {
    const deleted = await ingredientsAPI.deleteIngredient(id);
    dispatch({ type: actionTypes.ingredientsTypes.DELETE_INGREDIENT, payload: id });
};