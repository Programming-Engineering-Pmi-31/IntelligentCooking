import React from "react";
import styles from "../scss/Recommended.scss";
import Slider from "react-slick";

class Recommended extends React.PureComponent {
    componentDidMount() {
        const {setRecipes} = this.props;
        setRecipes();
    }
    render() {
        const {dishes} = this.props;

        const settings = {
            className: "slider variable-width",
            infinite: true,
            speed: 500,
            slidesToShow: 1,
            slidesToScroll: 1,
            autoplay: true,
            autoplaySpeed: 3000,
            variableWidth: true,
            arrows: false
        };
        let sliderItems = [];
        let indexes = [];
        if(dishes.length > 0){
            let randomIndex;
            while (indexes.length < 6) {
                randomIndex = Math.floor(Math.random() * dishes.length);
                if (indexes.indexOf(randomIndex) == -1) {
                    indexes.push(randomIndex);
                    sliderItems.push(<div style={{width:500}} className={styles.slider__item} key={dishes[randomIndex].id}>
                        <img src={dishes[randomIndex].imageUrl} alt=""/>
                        <p >{`cals: ${dishes[randomIndex].calories} time: ${dishes[randomIndex].time}`}</p>
                        <div></div>
                    </div>)
                }
            }
        }
        return (
            <Slider {...settings}>
                {sliderItems}
            </Slider>
        );
    }
}
export default Recommended;