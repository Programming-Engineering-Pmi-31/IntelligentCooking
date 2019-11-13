import React, { useState } from 'react';
import { Link } from 'react-router-dom';
import { faHome, faTimes } from '@fortawesome/free-solid-svg-icons';
import Modal from 'react-modal';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import basicStyles from '../styles/assets/main.scss';
import logo from '../img/logo.png';
import google from '../img/google.png';
import facebook from '../img/facebook.png';
import instagram from '../img/instagram.png';
import styles from '../scss/Header.scss';

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

const Header = React.memo(({ dishes }) => {
    const [modalIsOpen, toggleModal] = useState(false);
    const openModal = () => {
        toggleModal(true);
    };
    const closeModal = () => {
        toggleModal(false);
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
                    <li>
                        <button type="button" onClick={openModal}>
                            log
                        </button>
                    </li>
                </ul>
            </nav>
            <Modal
                isOpen={modalIsOpen}
                onRequestClose={closeModal}
                style={customStyles}
                contentLabel="Example Modal"
            >
                <button className={styles.closeAuth} onClick={closeModal}>
                    <FontAwesomeIcon icon={faTimes} />
                </button>
                <p className={styles.authTitle}> Please sign in</p>
                <form className={styles.authForm}>
                    <input placeholder="Login" name="login" type="email" />
                    <input placeholder="Password" type="password" />
                    <div>
                        <ul>
                            <li>
                                <button>
                                <img src={facebook} alt="" />
                                </button>
                            </li>
                            <li>
                                <button>
                                    <img src={google} alt="" />
                                </button>
                            </li>
                            <li>
                                <button>
                                    <img src={instagram} alt="" />
                                </button>
                            </li>
                        </ul>
                    </div>
                    <button className={styles.signInBtn} type="submit">
                        Sign in
                    </button>
                </form>
            </Modal>
        </div>
    );
});

export default Header;
