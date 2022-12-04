import React from 'react'
import { Box, Button, Card, CardContent, TextField, FormControl, InputLabel, Select, MenuItem } from '@mui/material'
import Center from './Center'
import { Navigate, useNavigate } from 'react-router-dom'

export default function Edit() {

  const [category, setCategory] = React.useState('');
  const navigate = useNavigate();

  const save = () => {
    navigate("/main")
  }

  const handleChangeCategory = (event) => {
    setCategory(event.target.value);
  };

  return (
    <Center>
      <Card sx={{
        width: '65vw',
        margin: 1
      }}>
        <CardContent sx={{ textAlign: 'center' }}>
          <Box sx={{
            '& .MuiTextField-root': {
              margin: 1,
              width: '90%'
            },
            '& .MuiFormControl-root': {
              margin: 1,
              width: '90%'
            },
            '& .MuiButton-root': {
              margin: 1,
              width: '45%'
            }
          }}>
            <TextField
              label="Наименование"
              name="name"
              variant="filled"
            />
            <FormControl variant="filled" sx={{ m: 1, minWidth: 250, textAlign: 'left' }}>
              <InputLabel>Категории</InputLabel>
              <Select
                value={category}
                onChange={handleChangeCategory}
              >
                <MenuItem value="db">Из бд</MenuItem>
              </Select>
            </FormControl>
            <TextField
              label="Количество на складе"
              name="count"
              variant="filled"
            />
            <TextField
              label="Единица измерения"
              name="unit"
              variant="filled"
            />
            <TextField
              label="Поставщик"
              name="provider"
              variant="filled"
            />
            <TextField
              label="Стоимость за единицу"
              name="cost"
              variant="filled"
            />
            <TextField
              disabled
              label="Изображение"
              name="image"
              variant="filled"
            />
            <TextField
              multiline
              rows={4}
              label="Описание"
              name="description"
              variant="filled"
            />
            <Button
              variant="outlined"
              size="large"
              type="submit"
              onClick={save}
            >
              Отменить
            </Button>
            <Button
              variant="outlined"
              size="large"
              type="submit"
              onClick={save}
            >
              Сохранить
            </Button>
          </Box>
        </CardContent>
      </Card>
    </Center>
  )
}
