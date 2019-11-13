import React, { useEffect, useState } from 'react';
import StarRatings from 'react-star-ratings';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faClock } from '@fortawesome/free-regular-svg-icons';
import { Link ,withRouter} from 'react-router-dom';

import { faHome } from '@fortawesome/free-solid-svg-icons';
import styles from '../scss/RecipeCard.scss';

const RecipeCard = React.memo(({ getRecipe, match, dishes, setExactRecipeEmpty }) => {
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
    } = dishes.soloDish;
    useEffect(() => {
        console.log('recipe card  did mount');
        if (!dishes.soloDish.length) {
            getRecipe(match.params.id);
        }
        return () => {
            setExactRecipeEmpty();
        };
    }, []);

    console.log('recipe card render');
    return (
        <div>
            {images && (
                <div className={styles.form}>
                    <div className={styles.recipe__info}>
                        <div>
                            <img
                                src={images.filter(e => e.priority === 1)[0].url}
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
                                                    {index+1}. {e.name}{' '}
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
                    <div className={styles.home__btn}>
                        <Link to='/'>
                            <FontAwesomeIcon icon={faHome} />
                        </Link>
                    </div>
                </div>
            )}
        </div>
    );
});

export default withRouter(RecipeCard);
