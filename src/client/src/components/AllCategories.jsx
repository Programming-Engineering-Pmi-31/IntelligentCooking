import React, { PureComponent } from 'react';
import { faHome, faSpinner, faTimes } from '@fortawesome/free-solid-svg-icons';
import Modal from 'react-modal';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { Link } from 'react-router-dom';
import styles from '../scss/AllCategories.scss';

export class AllCategories extends PureComponent {
    state = {
        name: '',
        image: null,
    };

    componentDidMount() {
        Modal.setAppElement('body');
        const { categories, setCategories } = this.props;
        if (!categories.length) setCategories();
    }

    valueChange = event => {
        const { name, value } = event.target;
        this.setState(prevState => ({
            ...prevState,
            [name]: value,
        }));
    };

    getInputElement = node => {
        this._inputEl = node;
    };

    render() {
        const { categories, createCategory, deleteCategory, isAuth } = this.props;
        console.log(this.state);
        return (
            <div className={styles.form}>
                <h2>Categories</h2>
                <form>
                    {isAuth && (
                        <div className={styles.createCategory}>
                            <p>Create New Category</p>
                            <input
                                value={this.state.name}
                                type="text"
                                name="name"
                                placeholder="Name..."
                                onChange={this.valueChange}
                            />
                            <input
                                type="file"
                                name="image"
                                id="image"
                                onChange={e => {
                                    if (e.target.files[0]) {
                                        this.setState({
                                            image: e.target.files[0],
                                        });
                                        if(e.target.files[0]){
                                            this._inputEl.innerHTML = e.target.files[0].name;
                                        }
                                    } else{
                                        this.setState({
                                            image: null,
                                        });
                                    }
                                }}
                            />
                            <label htmlFor="image" id="categoryLabel" ref={this.getInputElement}>
                                Choose image
                            </label>
                            <button
                                onClick={e => {
                                    e.preventDefault();
                                    createCategory({
                                        name: this.state.name,
                                        image: this.state.image,
                                    }).then(() => {
                                        this.setState({
                                            name: '',
                                            image: '',
                                        });
                                        this._inputEl.innerHTML = 'Choose image';
                                    });
                                }}
                            >
                                Create Category
                            </button>
                        </div>
                    )}

                    <ul>
                        {categories.map((item, index) => (
                            <li key={item.id}>
                                <div>
                                    <span>
                                        {index + 1}. {item.name}
                                    </span>
                                    <img src={item.imageUrl} alt={item.name} />
                                </div>
                                <button
                                    onClick={e => {
                                        e.preventDefault();
                                        deleteCategory(item.id);
                                    }}
                                >
                                    <FontAwesomeIcon icon={faTimes} />
                                </button>
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
