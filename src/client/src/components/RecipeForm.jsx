import React, { Component, useState } from 'react';
import Select from 'react-select';
import classNames from 'classnames';
import Textarea from 'react-textarea-autosize';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { Link } from 'react-router-dom';
import Modal from 'react-modal';
import { faHome, faPlusCircle, faTimes } from '@fortawesome/free-solid-svg-icons';
import styles from '../scss/CreateRecipe.scss';
import { Previews } from './Dropzone';

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

class RecipeForm extends Component {
    state = {
        addIngredientIsOpen: false,
        addCategoryIsOpen: false,
        name: '',
        categories: null,
        description: '',
        img: [],
        time: '',
        ingredients: [],
        ingredientAmounts: {},
        servings: null,
        proteins: null,
        carbs: null,
        fats: null,
        cals: null,
        recipe: '',
    };

    componentDidMount() {
        const {
            setIngredients,
            setCategories,
            ingredientsList,
            categoriesList,
            isEditing,
            getRecipe,
            match,
            soloDish,
        } = this.props;
        if (isEditing) {
            getRecipe(match.params.id).then(res => {
                this.setState({
                    name: res.name,
                    description: res.description,
                    categories: res.categories.map(e => ({ label: e.name, value: e.id })),
                    ingredients: res.ingredients.map(e => ({ label: e.name, value: e.id })),
                    servings: res.servings,
                    proteins: res.proteins,
                    carbs: res.carbohydrates,
                    fats: res.fats,
                    cals: res.calories,
                    img: res.images.map(e => ({ url: e.url })),
                    recipe: res.recipe,
                    time: res.time,
                });
            });
        }
        if (!ingredientsList.length) setIngredients();
        if (!categoriesList.length) setCategories();
    }

    createIngredientsOpen = () => {
        this.setState({
            addIngredientIsOpen: true,
        });
    };

    createIngredientsClose = (e) => {
        this.setState({
            addIngredientIsOpen: false,
        });
    };

    categoriesChange = category => {
        this.setState({ categories: category });
    };

    ingredientsChange = ingredient => {
        const { ingredients } = this.state;
        ingredient == null ? (ingredient = []) : ingredient;
        const difference = ingredients.filter(x => !ingredient.includes(x));
        console.log('Removed: ', difference);
        this.setState(prevState => ({
            ingredients: ingredient,
            ingredientAmounts: {
                [difference.value]: undefined,
            },
        }));
    };

    ingredientsRecipeChange = event => {
        const { name, value } = event.target;
        this.setState(prevState => ({
            ingredientAmounts: {
                ...prevState.ingredientAmounts,
                [name]: value,
            },
        }));
    };

    valueChange = event => {
        const { name, value, type } = event.target;
        this.setState(prevState => ({
            ...prevState,
            [name]: type === 'number' ? parseFloat(value) : value,
        }));
    };

    imageChange = images => {
        this.setState({
            img: images,
        });
    };

