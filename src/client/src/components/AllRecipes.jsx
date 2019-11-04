import React, { useEffect, useState, PureComponent } from 'react';
import Loader from 'react-loader-spinner';
import classNames from 'classnames';
import styles from '../scss/AllRecipes.scss';
import 'react-virtualized/styles.css';
import DishItem from './DishItem';

const AllRecipes = React.memo(
    ({ setRecipes, setRecipesEmpty, dishes, sortBy, isLoading, firstLoad, noItems, skip,updateRecipeRequest}) => {
        const load = 8;
        const [count, setCount] = useState(0);
        useEffect(() => {
            setRecipes(skip, load);
        }, []);
        useEffect(() => {
            window.onscroll = () => {
                if (
                    !isLoading &&
                    document.documentElement.scrollHeight - 1250 <
                        document.documentElement.scrollTop &&
                    count < 1
                ) {
                    setCount(count + 1);
                    setRecipes(skip, 8);
                }
            };
            return () => {
                window.onscroll = null;
            };
        }, [dishes, skip, count, isLoading, noItems, firstLoad ]);
        const handleLoadMore = () => {
            setRecipes(skip, 8);
        };
        return (
            <div>
                <ul className={styles.filters}>
                    <li>
                        <button type="button" onClick={() => sortBy('all')}>
                            All recipes
                        </button>
                    </li>
                    <li>
                        <button type="button" onClick={() => sortBy('popular')}>
                            Most Popular
                        </button>
                    </li>
                    <li>
                        <button type="button" onClick={() => sortBy('lowesttime')}>
                            Lowest Time
                        </button>
                    </li>
                    <li>
                        <button type="button" onClick={() => sortBy('lowestcals')}>
                            Lowest cals
                        </button>
                    </li>
                </ul>
                <ul className={styles.cards}>
                    {dishes.map((item, index) => (
                        <DishItem key={`${item.id}_dish`} item={item} updateRecipeRequest={updateRecipeRequest} />
                    ))}
                </ul>
                {isLoading ? <LoadingIndicator /> : null}
                {count === 1 && !isLoading ? (
                    <LoadMore handler={handleLoadMore} noItems={noItems} />
                ) : null}
            </div>
        );
    },
);
class LoadMore extends PureComponent {
    render() {
        const { noItems, handler } = this.props;
        const buttonClass = classNames({
            [styles.loadMore]: true,
            [styles.unvisible]: noItems,
        });
        return (
            <button className={buttonClass} onClick={handler}>
                Load More
            </button>
        );
    }
}
const LoadingIndicator = () => {
    return (
        <div
            style={{
                width: '100%',
                height: '100',
                display: 'flex',
                justifyContent: 'center',
                alignItems: 'center',
            }}
        >
            <Loader type="ThreeDots" color="#2BAD60" height={100} width={100} />
        </div>
    );
};
export default AllRecipes;
