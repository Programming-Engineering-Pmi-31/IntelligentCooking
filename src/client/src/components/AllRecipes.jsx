import React, { useEffect, useState, useRef } from 'react';
import Loader from 'react-loader-spinner';
import { debounce } from 'lodash';
import { usePromiseTracker } from 'react-promise-tracker';
import styles from '../scss/AllRecipes.scss';
import 'react-virtualized/styles.css';
import { DishItem } from './DishItem';

const AllRecipes = React.memo(({ setRecipes, dishes, sortBy, isLoading }) => {
    const { promiseInProgress } = usePromiseTracker();
    const [skip, setSkip] = useState(0);
    const load = 8;
    const [count, setCount] = useState(0);
    console.log(isLoading);
    useEffect(() => {
        setRecipes(skip, load);
        setSkip(skip + load);
    }, []);
    useEffect(() => {
        window.onscroll = () => {
            if (
                !isLoading &&
                document.documentElement.scrollHeight - 1250 < document.documentElement.scrollTop &&
                count < 2
            ) {
                setCount(count + 1);
                setRecipes(skip, 4);
                setSkip(skip + 4);
            }
        };
        return () => {
            window.onscroll = null;
        };
    }, [dishes, skip, count, isLoading]);
    const handleLoadMore = () => {
        setSkip(skip + load);
        setRecipes(skip, load);
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
                    <DishItem key={index} item={item} />
                ))}
            </ul>
            {isLoading ? <LoadingIndicator /> : null}
            {count === 2 && !isLoading ? (
                <button className={styles.loadMore} onClick={handleLoadMore}>
                    Load More
                </button>
            ) : null}
        </div>
    );
});
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
