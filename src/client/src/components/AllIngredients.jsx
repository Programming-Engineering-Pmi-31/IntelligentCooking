import React, { PureComponent } from 'react';
import { faHome, faSpinner, faTimes } from '@fortawesome/free-solid-svg-icons';
import Modal from 'react-modal';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { Link } from 'react-router-dom';
import styles from '../scss/AllIngredients.scss';

export class AllIngredients extends PureComponent {
    state = {
        name: '',
    };

    componentDidMount() {
        Modal.setAppElement('body');
        const { ingredients, setIngredients } = this.props;
        if (!ingredients.length) setIngredients();
    }

    valueChange = event => {
        const { name, value } = event.target;
        this.setState(prevState => ({
            ...prevState,
            [name]: value,
        }));
    };

    render() {
        const { ingredients, deleteIngredient, createIngredient, isAuth } = this.props;
        console.log(this.state);
        return (
            <div className={styles.form}>
                <h2>Ingredients</h2>
                <form>
                    {isAuth && <div className={styles.createIngredient}>
                        <p>Create New Ingredient</p>
                        <input type="text" name="name" placeholder="Name..." onChange={this.valueChange}/>
                        <button onClick={(e) => {
                            e.preventDefault();
                            createIngredient(this.state.name)
                        }}>Create Ingredient</button>
                    </div>}
                    <ul>
                        {ingredients.map((item,index) => (
                            <li key={item.id}>
                                <span>{index+1}. {item.name}</span>
                                <button onClick={(e) => {
                                    e.preventDefault();
                                    deleteIngredient(item.id)
                                }}><FontAwesomeIcon icon={faTimes}/></button>
                            </li>
                        ))}
                    </ul>
                </form>

                <div className={styles.home__btn}>
                    <Link to="/">
                        <FontAwesomeIcon icon={faHome} />
                    </Link>
                </div>
            </div>
        );
    }
}
