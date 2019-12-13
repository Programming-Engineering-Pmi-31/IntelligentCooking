import React, { PureComponent } from 'react';
import jwt_decode from 'jwt-decode';
import Header from '../containers/Header';
import Recommended from '../containers/Recommended';
import CategoriesSlider from '../containers/CategoriesSlider';
import styles from '../styles/assets/main.scss';
import AllRecipes from '../containers/AllRecipes';

class App extends PureComponent {
    state = {
        from: null,
    };

    componentDidMount() {
        if(this.props.location.state){
            this.setState({
                from: this.props.location,
            })
            console.log(this.props.location)
        }

        const { setCategories, categories, authorizeWithStorage, setFavourite,favourite} = this.props;
        if (localStorage.getItem('token')) {
            authorizeWithStorage();
        }
        if(!favourite.length){
            setFavourite();
        }
        // authorizeWithStorage();
        if (!categories.length) {
            setCategories();
        }
    }

    render() {

        console.log('main render');
        return (
            <div className={styles.container}>
                <Header from={this.state.from}/>
                <Recommended />
                <CategoriesSlider />
                <AllRecipes />
            </div>
        );
    }
}
export default App;
