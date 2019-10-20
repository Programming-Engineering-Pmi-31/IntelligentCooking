import React, { Component } from 'react';
import { Link } from 'react-router-dom';
import Slider from 'react-slick';
import styles from '../scss/Recommended.scss';

class Recommended extends Component {
    state = {
        shouldUpdate: true,
    };

    shouldComponentUpdate(nextProps, nextState) {
        return this.state.shouldUpdate;
    }

    componentDidUpdate(prevProps, prevState, snapshot) {
        this.setState({
            shouldUpdate: false,
        });
    }

    render() {
        const { dishes } = this.props;
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

        if (dishes.length > 0) {
            let randomIndex;
            while (indexes.length < 6) {
                randomIndex = Math.floor(Math.random() * dishes.length);
                if (indexes.indexOf(randomIndex) === -1) {
                    indexes.push(randomIndex);
                    sliderItems.push(
                        <Link to={`/recipe/${dishes[randomIndex].id}`} key={dishes[randomIndex].id}>
                            <div
                                style={{ width: 500 }}
                                className={styles.slider__item}
                            >
                                <img src={dishes[randomIndex].imageUrl} alt="" />
                                <p>{`cals: ${dishes[randomIndex].calories} time: ${dishes[randomIndex].time}`}</p>
                                <div />
                            </div>
                        </Link>,
                    );
                }
            }
        }
        return <Slider {...settings}>{sliderItems}</Slider>;
    }
}
export default Recommended;
