import React, { PureComponent } from 'react';
import { Link, withRouter } from 'react-router-dom';
import { faEdit, faTimes, faHeart} from '@fortawesome/free-solid-svg-icons';
import {} from '@fortawesome/free-regular-svg-icons';
import StarRatings from 'react-star-ratings';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import styles from '../scss/AllRecipes.scss';

class DishItem extends PureComponent {
    render() {
        const { item, updateRecipeRequest, deleteRecipe, isAuth, rateDish, token, likeDish } = this.props;
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
                                <span onClick={e => e.preventDefault()}>
                                    <StarRatings
                                        changeRating={e => {
                                            if (!isAuth) {
                                                alert('You are not authorized !');
                                            } else {
                                                rateDish({ id: item.id, rating: e});
                                            }
                                            console.log({ id: item.id, rating: e });
                                        }}
                                        starRatedColor="rgb(230, 67, 47)"
                                        starHoverColor="rgb(0,0,200)"
                                        rating={item.rating}
                                        starDimension="20px"
                                        starSpacing="3px"
                                    />
                                </span>
                                <span>{item.ratesCount}</span>
                                {isAuth && <button className={styles.heart__btn} onClick={(e)=>{
                                    e.preventDefault();
                                    likeDish(item.id);
                                }}><FontAwesomeIcon icon={faHeart}/></button>}


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
                        {isAuth && (
                            <div className={styles.editPanel}>
                                <button
                                    onClick={e => {
                                        e.preventDefault();
                                        updateRecipeRequest();
                                        this.props.history.push(`/recipe/${item.id}/edit`);
                                    }}
                                >
                                    <FontAwesomeIcon icon={faEdit} />
                                </button>
                                <button
                                    onClick={e => {
                                        e.preventDefault();
                                        const toDelete = confirm(`Detete item ${item.name}?`);
                                        if (toDelete) {
                                            deleteRecipe(item.id);
                                        } else {
                                            alert('ok');
                                        }
                                    }}
                                >
                                    <FontAwesomeIcon icon={faTimes} />
                                </button>
                            </div>
                        )}
                    </div>
                </Link>
            </li>
        );
    }
}
export default withRouter(DishItem);
