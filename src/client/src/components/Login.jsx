import React, { PureComponent, useEffect, useState } from 'react';
import { faTimes } from '@fortawesome/free-solid-svg-icons';
import Modal from 'react-modal';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import google from '../img/google.png';
import facebook from '../img/facebook.png';
import instagram from '../img/instagram.png';
import styles from '../scss/Header.scss';

export class Login extends PureComponent {
    state = {
        email: '',
        password: '',
    };

    componentDidMount() {
        Modal.setAppElement('body');
    }

    valueChange = event => {
        const { name, value } = event.target;
        this.setState(prevState => ({
            ...prevState,
            [name]: value,
        }));
    };

    LoginUser() {
        this.props.login({
            email: this.state.email,
            password: this.state.password,
        });
    }

    render() {
        console.log(this.state);
        const { modalIsOpen, closeModal, customStyles } = this.props;
        return (
            <Modal
                isOpen={modalIsOpen}
                onRequestClose={closeModal}
                style={customStyles}
                contentLabel="Example Modal"
            >
                <button className={styles.closeAuth} onClick={closeModal}>
                    <FontAwesomeIcon icon={faTimes} />
                </button>
                <p className={styles.authTitle}>Login</p>
                <form className={styles.authForm}>
                    <input
                        placeholder="Email"
                        name="email"
                        type="email"
                        onChange={this.valueChange}
                    />
                    <input
                        placeholder="Password"
                        name="password"
                        type="password"
                        onChange={this.valueChange}
                    />
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
                    <button
                        className={styles.signInBtn}
                        onClick={e => {
                            e.preventDefault();
                            this.LoginUser();
                        }}
                        type="submit"
                    >
                        Log In
                    </button>
                </form>
            </Modal>
        );
    }
}
