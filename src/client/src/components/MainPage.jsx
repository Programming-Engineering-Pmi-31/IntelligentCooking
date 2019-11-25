import React, { PureComponent } from 'react';
import Header from '../containers/Header';
import Recommended from '../containers/Recommended';
import CategoriesSlider from '../containers/CategoriesSlider';
import styles from '../styles/assets/main.scss';
import AllRecipes from '../containers/AllRecipes';
import jwt_decode from "jwt-decode";

class App extends PureComponent {
    componentDidMount() {
        console.log("main did mount");
        const { setCategories, categories, authorizeWithStorage } = this.props;
        authorizeWithStorage();
        if (!categories.length) {
            setCategories();
        }
    }

    render() {
        console.log("main render");
        return (
            <div className={styles.container}>
                <Header />
                {/*<Recommended />*/}
                <CategoriesSlider />
                <AllRecipes />
            </div>
        );
    }
}
export default App;
