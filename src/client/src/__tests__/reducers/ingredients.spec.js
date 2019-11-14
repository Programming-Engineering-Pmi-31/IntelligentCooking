import { ingredients } from '../../reducers/ingredients';

describe('reducers ingredients  ', () => {
    it('SET_INGREDIENTS', () => {
        const initialState = {
            ingredients: [],
            isLoading: true,
        };
        const action = {
            type: 'SET_INGREDIENTS',
            payload: [1, 2, 3],
        };
        expect(ingredients(initialState, action)).toEqual({
            ...initialState,
            isLoading: false,
            ingredients: action.payload,
        });
    });
});
