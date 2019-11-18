import React, { useEffect, useState, useRef } from 'react';
import axios from 'axios';
import styles from '../scss/Dropzone.scss';
import {FontAwesomeIcon} from "@fortawesome/react-fontawesome";
import {faTimes} from "@fortawesome/free-solid-svg-icons";

export const Previews = React.memo(props => {
    const { img } = props;
    const [files, setFiles] = useState({});
    const [currentDragFile, setDragFile] = useState(null);
    const [currentDragIndex, setDraggedIndex] = useState(null);
    const [currentDropIndex, setDroppedIndex] = useState(0);
    const [flag, setFlag] = useState(true);
    const rows = [];
    for (let i = 0; i < 6; i++) {
        rows.push(
            <div
                draggable={!!files[`${i}`]}
                key={i}
                className={styles.upload__thumb}
                onDragStart={e => {
                    e.target.style.opacity = 0.3;
                    setDraggedIndex(e.target.querySelector('input').id);
                    setDragFile(files[e.target.querySelector('input').id]);
                }}
                onDragOver={e => {
                    e.preventDefault();
                    e.target.style.boxShadow = '0px 0px 20px 0px rgba(0,0,0,0.75)';
                }}
                onDragLeave={e => {
                    e.target.style.boxShadow = '0px 0px 0px 0px rgba(0,0,0,0)';
                    e.target.style.backgroundColor = 'transparent';
                }}
                onDragEnd={e => {
                    e.target.style.opacity = 1;
                }}
                index={i}
            >
                {typeof files[`${i}`] === 'string' && typeof img[`${i}`] === 'string' && (
                    <img
                        className={styles.active_img}
                        src={files[`${i}`]}
                        alt=""
                    />
                )}
                {typeof files[`${i}`] === 'object' && files[`${i}`] !== null &&  typeof img[`${i}`] === 'object' &&
                img[`${i}`] !== null && (
                    <img
                        className={styles.active_img}
                        src={URL.createObjectURL(files[`${i}`])}
                        alt=""
                    />
                )}


                <p>+</p>
                <input
                    id={i}
                    type="file"
                    name="img"
                    onChange={e => {
                        console.log('target');
                        e.target.parentNode.setAttribute('draggable', true);
                        if (!files[e.target.id] || files[e.target.id] !== e.target.files[0]) {
                            console.log('changed');
                            setFiles({ ...files, [`${i}`]: e.target.files[0] });
                            setDraggedIndex(e.target.id);
                            setDragFile(files[e.target.id]);
                            setDroppedIndex(e.target.id);
                        }
                    }}
                    onDrop={e => {
                        console.log(currentDragIndex);
                        console.log(currentDropIndex);
                        setDroppedIndex(e.target.id);
                        e.target.parentNode.setAttribute('draggable', true);
                        if (files[currentDragIndex] && !files[currentDropIndex]) {
                            e.target.parentNode.parentNode.childNodes[
                                currentDragIndex
                            ].setAttribute('draggable', false);
                        }
                        setDragFile(null);
                        e.target.style.boxShadow = '0px 0px 0px 0px rgba(0,0,0,0)';
                        if (!currentDragFile && !files[e.target.id]) {
                            console.log(1);
                            setFlag(false);
                        } else if (currentDragFile && !files[e.target.id]) {
                            console.log(2);
                            e.target.parentNode.parentNode.childNodes[
                                currentDragIndex
                            ].setAttribute('draggable', false);
                            setFiles({
                                ...files,
                                [`${e.target.id}`]: currentDragFile,
                                [`${currentDragIndex}`]: null,
                            });
                        } else if (
                            !currentDragFile &&
                            files[e.target.id] &&
                            currentDragIndex === null
                        ) {
                            console.log(5);
                        } else if (!currentDragFile && files[e.target.id]) {
                            console.log(4);
                            console.log(flag);
                            setFiles({
                                ...files,
                                [`${e.target.id}`]: null,
                            });
                        } else if (!currentDragFile && files[e.target.id]) {
                            console.log(5);
                            setFiles({
                                ...files,
                                [`${currentDragIndex}`]: files[e.target.id],
                                [`${e.target.id}`]: null,
                            });
                        } else {
                            console.log(6);
                            console.log(currentDragFile);
                            console.log(files[e.target.id])
                            setFiles({
                                ...files,
                                [`${currentDragIndex}`]: files[e.target.id],
                                [`${e.target.id}`]: currentDragFile,
                            });
                        }
                    }}
                />
                {files[`${i}`]  &&
                    <button className={styles.deleteImage} onClick={e => {
                        e.preventDefault();
                       setFiles({ ...files, [`${i}`]: null })
                    }}>
                        <FontAwesomeIcon icon={faTimes} />
                    </button>}

            </div>,
        );
    }
    useEffect(() => {
        if(img.length > 0){
            img.forEach((value,i)=>  setFiles({
                ...files,
                [`${i}`]:value.url,
            }));
        }
        props.valueChange(files);
    }, [files, props]);
    return (
        <section className={styles.dropZone}>
            <div>
                <div className={styles.upload__gallery}>{rows}</div>
            </div>
        </section>
    );
});
