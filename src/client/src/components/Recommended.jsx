import React, { Component } from 'react';
import Helmet from 'react-helmet';
import { Link } from 'react-router-dom';
import Slider from 'react-slick';
import styles from '../scss/Recommended.scss';

class Recommended extends Component {
    state = {
        recommended: [],
    };

    componentDidMount() {
        const { getRecommended, recommended } = this.props;
        if (!recommended.length) {
            getRecommended(6);
        }
    }

    render() {
        const { recommended } = this.props;
        const settings = {
            className: 'slider variable-width',
            infinite: true,
            speed: 500,
            slidesToShow: 1,
            slidesToScroll: 1,
            autoplay: true,
            autoplaySpeed: 2000,
            variableWidth: true,
            draggable: false,
            swipeToSlide: false,
            touchMove: false,
            arrows: true,
        };
        const sliderItems = [];
        const indexes = [];
        recommended.map(item => {
            sliderItems.push(
                <Link to={`/recipe/${item.id}`} key={item.id}>
                    <div style={{ width: 500 }} className={styles.slider__item}>
                        <img src={item.imageUrl} alt="" />
                        <p>{`cals: ${item.calories} time: ${item.time}`}</p>
                        <div />
                    </div>
                </Link>,
            );
        });
        return (
            <div>
                <Slider {...settings}>{sliderItems}</Slider>
            </div>
        );
    }
}
export default Recommended;
