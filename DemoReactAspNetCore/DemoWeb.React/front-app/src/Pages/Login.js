import React, { useState } from 'react'
import { Box, Button, Card, CardContent, TextField } from '@mui/material'
import Center from './Center'
import useForm from '../Hooks/useForm'
import { Navigate, useNavigate } from 'react-router-dom'

const getFreshModeObject = () => ({
    email: '',
    password: ''
})

export default function Login() {

    const navigate = useNavigate();

    const {
        values,
        setValues,
        errors,
        setErrors,
        handleInputChange
    } = useForm(getFreshModeObject);

    const login = e => {
        //e.preventDefault();
        //if (validate()) {
        //    console.log(values)
        //    navigate('/main')
        //}
        navigate('/main')
    }

    const validate = () => {
        let temp = {}
        temp.email = (/\S+@\S+\.\S+/).test(values.email) ? "" : "Неверно введена электронная почта."
        temp.password = values.password !== "" ? "" : "Введите пароль."
        setErrors(temp)
        return Object.values(temp).every(x => x === "")
    }

    return (
        <Center>
            <Card sx={{
                width: 500
            }}>
                <CardContent sx={{ textAlign: 'center' }}>
                    <Box sx={{
                        '& .MuiTextField-root': {
                            margin: 1,
                            width: '90%'
                        }
                    }}>
                        <form noValidate onSubmit={login}>
                            <TextField
                                disabled
                                label="Электронная почта"
                                name="email"
                                value={values.email}
                                onChange={handleInputChange}
                                variant="filled"
                                {...(errors.email && { error: true, helperText: errors.email })}
                            />
                            <TextField
                                disabled
                                label="Пароль"
                                name="password"
                                value={values.password}
                                onChange={handleInputChange}
                                variant="filled"
                                type="password"
                                {...(errors.password && { error: true, helperText: errors.password })}
                            />
                            <Button
                                variant="outlined"
                                size="large"
                                type="submit"
                                sx={{
                                    width: '90%'
                                }}
                            >
                                Войти
                            </Button>
                        </form>
                    </Box>
                </CardContent>
            </Card>
        </Center>
    )

}
