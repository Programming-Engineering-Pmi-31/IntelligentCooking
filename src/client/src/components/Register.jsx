import React, { PureComponent, useEffect, useState } from 'react';
import { faTimes } from '@fortawesome/free-solid-svg-icons';
import Modal from 'react-modal';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import google from '../img/google.png';
import facebook from '../img/facebook.png';
import instagram from '../img/instagram.png';
import styles from '../scss/Header.scss';

export class Register extends PureComponent {
    state = {
        email: '',
        login: '',
        password: '',
        confirm: '',
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

    registrateNewUser() {
        if (this.state.password !== this.state.confirm) {
            alert('confirm password should be equal two password');
        } else {
            this.props.registrate({
                email: this.state.email,
                login: this.state.login,
                password: this.state.password,
            });
        }
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
                <p className={styles.authTitle}>Register your account</p>
                <form className={styles.authForm}>
                    <input
                        placeholder="Email"
                        name="email"
                        type="email"
                        onChange={this.valueChange}
                    />
                    <input
                        placeholder="Login"
                        name="login"
                        type="text"
                        onChange={this.valueChange}
                    />
                    <input
                        placeholder="Password"
                        name="password"
                        type="password"
                        onChange={this.valueChange}
                    />
                    <input
                        placeholder="Confirm password"
                        name="confirm"
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
                            this.registrateNewUser();
                        }}
                        type="submit"
                    >
                        Sign in
                    </button>
                </form>
            </Modal>
        );
    }
}
