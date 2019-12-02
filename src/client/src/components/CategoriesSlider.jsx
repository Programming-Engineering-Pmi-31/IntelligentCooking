import React, { PureComponent } from 'react';
import { Link } from 'react-router-dom';
import Slider from 'react-slick';
import styles from '../scss/CategoriesSlider.scss';

class CategoriesSlider extends PureComponent {
    render() {
        const settings = {
            infinite: true,
            speed: 500,
            slidesToShow: 6,
            slidesToScroll: 1,
        };
        const { categories,getDishesByCategory} = this.props;
        const categoriesItems = [];
        categories.forEach((item, index) => {
            categoriesItems.push(
                <div className={styles.categories__slider} key={categories[index].id}>
                    <button className={styles.category_btn} onClick={(e) => getDishesByCategory(item.id)}>
                        <img src={categories[index].imageUrl} alt="" />
                        <p>{categories[index].name}</p>
                    </button>
                </div>,
            );
        });
        return (
            <div>
                <Slider {...settings}>{categoriesItems}</Slider>
            </div>
        );
    }
}
export default CategoriesSlider;
