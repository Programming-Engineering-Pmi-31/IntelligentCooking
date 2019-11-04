import React, { PureComponent } from 'react';
import { Link, withRouter} from 'react-router-dom';
import { faEdit, faTimes } from '@fortawesome/free-solid-svg-icons';
import StarRatings from 'react-star-ratings';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import styles from '../scss/AllRecipes.scss';

class DishItem extends PureComponent {
    render() {
        const { item, updateRecipeRequest } = this.props;
        return (
            <li key={item.id} className={styles.cards__item}>
                <Link to={`/recipe/${item.id}`}>
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
                                        changeRating={e => console.log(e)}
                                        starRatedColor="rgb(230, 67, 47)"
                                        starHoverColor="rgb(0,0,200)"
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
                        <div className={styles.editPanel}>
                            <button onClick={(e) => {e.preventDefault(); updateRecipeRequest();
                            this.props.history.push(`/recipe/${item.id}/edit`); }}>
                                <FontAwesomeIcon icon={faEdit} />
                            </button>
                            <button onClick={(e) => {e.preventDefault(); alert(3)}}>
                                <FontAwesomeIcon icon={faTimes} />
                            </button>
                        </div>
                    </div>
                </Link>
            </li>
        );
    }
}
export default withRouter(DishItem);
