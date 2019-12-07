import axios from 'axios';
import { categoriesAPI, ingredientsAPI } from '../services/services';
import { actionTypes } from './actionTypes';

export const setCategories = () => async dispatch => {
    const categories = await categoriesAPI.getCategories();
    dispatch({ type: 'SET_CATEGORIES', payload: categories.data });
};
export const createCategory = ({ name, image }) => async dispatch => {
    const formData = new FormData();
    formData.append('Name', name);
    formData.append('Image', image);
    const category = await categoriesAPI.createCategory(formData);
    dispatch({ type: actionTypes.categoriesTypes.CREATE_CATEGORY, payload: category.data });
};
export const deleteCategory = id => async dispatch => {
    const deleted = await categoriesAPI.deleteCategory(id);
    dispatch({ type: actionTypes.categoriesTypes.DELETE_CATEGORY, payload: id });
};
