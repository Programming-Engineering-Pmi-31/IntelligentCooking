import { actionTypes } from './actionTypes';

export const sortBy = sort => ({
    type: actionTypes.sortTypes.SORT_BY,
    payload: sort,
});
