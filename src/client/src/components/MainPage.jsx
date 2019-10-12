import React, { PureComponent } from 'react';
import axios from 'axios';
import Header from '../containers/Header';
import Recommended from '../containers/Recommended';
import CategoriesSlider from '../containers/CategoriesSlider';
import styles from '../styles/assets/main.scss';
import AllRecipes from '../containers/AllRecipes';

class App extends PureComponent {
    componentDidMount() {
        const { setCategories } = this.props;
        setCategories();
    }

    render() {
        return (
            <div className={styles.container}>
                <Header />
                <Recommended />
                <CategoriesSlider />
                <AllRecipes />
            </div>
        );
    }
}
export default App;
