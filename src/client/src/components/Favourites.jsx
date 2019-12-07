import React, { PureComponent, useEffect, useState } from 'react';
import { Link } from 'react-router-dom';
import { faTimes, faSpinner } from '@fortawesome/free-solid-svg-icons';
import Modal from 'react-modal';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import styles from '../scss/Favourites.scss';

export class Favourites extends PureComponent {
    state = {
        email: '',
        password: '',
    };

    componentDidMount() {
        Modal.setAppElement('body');
    }

    render() {
        const { modalIsOpen, closeModal, customStyles, favourite,addToFavourite } = this.props;

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
                <p className={styles.favouriteTitle}>Favourites</p>
                <ul>
                    {Object.keys(favourite).map(key => (
                        <li key={favourite[key].id}>
                            <div className={styles.favouriteDish}>
                                <Link to={`recipe/${favourite[key].id}`}>
                                    {favourite[key].name}
                                </Link>
                                <button onClick={()=> addToFavourite(favourite[key].id)}>
                                    <FontAwesomeIcon icon={faTimes} />
                                </button>

                            </div>
                        </li>
                    ))}
                </ul>
            </Modal>
        );
    }
}
