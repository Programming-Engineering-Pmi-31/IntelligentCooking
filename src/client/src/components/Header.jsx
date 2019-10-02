import React from 'react';
import basicStyles from '../styles/assets/main.scss'
import logo from '../img/logo.png'
import Slider from "react-slick";
import styles from '../scss/Header.scss'
const Header = React.memo(({dishes}) => {
    return (
            <div className={basicStyles.wrapper}>
                <nav className={styles.nav}>
                    <ul>
                        <li><img src={logo} alt="Logo"/></li>
                        <li><button>category</button></li>
                        <li><button>search</button></li>
                        <li><button>likes</button></li>
                        <li><button>create</button></li>
                        <li><button>log</button></li>
                    </ul>
                </nav>
            </div>
    )
});
export default Header;