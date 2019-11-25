import React, { PureComponent, useEffect, useState } from 'react';
import { faTimes } from '@fortawesome/free-solid-svg-icons';
import Modal from 'react-modal';
import Select from 'react-select';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import styles from '../scss/Search.scss';

export class Search extends PureComponent {
    state = {
        name: '',
        ingredientsInclude: [],
        ingredientsExclude: [],
        include: [],
        exclude: [],
    };

    componentDidMount() {
        Modal.setAppElement('body');
        const { ingredientsList, setIngredients } = this.props;
        if (!ingredientsList.length) setIngredients();
    }

    valueChange = event => {
        const { name, value } = event.target;
        this.setState(prevState => ({
            ...prevState,
            [name]: value,
        }));
    };
    filterByIngredient = () => {

        this.props.filterByIngredient({
            includeIngredients: this.state.ingredientsInclude.map(e => e.value),
            excludeIngredients: this.state.ingredientsExclude.map(e => e.value),
        })
    }

    comparer = otherArray => {
        return current => {
            return (
                otherArray.filter(function(other) {
                    return other.value === current.value && other.display === current.display;
                }).length === 0
            );
        };
    };

    ingredientsIncludeChange = ingredient => {
        ingredient == null ? (ingredient = []) : ingredient;
        this.setState(prevState => ({
            ingredientsInclude: ingredient,
        }));
    };

    ingredientsExcludeChange = ingredient => {
        ingredient == null ? (ingredient = []) : ingredient;
        this.setState(prevState => ({
            ingredientsExclude: ingredient,
        }));
    };

    render() {
        const { modalIsOpen, closeModal, customStyles, ingredientsList } = this.props;
        let ingredientsOptions = [];
        ingredientsList.map(item => ingredientsOptions.push({ value: item.id, label: item.name }));
        if(this.state.ingredientsInclude !== null && this.state.ingredientsExclude !== null){
            ingredientsOptions = ingredientsOptions.filter(this.comparer(this.state.ingredientsInclude));
            ingredientsOptions = ingredientsOptions.filter(this.comparer(this.state.ingredientsExclude));
        }

        console.log(this.state);
        return (
            <Modal
                isOpen={modalIsOpen}
                onRequestClose={closeModal}
                style={customStyles}
                contentLabel="Search"
            >
                <button className={styles.closeAuth} onClick={closeModal}>
                    <FontAwesomeIcon icon={faTimes} />
                </button>
                <p className={styles.authTitle}>Search panel</p>
                <form className={styles.searchForm}>
                    <input placeholder="Name" name="name" type="text" onChange={this.valueChange} />
                    <div>
                        <Select
                            value={this.state.ingredientsInclude}
                            onChange={this.ingredientsIncludeChange}
                            options={ingredientsOptions}
                            placeholder="Include ingredients"
                            isMulti
                        />
                    </div>
                    <div>
                        <Select
                            value={this.state.ingredientsExclude}
                            onChange={this.ingredientsExcludeChange}
                            options={ingredientsOptions}
                            placeholder="Exclude ingredients"
                            isMulti
                        />
                    </div>
                    <button
                        className={styles.signInBtn}
                        onClick={e => {
                            e.preventDefault();
                            this.filterByIngredient();
                        }}
                        type="submit"
                    >
                        Search
                    </button>
                </form>
            </Modal>
        );
    }
}
