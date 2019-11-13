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
    it('SET_RECIPES_SUCCESS', () => {
        const initialState = {
            isLoading: false,
            dishes: [],
            noItems: false,
            sortedItem: 'all',
            error: false,
            soloDish: [],
            firstLoad: false,
            skip: 0,
        };
        const action = {
            type: 'SET_RECIPES_SUCCESS',
            payload: [1, 2, 3],
        };
        expect(dishes(initialState, action)).toEqual({
            ...initialState,
            dishes: [...initialState.dishes, ...action.payload],
            isLoading: false,
            firstLoad: true,
            noItems: false,
            skip: initialState.skip + 8,
        });
    });
});
