import React from 'react';
import StarRatings from 'react-star-ratings';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faClock } from '@fortawesome/free-regular-svg-icons';
import PropTypes from 'prop-types';
import Logo from '../img/logo.png';
import styles from '../scss/RecipeCard.scss';

const RecipeCard = React.memo(({ dishes }) => {
    return (
        <div className={styles.form}>
            <div className={styles.recipe__info}>
                <div>
                    <img src={Logo} alt="Recipe" className={styles.recipe__photo} />
                </div>
                <div>
                    <h3 className={styles.recipe__name}>Name</h3>
                    <div className={styles.rating_info}>
                        <span>
                            <StarRatings rating={4.59} starDimension="20px" starSpacing="3px" />
                        </span>
                        <span>54</span>
                        <p>
                            Lorem ipsum dolor sit amet, consectetur adipisicing elit. Error magni
                            natus odio porro? Dolore eius maxime quas quidem soluta voluptatum!
                        </p>
                        <div className={styles.recipe__aditional_info}>
                            <FontAwesomeIcon icon={faClock} className={styles.clock__icon} />
                            <h4>Categories</h4>
                            <ul>
                                <li>
                                    <p>1</p>
                                </li>
                                <li>
                                    <p>2</p>
                                </li>
                                <li>
                                    <p>3</p>
                                </li>
                                <li>
                                    <p>4</p>
                                </li>
                            </ul>
                            <h4>Ingredients</h4>
                            <ul>
                                <li>
                                    <p>1</p>
                                </li>
                                <li>
                                    <p>2</p>
                                </li>
                                <li>
                                    <p>3</p>
                                </li>
                                <li>
                                    <p>4</p>
                                </li>
                                <li>
                                    <p>1</p>
                                </li>
                                <li>
                                    <p>2</p>
                                </li>
                                <li>
                                    <p>3</p>
                                </li>
                                <li>
                                    <p>4</p>
                                </li>
                                <li>
                                    <p>4</p>
                                </li>
                            </ul>
                            <p>Proteins</p>
                            <p>Carbs</p>
                            <p>Fats</p>
                            <p>Calories</p>
                            <p>Servings</p>
                            <p>Time</p>
                        </div>
                    </div>
                </div>
            </div>
            <div className={styles.recipe}>
                Lorem ipsum dolor sit amet, consectetur adipisicing elit. Consequatur corporis
                cupiditate eius id inventore ipsa officiis quaerat reprehenderit! Aliquid at
                deleniti deserunt dicta ducimus esse fuga fugiat fugit iusto, magni maiores
                molestias obcaecati officiis provident quae quia quo repellendus tenetur unde
                veritatis. Debitis eius, enim exercitationem magni sapiente ullam unde?
            </div>
        </div>
    );
});

export default RecipeCard;
