import React, { useState, Fragment } from 'react';
import { Link } from 'react-router-dom';
import basicStyles from '../styles/assets/main.scss';
import logo from '../img/logo.png';
import styles from '../scss/Header.scss';
import { Register } from './Register';
import { Login } from './Login';
import { Search } from './Search';

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
    ({ registrateNewUserAPI, loginUserAPI, isAuth, login,token, ingredientsList,setIngredients,
                filterByIngredient, Logout }) => {
        const [registrationModalIsOpen, toggleRegistrationModal] = useState(false);
        const [loginModalIsOpen, toggleLoginModal] = useState(false);
        const [searchModalIsOpen, toggleSearchModal] = useState(false);
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
        return (
            <div className={basicStyles.wrapper}>
                <nav className={styles.nav}>
                    <ul>
                        <li>
                            <img src={logo} alt="Logo" />
                        </li>
                        <li>
                            <button type="button">ingredients</button>
                        </li>
                        <li>
                            <button type="button">categories</button>
                        </li>
                        <li>
                            <button type="button" onClick={openSearchModal}>search</button>
                        </li>
                        <li>
                            <button type="button">likes</button>
                        </li>
                        <li>
                            <Link to="/create">create</Link>
                        </li>
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
                    registrate={registrateNewUserAPI}
                    modalIsOpen={registrationModalIsOpen}
                    customStyles={customStyles}
                    closeModal={closeRegistrationModal}
                />
                <Login
                    login={loginUserAPI}
                    modalIsOpen={loginModalIsOpen}
                    customStyles={customStyles}
                    closeModal={closeLoginModal}
                />
                <Search
                    filterByIngredient={filterByIngredient}
                    setIngredients={setIngredients}
                    ingredientsList={ingredientsList}
                    login={loginUserAPI}
                    modalIsOpen={searchModalIsOpen}
                    customStyles={customStyles}
                    closeModal={closeSearchModal}
                />
            </div>
        );
    },
);

export default Header;
