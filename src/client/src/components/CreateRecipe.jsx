import React,{Component} from 'react';
import styles from "../scss/CreateRecipe.scss"
import axios from 'axios'
import Select from 'react-select';
import classNames from  'classnames'
import _ from 'lodash/isUndefined'
import diff from "redux-logger/src/diff";
class CreateRecipe extends Component {
    state = {
        name:"",
        categories:null,
        description:"",
        img:0,
        time:"",
        ingredients:[],
        ingredientAmounts:{},
        servings:0,
        proteins:0,
        carbs :0,
        fats:0,
        cals: 0,
        recipe:"",
        likes:0,

    };

    categoriesChange = category => {
        console.log(category);
        this.setState(
            { categories: category }
        );
    };
    ingredientsChange = ingredient => {
        ingredient == null? ingredient = [] : ingredient
        let difference =  this.state.ingredients.filter(x => !ingredient.includes(x));
        console.log('Removed: ', difference);
        this.setState(prevState=>(
            {
                ingredients: ingredient,
                ingredientAmounts:{
                    [difference.value]: undefined
                }

            })
        );

    };
    ingredientsRecipeChange = event => {
        const { name, value } = event.target;
        this.setState( prevState=>({
            ingredientAmounts: {
                ...prevState.ingredientAmounts,
                [name]:value
            }
        }))
    }

    createProduct = (obj) =>{
        const formData = new FormData();
        for(let val in obj){
            if(val !== 'ingredients' && val !== 'categories' && val !== 'ingredientAmounts')
            formData.append(val, obj[val])
        }

        for(let [i, val] of obj.ingredients.entries())
            formData.append(`ingredients[${i}]`, val)
            
        for(let [i, val] of obj.categories.entries())
            formData.append(`categories[${i}]`, val)
        
        for(let [i, val] of obj.ingredientAmounts.entries())
            formData.append(`ingredientAmounts[${i}]`, val)

        axios({
            method: 'POST',
            url: 'https://localhost:44335/api/Dish',
            data: formData
        })
        console.log(formData)
    }
    fileChangedHandler = e => {
        this.setState({ img: e.target.files[0] })
    }

    valueChange = (event) => {
        const { name, value,type } = event.target;
        console.log(name,value)
        this.setState((prevState) => ({
            [name]: type === 'number' ? parseFloat(value) : value
        }));
    };
    componentDidMount() {
        const {setIngredients,setCategories} = this.props;
        setIngredients();
        setCategories();
    }

    render() {
        let catToSend;
        {this.state.categories ? catToSend = this.state.categories.map(item=>item.value) : catToSend = []}
        let obj = {
            title:this.state.name,
            img: this.state.img,
            description: this.state.description,
            ingredients: Object.values(this.state.ingredients).map(e => e.value),
            ingredientAmounts: Object.values(this.state.ingredientAmounts).filter(e => e != undefined),
            categories:catToSend,
            recipe:this.state.recipe,
            time:this.state.time,
            cals:this.state.cals,
            servings:this.state.servings,
            fats:this.state.fats,
            proteins:this.state.proteins,
            carbs:this.state.carbs
        };
        console.log(obj);
        let ingredientsOptions = [];
        let categoriesOptions = [];
        const {ingredientsList,categoriesList} = this.props;
        ingredientsList.map(item => ingredientsOptions.push({value:item.id, label:item.name}))
        categoriesList.map(item => categoriesOptions.push({value:item.id, label:item.name}))
        return (
            <div className={styles.form}>
                <h2>Create new recipe</h2>
                <form>
                    <div>
                        <Input name="name" type="text" handler={this.valueChange}/>
                        <label className={styles.label}>Name</label>
                    </div>
                    <div>
                        <Input name="description" type="text" handler={this.valueChange}/>
                        <label className={styles.label}>Description</label>
                    </div>
                    <div className={styles.form__selector}>
                        <Select
                            value={this.state.categories}
                            onChange={this.categoriesChange}
                            options={categoriesOptions}
                            isMulti={true}

                        />
                        <label className={styles.label}>Category</label>
                    </div>
                    <div>
                        <input name="img" id='name-input' onChange={this.fileChangedHandler} type="file"/>
                        <label className={styles.label}>Image URL</label>
                    </div>
                    <div className={styles.form__selector}>
                        <Select
                            value={this.state.ingredients}
                            onChange={this.ingredientsChange.bind(this)}
                            options={ingredientsOptions}
                            isMulti={true}
                        />
                        <label className={styles.label}>Ingredients</label>
                    </div>
                    <div>
                        {this.state.ingredients ?
                            <table className={styles.ingredient__table}>
                                <thead>
                                <tr>
                                    <th>&#8470;</th>
                                    <th>Ingredient</th>
                                    <th>Amount</th>
                                </tr>
                                </thead>
                                <tbody>
                                {this.state.ingredients.map((item, index) => (
                                    <tr key={this.state.ingredients[this.state.ingredients.length-1-index].value}>
                                        <td>{index+ 1}</td>
                                        <td>{this.state.ingredients[this.state.ingredients.length-1-index].label}</td>
                                        <td><input type="text"
                                                   name={this.state.ingredients[this.state.ingredients.length-1-index].value}
                                                   onChange={this.ingredientsRecipeChange}/>
                                        </td>
                                    </tr>))}
                                </tbody>
                            </table> : null
                        }
                    </div>
                    <div className={styles.input__flex}>
                        <div>
                            <Input name="proteins" type="number" handler={this.valueChange}/>
                            <label className={styles.label}>Proteins</label>
                        </div>
                        <div>
                            <Input name="carbs" type="number" handler={this.valueChange}/>
                            <label className={styles.label}>Carbs</label>
                        </div>
                        <div>
                            <Input name="fats" type="number" handler={this.valueChange}/>
                            <label className={styles.label}>Fats</label>
                        </div>
                    </div>
                    <div>
                        <Input name="cals" type="number" handler={this.valueChange}/>
                        <label className={styles.label}>Cals</label>
                    </div>
                    <div>
                        <Input name="servings" type="number" handler={this.valueChange}/>
                        <label className={styles.label}>Servings</label>
                    </div>
                    <div>
                        <Input name="time" type="time" handler={this.valueChange}/>
                        <label className={styles.label}>Time</label>
                    </div>
                    <div>
                        <TextArea name="recipe" handler={this.valueChange}/>
                        <label className={styles.label}>Recipe</label>
                    </div>
                    <div>

                    </div>
                    <input type="button"   onClick={()=>this.createProduct(obj)} value="Send Message"/>
                </form>
            </div>
        )
    }
}
class Input extends Component{
    state = {
        length: 0
    }
    valueChange = (event) => {
        const {value} = event.target;
        this.setState({
            length: value.length
        })
    };
    render () {
        let inputClass = classNames({
            [styles.input__active]: this.state.length > 0,
        });
        return <input className={inputClass} name={this.props.name} onChange={(e)=>{this.valueChange(e);this.props.handler(e)}}  type={this.props.type}/>
    }
};
class TextArea extends Component{
    state = {
        length: 0
    }
    valueChange = (event) => {
        const {value} = event.target;
        this.setState({
            length: value.length
        })
    };
    render () {
        let inputClass = classNames({
            [styles.input__active]: this.state.length > 0,
        });
        return <textarea className={inputClass} name={this.props.name} onChange={(e)=>{this.valueChange(e);this.props.handler(e)}}  type={this.props.type}/>
    }
};
export default CreateRecipe;