import React, { useEffect, useState, useRef } from 'react';
import styles from '../scss/Dropzone.scss';

export const Previews = React.memo(props => {
    const [files, setFiles] = useState({});
    const [currentDragFile, setDragFile] = useState(null);
    const [currentDragIndex, setDraggedIndex] = useState(null);
    const [currentDropIndex, setDroppedIndex] = useState(0);
    const [flag, setFlag] = useState(true);
    const rows = [];
    for (let i = 0; i < 6; i++) {
        rows.push(
            <div
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
                {files[`${i}`] ? (
                    <img
                        className={styles.active_img}
                        src={URL.createObjectURL(files[`${i}`])}
                        alt=""
                    />
                ) : null}
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
                            setFiles({
                                ...files,
                                [`${currentDragIndex}`]: files[e.target.id],
                                [`${e.target.id}`]: currentDragFile,
                            });
                        }
                    }}
                />
            </div>,
        );
    }
    useEffect(() => {
        props.valueChange(files);
    }, [files]);
    return (
        <section className={styles.dropZone}>
            <div>
                <div className={styles.upload__gallery}>{rows}</div>
            </div>
        </section>
    );
});
