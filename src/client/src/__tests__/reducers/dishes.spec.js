import orderBy from 'lodash/orderBy';
import { dishes } from '../../reducers/dishes';

const sortBy = (_dishes, sortedItem) => {
    switch (sortedItem) {
        case 'popular':
            return orderBy(_dishes, 'rating', 'desc');
        case 'lowesttime':
            return orderBy(_dishes, 'time', 'asc');
        case 'lowestcals':
            return orderBy(_dishes, 'calories', 'asc');
        default:
            return _dishes;
    }
};
describe('reducers dishes  ', () => {
    it('SET_RECIPES', () => {
        const initialState = {
            dishes: [],
            isLoading: true,
        };
        const action = {
            type: 'SET_RECIPES',
            payload: [1, 2, 3],
        };
        expect(dishes(initialState, action)).toEqual({
            ...initialState,
            isLoading: false,
            dishes: action.payload,
        });
    });
});
