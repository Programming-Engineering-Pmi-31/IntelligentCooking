import React,{Component} from 'react';
import styles from "../scss/CreateRecipe.scss"
import axios from 'axios'
import Select from 'react-select';
class CreateRecipe extends Component {
    state = {
        name:"",
        categories:[],
        description:"",
        image:null,
        time:"",
        ingridients:[],
        servings:0,
        proteins:0,
        carbohydrates :0,
        fats:0,
        calories: 0,
        recipe:"",
        likes:0,

    };
    categoriesChange = category => {
        console.log(category);
        this.setState(
            { categories: category }
        );
    };
    ingridientsChange = ingridient => {
        console.log(ingridient);
        this.setState(
            { ingridients:ingridient}
        );
    };

    createProduct = (product) =>{

        axios.post("https://localhost:5001/api/Dish",{
            title:this.state.name,
            img: this.state.image,
            description: this.state.description,
            ingridients: [],
            categories:[],
            recipe:this.state.recipe,
            time:this.state.time,
            cals:this.state.calories,
            servings:this.state.servings,
            fats:this.state.fats,
            proteins:this.state.proteins,
            carbs:this.state.carbohydrates
        })
            .then(res=>console.log(res))
    }
    // createProduct = (product) =>{
    //     const formData = new FormData()
    //     formData.append(
    //         'image',
    //         this.state.image,
    //         this.state.image.name)
    //     console.log(formData);
    //     return fetch(`http://localhost:4000/dishes`, {
    //         method: 'POST',
    //         body: JSON.stringify(
    //             {
    //                 title:this.state.name,
    //                 img: this.state.image,
    //                 description: this.state.description,
    //                 rating:0,
    //                 likes:0,
    //                 ingridients: this.state.ingridients,
    //                 categories:this.state.categories,
    //                 recipe:this.state.recipe,
    //                 time:this.state.time,
    //                 cals:this.state.calories,
    //                 servings:this.state.servings,
    //                 fats:this.state.fats,
    //                 proteins:this.state.proteins,
    //                 carbs:this.state.carbohydrates
    //             }
    //         ),
    //         headers: {
    //             'content-type': "application/json"
    //         }
    //     }).then(res=>res.json())
    // }
    fileChangedHandler = event => {
        const formData = new FormData()
        formData.append(
            'image',
            event.target.files[0]
        )
        this.setState({ image:formData })
    }
    // createDish = () =>{
    //     axios.post('/dishes.json', qs.stringify(){
    //         id:13,
    //         title:this.state.name,
    //         img: this.state.img,
    //         description: this.state.description,
    //         rating:0,
    //         likes:0,
    //         recipe:this.state.recipe,
    //         time:this.state.time,
    //         cals:this.state.calories,
    //         servings:this.state.servings,
    //         fats:this.state.fats,
    //         proteins:this.state.proteins,
    //         carbs:this.state.carbohydrates
    //     })
    //         .then(function (response) {
    //             console.log(response);
    //         })
    // }
    valueChange = (event) => {
        const { name, value,type } = event.target;
        console.log(name,value)
        this.setState((prevState) => ({
            [name]: type === 'number' ? parseFloat(value) : value
        }));
    };
    componentDidMount() {
        const {setIngridients,setCategories} = this.props;
        setIngridients();
        setCategories();
    }


    // const [recipe,changeRecipe] = useState({
    //     "name":"",
    //     "categories":[],
    //     "description":"",
    //     "image":"",
    //     "ingridients":[],
    //     "protein":0,
    //     "carbs":0,
    //     "fat":0,
    //     "recipe":""
    // })
    render() {
        console.log(this.state);
        const options = []
        let ingridientsOptions = [];
        let categoriesOptions = [];
        const {ingridients,categories} = this.props;
        ingridients.map(item => ingridientsOptions.push({value:item.id, label:item.name}))
        categories.map(item => categoriesOptions.push({value:item.id, label:item.name}))
        return (
            <div className={styles.form}>
                <h2>Create new recipe</h2>
                <form>
                    <div>
                        <input name="name" id='name-input' onChange={this.valueChange} type="text"/>
                        <label className={styles.label}>Name</label>
                    </div>
                    <div>
                        <input name="description" id='name-input' onChange={this.valueChange} type="text"/>
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
                        <input name="image" id='name-input' onChange={this.fileChangedHandler} type="file"/>
                        <label className={styles.label}>Image URL</label>
                    </div>
                    <div className={styles.form__selector}>
                        <Select
                            value={this.state.ingridients}
                            onChange={this.ingridientsChange}
                            options={ingridientsOptions}
                            isMulti={true}
                        />
                        <label className={styles.label}>Ingridients</label>
                    </div>
                    <div className={styles.input__flex}>
                        <div>
                            <input name="proteins" id='name-input' onChange={this.valueChange} type="number"/>
                            <label className={styles.label}>Proteins</label>
                        </div>
                        <div>
                            <input name="carbs" id='name-input' onChange={this.valueChange} type="number"/>
                            <label className={styles.label}>Carbs</label>
                        </div>
                        <div>
                            <input name="fats" id='name-input' onChange={this.valueChange} type="number"/>
                            <label className={styles.label}>Fats</label>
                        </div>
                    </div>
                    <div>
                        <input name="cals" id='name-input' onChange={this.valueChange} type="number"/>
                        <label className={styles.label}>Cals</label>
                    </div>
                    <div>
                        <input name="servings" id='name-input' onChange={this.valueChange} type="number"/>
                        <label className={styles.label}>Servings</label>
                    </div>
                    <div>
                        <input name="time" id='name-input' onChange={this.valueChange}  type="time"/>
                        <label className={styles.label}>Time</label>
                    </div>
                    <div>
                        <textarea onChange={this.valueChange}></textarea>
                        <label className={styles.label}>Recipe</label>
                    </div>
                    <input type="button" onClick={this.createProduct} value="Send Message"/>
                </form>
            </div>
        )
    }
}
export default CreateRecipe;