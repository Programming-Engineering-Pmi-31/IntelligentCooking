import React, { PureComponent } from 'react';
import axios from 'axios'
import styles from "../scss/CategoriesSlider.scss"
import Slider from "react-slick";

class CategoriesSlider extends PureComponent  {
    componentDidMount() {
        const { setCategories } = this.props;
        setCategories();

    }
    render() {
        const settings = {
            infinite: true,
            speed: 500,
            slidesToShow: 6,
            slidesToScroll: 1
        };
        let {categories} = this.props;
        let categoriesItems = [];
        categories.forEach((item,index) => {
            categoriesItems.push(<div className={styles.categories__slider} key={categories[index].id}>
                <img src={categories[index].imageUrl} alt=""/>
                <p >{categories[index].name}</p>
            </div>)
        })
        return (
            <div>
                <p>hello</p>
                <Slider {...settings}>
                    {categoriesItems}
                </Slider>
            </div>

        );
    }
}
export default CategoriesSlider;