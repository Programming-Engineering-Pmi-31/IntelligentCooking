import { categories } from '../../reducers/categories';

describe('reducers categories  ', () => {
    it('SET_CATEGORIES', () => {
        const initialState = {
            categories: [],
            isLoading: true,
        };
        const action = {
            type: 'SET_CATEGORIES',
            payload: [1, 2, 3],
        };
        expect(categories(initialState, action)).toEqual({
            ...initialState,
            isLoading: false,
            categories: action.payload,
        });
    });
});
