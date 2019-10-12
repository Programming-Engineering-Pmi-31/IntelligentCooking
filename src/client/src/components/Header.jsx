import React from 'react';
import { Link } from 'react-router-dom';
import basicStyles from '../styles/assets/main.scss';
import logo from '../img/logo.png';
import styles from '../scss/Header.scss';

const Header = React.memo(({ dishes }) => {
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
                        <button type="button">log</button>
                    </li>
                </ul>
            </nav>
        </div>
    );
});
export default Header;
