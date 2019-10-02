import React from 'react';
import styles from "../scss/AllRecipes.scss"
import StarRatings from 'react-star-ratings';

const AllRecipes = React.memo(({dishes,sortBy}) => {
    console.log(dishes);
    return(

        <div>
            <ul className={styles.filters}>
                <li><button onClick={()=>sortBy('all')}>All recipes</button> </li>
                <li><button onClick={()=>sortBy('popular')}>Most Popular</button></li>
                <li><button onClick={()=>sortBy('lowesttime')}>Lowest Time</button></li>
                <li><button onClick={()=>sortBy('lowestcals')}>Lowest cals</button></li></ul>
            <ul className={styles.cards}>
                {dishes.map(item => (
                    <li key={item.id} className={styles.cards__item}>
                        <div className={styles.card}>
                            <div className={styles.card__image}>
                                <img src={item.img} alt={item.title}/>
                            </div>
                            <div className={styles.card__content}>
                                <div className={styles.card__title}>{item.title}</div>
                                <div className={styles.rating__info}>
                                    <span>
                                    <StarRatings
                                        rating={item.rating}
                                        starDimension="20px"
                                        starSpacing="3px"/>
                                </span>
                                    <span>{item.likes}</span>
                                    <span>{item.cals}</span>
                                    <span>{item.time}</span>
                                </div>


                            </div>
                        </div>
                    </li>
                ))}

            </ul>
        </div>
    )
});
export default AllRecipes;