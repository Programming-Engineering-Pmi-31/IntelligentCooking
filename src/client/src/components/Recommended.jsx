import React, { Component } from 'react';
import Slider from 'react-slick';
import styles from '../scss/Recommended.scss';

class Recommended extends Component {
    state = {
        shouldUpdate: true,
    };

    componentDidMount() {
        const { setRecipes } = this.props;
        setRecipes(0,8);
    }

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
            autoplaySpeed: 3000,
            variableWidth: true,
            arrows: false,
        };
        const sliderItems = [];
        const indexes = [];

        if (dishes.length > 0) {
            let randomIndex;
            while (indexes.length < 6) {
                randomIndex = Math.floor(Math.random() * dishes.length);
                if (indexes.indexOf(randomIndex) == -1) {
                    indexes.push(randomIndex);
                    sliderItems.push(
                        <div
                            style={{ width: 500 }}
                            className={styles.slider__item}
                            key={dishes[randomIndex].id}
                        >
                            <img src={dishes[randomIndex].imageUrl} alt="" />
                            <p>{`cals: ${dishes[randomIndex].calories} time: ${dishes[randomIndex].time}`}</p>
                            <div />
                        </div>,
                    );
                }
            }
        }
        return <Slider {...settings}>{sliderItems}</Slider>;
    }
}
export default Recommended;