    render() {
        const {
            categories,
            name,
            img,
            description,
            ingredients,
            ingredientAmounts,
            recipe,
            time,
            cals,
            carbs,
            servings,
            fats,
            proteins,
        } = this.state;
        const {
            ingredientsList,
            categoriesList,
            createProduct,
            setRecipe,
            skip,
            soloDish,
        } = this.props;

        let catToSend;
        {
            categories ? (catToSend = categories.map(item => item.value)) : (catToSend = []);
        }
        const obj = {
            name: name,
            img: Object.values(img).filter(e => e !== undefined),
            description: description,
            ingredients: Object.values(ingredients).map(e => e.value),
            ingredientAmounts: Object.values(ingredientAmounts).filter(e => e !== undefined),
            categories: catToSend,
            recipe: recipe,
            time: time,
            cals: cals,
            servings: servings,
            fats: fats,
            proteins: proteins,
            carbs: carbs,
        };
        const ingredientsOptions = [];
        const categoriesOptions = [];

        ingredientsList.map(item => ingredientsOptions.push({ value: item.id, label: item.name }));
        categoriesList.map(item => categoriesOptions.push({ value: item.id, label: item.name }));
        return (
            <div className={styles.form}>
                <h2>Create new recipe</h2>
                <form>
                    <div>
                        <Input name="name" type="text" value={name} handler={this.valueChange} />
                        <label className={styles.label}>Name</label>
                    </div>
                    <div>
                        <Input
                            name="description"
                            type="text"
                            value={description}
                            handler={this.valueChange}
                        />
                        <label className={styles.label}>Description</label>
                    </div>
                    <div className={styles.form__selector}>
                        <div>
                            <Select
                                value={categories}
                                onChange={this.categoriesChange}
                                options={categoriesOptions}
                                isMulti
                            />
                            <label className={styles.label}>Category</label>
                        </div>
                        <div className={styles.addBtn}>
                            <FontAwesomeIcon icon={faPlusCircle} />
                        </div>
                    </div>
                    <div className={styles.input_img__block}>
                        <Previews img={img} valueChange={this.imageChange} />
                        <label className={styles.label__img}>Images</label>
                    </div>
                    <div className={styles.form__selector}>
                        <div>
                            <Select
                                value={ingredients}
                                onChange={this.ingredientsChange}
                                options={ingredientsOptions}
                                isMulti
                            />
                            <label className={styles.label}>Ingredients</label>
                        </div>
                        <div className={styles.addBtn}>
                            <button onClick={(e) => {
                                e.preventDefault();
                                this.createIngredientsOpen();
                            }}>
                                <FontAwesomeIcon icon={faPlusCircle} />
                            </button>
                        </div>
                    </div>
                    <Modal
                        isOpen={this.state.addIngredientIsOpen}
                        onRequestClose={this.createIngredientsClose}
                        houldCloseOnOverlayClick={false}
                        style={customStyles}
                        contentLabel="Example Modal"
                    >
                        <button className={styles.closeAuth} >
                            <FontAwesomeIcon icon={faTimes} />
                        </button>
                        <p className={styles.authTitle}> Please sign in</p>
                        <form className={styles.authForm}>
                            <input placeholder="Login" name="login" type="email" />
                            <input placeholder="Password" type="password" />

                        </form>
                    </Modal>
                    <div>
                        {ingredients.length ? (
                            <table className={styles.ingredient__table}>
                                <thead>
                                    <tr>
                                        <th>&#8470;</th>
                                        <th>Ingredient</th>
                                        <th>Amount</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    {ingredients.map((item, index) => (
                                        <tr key={ingredients[ingredients.length - 1 - index].value}>
                                            <td>{index + 1}</td>
                                            <td>
                                                {ingredients[ingredients.length - 1 - index].label}
                                            </td>
                                            <td>
                                                <Input
                                                    type="text"
                                                    name={
                                                        ingredients[ingredients.length - 1 - index]
                                                            .value
                                                    }
                                                    handler={this.ingredientsRecipeChange}
                                                />
                                            </td>
                                        </tr>
                                    ))}
                                </tbody>
                            </table>
                        ) : null}
                    </div>
                    <div className={styles.energy__inputs}>
                        <div>
                            <Input
                                name="proteins"
                                type="number"
                                value={proteins}
                                handler={this.valueChange}
                            />
                            <label className={styles.label}>Proteins</label>
                        </div>
                        <div>
                            <Input
                                name="carbs"
                                type="number"
                                value={carbs}
                                handler={this.valueChange}
                            />
                            <label className={styles.label}>Carbs</label>
                        </div>
                        <div>
                            <Input
                                name="fats"
                                type="number"
                                value={fats}
                                handler={this.valueChange}
                            />
                            <label className={styles.label}>Fats</label>
                        </div>
                        <div>
                            <Input
                                name="cals"
                                type="number"
                                value={cals}
                                handler={this.valueChange}
                            />
                            <label className={styles.label}>Cals</label>
                        </div>
                    </div>
                    <div className={styles.additional_info}>
                        <div>
                            <Input
                                name="servings"
                                type="number"
                                value={servings}
                                handler={this.valueChange}
                            />
                            <label className={styles.label}>Servings</label>
                        </div>
                        <div>
                            <Input
                                name="time"
                                type="time"
                                value={time}
                                handler={this.valueChange}
                            />
                            <label className={styles.label}>Time</label>
                        </div>
                    </div>
                    <div>
                        <TextArea name="recipe" value={recipe} handler={this.valueChange} />
                        <label className={styles.label}>Recipe</label>
                    </div>
                    <input
                        type="button"
                        onClick={() => {
                            createProduct(obj).then(res => {
                                this.props.history.push(`/recipe/${res.data.id}`);
                                setRecipe(skip);
                            });
                        }}
                        value="Send Message"
                    />
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
class Input extends Component {
    state = {
        length: 0,
        value: null,
    };

    componentDidUpdate(prevProps, prevState, snapshot) {
        if (this.props.value != null && prevProps.value !== this.props.value) {
            this.setState({
                value: this.props.value,
                length: this.props.value.toString().length,
            });
        }
    }

    valueChange = event => {
        const { value } = event.target;
        this.setState({
            length: value.length,
            value: value,
        });
    };

    render() {
        const { length, value } = this.state;
        const { name, handler, type } = this.props;
        const inputClass = classNames({
            [styles.input__active]: length > 0,
        });
        return (
            <input
                className={inputClass}
                name={name}
                value={this.props.value}
                onChange={e => {
                    this.valueChange(e);
                    handler(e);
                }}
                type={type}
            />
        );
    }
}
class TextArea extends Component {
    state = {
        length: 0,
        value: null,
    };

    componentDidUpdate(prevProps, prevState, snapshot) {
        if (this.props.value != null && prevProps.value !== this.props.value) {
            this.setState({
                value: this.props.value,
                length: this.props.value.toString().length,
            });
        }
    }

    valueChange = event => {
        const { value } = event.target;
        this.setState({
            length: value.length,
        });
    };

    render() {
        const { length } = this.state;
        const { name, handler, type } = this.props;
        const inputClass = classNames({
            [styles.input__active]: length > 0,
        });

        return (
            <Textarea
                className={inputClass}
                name={name}
                value={this.props.value}
                onChange={e => {
                    this.valueChange(e);
                    handler(e);
                }}
                type={type}
            />
        );
    }
}
export default RecipeForm;
