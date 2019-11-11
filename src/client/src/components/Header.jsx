import React, { useState, Fragment } from 'react';
import { Link } from 'react-router-dom';
import basicStyles from '../styles/assets/main.scss';
import logo from '../img/logo.png';
import styles from '../scss/Header.scss';
import { Register } from './Register';
import { Login } from './Login';

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

const Header = React.memo(({ registrateNewUserAPI, loginUserAPI, isAuth, login }) => {
    const [registrationModalIsOpen, toggleRegistrationModal] = useState(false);
    const [loginModalIsOpen, toggleLoginModal] = useState(false);
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
    return (
        <div className={basicStyles.wrapper}>
            <nav className={styles.nav}>
                <ul>
                    <li>
                        <img src={logo} alt="Logo" />
                    </li>
                    <li>
                        <button type="button">category</button>
                    </li>
                    <li>
                        <button type="button">search</button>
                    </li>
                    <li>
                        <button type="button">likes</button>
                    </li>
                    <li>
                        <Link to="/create">create</Link>
                    </li>
                    {isAuth ? (
                        <li>
                            <p>{login}</p>
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
        </div>
    );
});

export default Header;
