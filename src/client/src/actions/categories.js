import axios from 'axios';
import { categoriesAPI } from '../services/services';

export const setCategories = () => async dispatch => {
    const categories = await categoriesAPI.getCategories();
    dispatch({ type: 'SET_CATEGORIES', payload: categories.data });
};
