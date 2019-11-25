import React, { useEffect, useState, PureComponent } from 'react';
import Loader from 'react-loader-spinner';
import classNames from 'classnames';
import styles from '../scss/AllRecipes.scss';
import 'react-virtualized/styles.css';
import DishItem from './DishItem';

const AllRecipes = React.memo(
    ({ setRecipes, count , isAscending, sortingCriteria, dishes,setSort, sortBy, isLoading,
                firstLoad, noItems, skip,updateRecipeRequest, deleteRecipe, dishesPages, dishesToLoad,
                isAuth, rateDish, token }) => {
        useEffect(() => {
            if (!firstLoad) {
                setRecipes(0, 8, sortingCriteria, isAscending);
            }
        }, [sortingCriteria, isAscending]);
        useEffect(() => {
            window.onscroll = () => {
                if (
                    !isLoading &&
                    document.documentElement.scrollHeight - 1250 <
                        document.documentElement.scrollTop &&
                    count < 2
                ) {
                    setRecipes(8, 8, sortingCriteria, isAscending);
                }
            };
            return () => {
                window.onscroll = null;
            };
        }, [dishes, skip, count, isLoading, noItems, firstLoad]);
        const handleLoadMore = () => {
            if (count < dishesPages) {
                setRecipes(skip, 8, sortingCriteria, isAscending);
            } else if (count === dishesPages) {
                setRecipes(skip, dishesToLoad, sortingCriteria, isAscending);
            }
        };
        return (
            <div>
                <ul className={styles.filters}>
                    <li>
                        <button type="button" onClick={() => setSort(null, null)}>
                            All recipes
                        </button>
                    </li>
                    <li>
                        <button type="button" onClick={() => sortBy('popular')}>
                            Most Popular
                        </button>
                    </li>
                    <li>
                        <button type="button" onClick={() => setSort('Time', true)}>
                            Lowest Time
                        </button>
                    </li>
                    <li>
                        <button type="button" onClick={() => setSort('Calories', true)}>
                            Lowest Cals
                        </button>
                    </li>
                    <li>
                        <button type="button" onClick={() => setSort('Calories', false)}>
                            Highest Cals
                        </button>
                    </li>
                </ul>
                <ul className={styles.cards}>
                    {dishes.map((item, index) => (
                        <DishItem
                            token={token}
                            rateDish={rateDish}
                            isAuth={isAuth}
                            key={`${item.id}_dish`}
                            item={item}
                            deleteRecipe={deleteRecipe}
                            updateRecipeRequest={updateRecipeRequest}
                        />
                    ))}
                </ul>
                {isLoading ? <LoadingIndicator /> : null}
                {count <= dishesPages && !isLoading ? (
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
