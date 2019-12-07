import React, { useState, Fragment, useEffect } from 'react';
import createHistory from 'history/createBrowserHistory';
import { Link } from 'react-router-dom';
import basicStyles from '../styles/assets/main.scss';
import logo from '../img/logo.png';
import styles from '../scss/Header.scss';
import { Register } from './Register';
import { Login } from './Login';
import { Search } from './Search';
import { Favourites } from './Favourites';

const customStyles = {
    content: {
        top: '30%',
        left: '40%',
        width: '40%',
        right: 'auto',
        bottom: 'auto',
        transform: 'translate(-25%, -30%)',
    },
    overlay: {
        backgroundColor: '#ffefd5dd',
    },
};

const Header = React.memo(
    ({
        registrateNewUserAPI,
        loginUserAPI,
        isAuth,
        login,
        token,
        isProccesing,
        ingredientsList,
        setIngredients,
        searchDish,
        Logout,
        from,
        setFavourite,
         favourite,
         addToFavourite,
    }) => {
        const [registrationModalIsOpen, toggleRegistrationModal] = useState(false);
        const [loginModalIsOpen, toggleLoginModal] = useState(false);
        const [searchModalIsOpen, toggleSearchModal] = useState(false);
        const [favouritesModalIsOpen, toggleFavouriteModal] = useState(false);
        useEffect(() => {
            if (!localStorage.getItem('token') && from !== null) {
                // const history = createHistory();
                openLoginModal();
                // history.replace({});
            }
        }, [from]);
        const openRegistrationModal = () => {
            toggleRegistrationModal(true);
        };
        const closeRegistrationModal = () => {
            toggleRegistrationModal(false);
        };
        const openLoginModal = () => {
            toggleLoginModal(true);
        };
        const closeLoginModal = () => {
            toggleLoginModal(false);
        };
        const openSearchModal = () => {
            toggleSearchModal(true);
        };
        const closeSearchModal = () => {
            toggleSearchModal(false);
        };
        const openFavouritesModal = () => {
            toggleFavouriteModal(true);
        };
        const closeFavouritesModal = () => {
            toggleFavouriteModal(false);
        };
        return (
            <div className={basicStyles.wrapper}>
                <nav className={styles.nav}>
                    <ul>
                        <li>
                            <img src={logo} alt="Logo" />
                        </li>
                        <li>
                            <Link to="/allingredients">
                                <button>ingredients</button>
                            </Link>
                        </li>
                        <li>
                            <Link to="/allcategories">
                                <button>categories</button>
                            </Link>
                        </li>
                        <li>
                            <button type="button" onClick={openSearchModal}>
                                search
                            </button>
                        </li>
                        {isAuth && (
                            <li>
                                <button type="button" onClick={openFavouritesModal}>
                                    likes
                                </button>
                            </li>
                        )}
                        {isAuth && (
                            <li>
                                <Link to="/create">
                                    <button>create</button>
                                </Link>
                            </li>
                        )}
                        {isAuth ? (
                            <li className={styles.logName}>
                                <button>{login}</button>
                                <button onClick={Logout}>Logout</button>
                            </li>
                        ) : (
                            <Fragment>
                                <li>
                                    <button type="button" onClick={openRegistrationModal}>
                                        register
                                    </button>
                                </li>
                                <li>
                                    <button type="button" onClick={openLoginModal}>
                                        log
                                    </button>
                                </li>
                            </Fragment>
                        )}
                    </ul>
                </nav>
                <Register
                    isProccesing={isProccesing}
                    registrate={registrateNewUserAPI}
                    modalIsOpen={registrationModalIsOpen}
                    customStyles={customStyles}
                    closeModal={closeRegistrationModal}
                />
                <Login
                    setFavourite={setFavourite}
                    from={from}
                    isAuth={isAuth}
                    isProccesing={isProccesing}
                    login={loginUserAPI}
                    modalIsOpen={loginModalIsOpen}
                    customStyles={customStyles}
                    closeModal={closeLoginModal}
                />
                <Search
                    searchDish={searchDish}
                    setIngredients={setIngredients}
                    ingredientsList={ingredientsList}
                    login={loginUserAPI}
                    modalIsOpen={searchModalIsOpen}
                    customStyles={customStyles}
                    closeModal={closeSearchModal}
                />
                <Favourites
                    addToFavourite={addToFavourite}
                    favourite={favourite}
                    customStyles={customStyles}
                    modalIsOpen={favouritesModalIsOpen}
                    closeModal={closeFavouritesModal}
                />
            </div>
        );
    },
);

export default Header;
