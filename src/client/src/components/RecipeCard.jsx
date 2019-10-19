import React, { useEffect, useState } from 'react';
import StarRatings from 'react-star-ratings';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faClock } from '@fortawesome/free-regular-svg-icons';
import styles from '../scss/RecipeCard.scss';

const RecipeCard = React.memo(({ getRecipe, match, dishes }) => {
    const {
        name,
        recipe,
        rating,
        likes,
        proteins,
        servings,
        calories,
        carbohydrates,
        fats,
        ingredients,
        time,
        description,
        categories,
        images,
    } = dishes.dishes;
    useEffect(() => {
        getRecipe(match.params.id);
    }, [getRecipe, match.params.id]);
    if (dishes.dishes.images) {
        console.log(dishes.dishes);
    }

    return (
        <div>
            {images && (
                <div className={styles.form}>
                    <div className={styles.recipe__info}>
                        <div>
                            <img
                                src={images[0].url}
                                alt="Recipe"
                                className={styles.recipe__photo}
                            />
                        </div>
                        <div>
                            <h3 className={styles.recipe__name}>{name}</h3>
                            <div className={styles.rating__info}>
                                <span>
                                    <StarRatings
                                        changeRating={e => console.log(e)}
                                        starRatedColor="rgb(230, 67, 47)"
                                        starHoverColor="rgb(0,0,200)"
                                        rating={rating}
                                        starDimension="20px"
                                        starSpacing="3px"
                                    />
                                </span>
                                <span>&nbsp; {likes}</span>
                                <p>{description}</p>
                                <div className={styles.recipe__aditional_info}>
                                    <FontAwesomeIcon
                                        icon={faClock}
                                        className={styles.clock__icon}
                                    />
                                    <h4>Categories</h4>
                                    <ul>
                                        {categories.map(e => (
                                            <li key={e.id}>
                                                <p>{e.name}</p>
                                            </li>
                                        ))}
                                    </ul>
                                    <h4>Ingredients</h4>
                                    <ul>
                                        {ingredients.map((e, index) => (
                                            <li key={e.id}>
                                                <p>
                                                    {' '}
                                                    {index}. {e.name}{' '}
                                                </p>
                                            </li>
                                        ))}
                                    </ul>
                                    <p>Proteins : {proteins}</p>
                                    <p>Carbs : {carbohydrates}</p>
                                    <p>Fats : {fats}</p>
                                    <p>Calories: {calories}</p>
                                    <p>Servings: {servings}</p>
                                    <p>Time: {time}</p>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div className={styles.recipe}>{recipe}</div>
                </div>
            )}
        </div>
    );
});

export default RecipeCard;
