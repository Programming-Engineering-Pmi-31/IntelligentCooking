import axios from 'axios';
import { ingredientsAPI } from '../services/services';
import { actionTypes } from './actionTypes';

export const setIngredients = () => async dispatch => {
    const ingredients = await ingredientsAPI.getIngredients();
    dispatch({ type: actionTypes.ingredientsTypes.SET_INGREDIENTS, payload: ingredients.data });
};
