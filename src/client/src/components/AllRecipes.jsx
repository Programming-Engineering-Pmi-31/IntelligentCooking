import React from 'react';
import { Link } from 'react-router-dom';
import StarRatings from 'react-star-ratings';
import Loader from 'react-loader-spinner';
import { usePromiseTracker } from 'react-promise-tracker';
import styles from '../scss/AllRecipes.scss';

const AllRecipes = React.memo(({ dishes, sortBy }) => {
    const { promiseInProgress } = usePromiseTracker();
    console.log(promiseInProgress);
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
            {promiseInProgress === true ? (
                <LoadingIndicator />
            ) : (
                <ul className={styles.cards}>
                    {dishes.map((item, index) => (
                        <Link key={item.id} to={`recipe/${index}`}>
                            <li className={styles.cards__item}>
                                <div className={styles.card}>
                                    <div className={styles.image__container}>
                                        <img
                                            className={styles.card__image}
                                            src={item.imageUrl}
                                            alt={item.name}
                                        />
                                    </div>
                                    <div className={styles.card__content}>
                                        <div className={styles.card__title}>{item.name}</div>
                                        <div className={styles.rating__info}>
                                            <span>
                                                <StarRatings
                                                    rating={item.rating}
                                                    starDimension="20px"
                                                    starSpacing="3px"
                                                />
                                            </span>
                                            <span>{item.likes}</span>
                                        </div>
                                        <div className={styles.card__aditional}>
                                            <span>
                                                proteins:
                                                {item.proteins}
                                            </span>
                                            <span>
                                                carbs:
                                                {item.carbohydrates}
                                            </span>
                                            <span>
                                                fats:
                                                {item.fats}
                                            </span>
                                            <span>
                                                cals:
                                                {item.calories}
                                            </span>
                                            <span>
                                                servings:
                                                {item.servings}
                                            </span>
                                            <span>
                                                time:
                                                {item.time}
                                            </span>
                                        </div>
                                    </div>
                                </div>
                            </li>
                        </Link>
                    ))}
                </ul>
            )}
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
