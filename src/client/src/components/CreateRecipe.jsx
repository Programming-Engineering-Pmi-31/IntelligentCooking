import React, { Component } from 'react';
import Select from 'react-select';
import classNames from 'classnames';
import Textarea from 'react-textarea-autosize';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { Link, withRouter } from 'react-router-dom';
import { faHome } from '@fortawesome/free-solid-svg-icons';
import styles from '../scss/CreateRecipe.scss';
import { Previews } from './Dropzone';

class CreateRecipe extends Component {
    state = {
        name: '',
        categories: null,
        description: '',
        img: [],
        time: '',
        ingredients: [],
        ingredientAmounts: {},
        servings: 0,
        proteins: 0,
        carbs: 0,
        fats: 0,
        cals: 0,
        recipe: '',
    };

    componentDidMount() {
        console.log("create did mount");
        const { setIngredients, setCategories, ingredientsList, categoriesList } = this.props;
        if (!ingredientsList.length) setIngredients();
        if (!categoriesList.length) setCategories();
    }

    categoriesChange = category => {
        console.log(category);
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
        console.log("create render");
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
        const { ingredientsList, categoriesList, createProduct } = this.props;
        let catToSend;
        {
            categories ? (catToSend = categories.map(item => item.value)) : (catToSend = []);
        }
        const obj = {
            title: name,
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
                        <Input name="name" type="text" handler={this.valueChange} />
                        <label className={styles.label}>Name</label>
                    </div>
                    <div>
                        <Input name="description" type="text" handler={this.valueChange} />
                        <label className={styles.label}>Description</label>
                    </div>
                    <div className={styles.form__selector}>
                        <Select
                            value={categories}
                            onChange={this.categoriesChange}
                            options={categoriesOptions}
                            isMulti
                        />
                        <label className={styles.label}>Category</label>
                    </div>
                    <div className={styles.input_img__block}>
                        <Previews valueChange={this.imageChange} />
                        <label className={styles.label__img}>Images</label>
                    </div>
                    <div className={styles.form__selector}>
                        <Select
                            value={ingredients}
                            onChange={this.ingredientsChange}
                            options={ingredientsOptions}
                            isMulti
                        />
                        <label className={styles.label}>Ingredients</label>
                    </div>
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
                            <Input name="proteins" type="number" handler={this.valueChange} />
                            <label className={styles.label}>Proteins</label>
                        </div>
                        <div>
                            <Input name="carbs" type="number" handler={this.valueChange} />
                            <label className={styles.label}>Carbs</label>
                        </div>
                        <div>
                            <Input name="fats" type="number" handler={this.valueChange} />
                            <label className={styles.label}>Fats</label>
                        </div>
                        <div>
                            <Input name="cals" type="number" handler={this.valueChange} />
                            <label className={styles.label}>Cals</label>
                        </div>
                    </div>
                    <div className={styles.additional_info}>
                        <div>
                            <Input name="servings" type="number" handler={this.valueChange} />
                            <label className={styles.label}>Servings</label>
                        </div>
                        <div>
                            <Input name="time" type="time" handler={this.valueChange} />
                            <label className={styles.label}>Time</label>
                        </div>
                    </div>
                    <div>
                        <TextArea name="recipe" handler={this.valueChange} />
                        <label className={styles.label}>Recipe</label>
                    </div>
                    <input
                        type="button"
                        onClick={() => {
                            createProduct(obj).then(res =>
                                this.props.history.push(`/recipe/${res.data.id}`)
                            );
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
    };

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
            <input
                className={inputClass}
                name={name}
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
    };

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
                onChange={e => {
                    this.valueChange(e);
                    handler(e);
                }}
                type={type}
            />
        );
    }
}
export default withRouter(CreateRecipe);
