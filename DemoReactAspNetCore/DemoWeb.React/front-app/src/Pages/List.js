import React, { useEffect, useState } from 'react'
import { Box, Button, TextField, MenuItem, Select, FormControl, InputLabel, IconButton } from '@mui/material'
import { Navigate, useNavigate } from 'react-router-dom'
import Elements from './Elements'
import KeyboardArrowUpIcon from '@mui/icons-material/KeyboardArrowUp';
import { blue } from '@mui/material/colors';
import { createAPIEndpoint, ENDPOINT } from '../Api';

export default function List() {

    const [elementsList, setElementList] = React.useState([]);
    const [sort, setSort] = React.useState('');
    const [filter, setFilter] = React.useState('');
    const navigate = useNavigate();
    //const [prd, setPrd] = useState([]);

    // useEffect(() => {
    //     createAPIEndpoint(ENDPOINT.product)
    //         .fetch()
    //         .then(res => {
    //             setPrd(res.data)
    //             console.log(res.data)
    //         })
    //         .catch(err => { console.log(err); })
    // },[])

    const [posts, setPosts] = useState([]);

    function getPosts() {
        const url = "http://localhost:5000/api/Product/";
        fetch(url, {
            method: 'GET'
        })
            .then(response => response.json())
            .then(postsFromServer => {
                console.log(postsFromServer);
                setPosts(postsFromServer);
            })
            .catch(err => { console.log(err); })
    }

    const onAddBtnClick = event => {
        setElementList(elementsList.concat(<Product key={elementsList.length} />));
    };

    const handleChangeSort = (event) => {
        setSort(event.target.value);
    };

    const handleChangeFilter = (event) => {
        setFilter(event.target.value);
    };

    const logout = () => {
        navigate("/")
    }

    const edit = () => {
        navigate("/product")
    }

    const upScroll = () => {
        window.scrollTo(0, 0)
    }

    const Product = () => {
        return <Elements></Elements>;
    };

    return (
        <Box
            textAlign='right'
            height='100vh'
        >
            <Box sx={{
                '& .MuiButton-root': {
                    margin: 1,
                    width: 120,
                    height: 56
                },
                textAlign: 'center',
                '& .MuiTextField-root': {
                    margin: 1,
                    width: 250,
                }
            }}>
                <header>
                    <Button
                        variant="outlined"
                        size="large"
                        type="submit"
                        onClick={getPosts}
                    >Добавить</Button>
                    <Button
                        disabled
                        variant="outlined"
                        size="large"
                        type="submit"
                    //onClick={edit}
                    >Удалить</Button>
                    <TextField
                        disabled
                        label="Поиск"
                        name="search"
                        variant="filled"
                    />
                    <FormControl variant="filled" sx={{ m: 1, minWidth: 250, textAlign: 'left' }}>
                        <InputLabel>Фильтрация</InputLabel>
                        <Select
                            value={filter}
                            onChange={handleChangeFilter}
                        >
                            <MenuItem value="1"></MenuItem>
                            <MenuItem value="2">Из бд</MenuItem>
                        </Select>
                    </FormControl>
                    <FormControl variant="filled" sx={{ m: 1, minWidth: 250, textAlign: 'left' }}>
                        <InputLabel>Сортировка</InputLabel>
                        <Select
                            value={sort}
                            onChange={handleChangeSort}
                        >
                            <MenuItem value="up">Возрастания</MenuItem>
                            <MenuItem value="down">Убывания</MenuItem>
                        </Select>
                    </FormControl>
                    <Button
                        variant="outlined"
                        size="large"
                        type="submit"
                        onClick={logout}
                    >Выйти</Button>
                </header>
            </Box>
            <Box>
                <Elements></Elements>
                {elementsList}
            </Box>
            <footer style={{ marginTop: '-5.5vh' }}>
                <IconButton
                    sx={{ color: blue[900] }}
                    onClick={upScroll}
                    size="large"
                >
                    <KeyboardArrowUpIcon />
                </IconButton>
            </footer>
        </Box>
    )
}
