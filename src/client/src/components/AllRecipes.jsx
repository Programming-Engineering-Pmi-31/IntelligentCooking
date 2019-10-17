import React, { useEffect, useState } from 'react';
import Loader from 'react-loader-spinner';
import { debounce } from 'lodash';
import { usePromiseTracker } from 'react-promise-tracker';
import styles from '../scss/AllRecipes.scss';
import 'react-virtualized/styles.css';
import { DishItem } from './DishItem';

const AllRecipes = React.memo(({ setRecipes, dishes, sortBy }) => {
    const { promiseInProgress } = usePromiseTracker();
    const [skip, setSkip] = useState(6);
    useEffect(() => {
        window.onscroll = debounce(() => {
            if (document.documentElement.scrollHeight - 6000 < document.documentElement.scrollTop) {
                setRecipes(skip, 8);
                setSkip(skip + 8);
            }
        }, 30);
    }, [setRecipes, skip]);

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
            {/* {promiseInProgress === true ? ( */}
            {/*    <LoadingIndicator /> */}
            {/* ) : ( */}
            <ul className={styles.cards}>
                {dishes.map((item, index) => (
                    <DishItem key={index} item={item} />
                ))}
            </ul>
            {/* )} */}
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
