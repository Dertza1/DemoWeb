import React from 'react'
import { Stack, Link, Checkbox } from '@mui/material'
import logo from '../logo.svg'
import { Navigate, useNavigate } from 'react-router-dom'
import { blue } from '@mui/material/colors';
import CenterContainers from './CenterContainers';

export default function Elements() {

  const navigate = useNavigate();

  const edit = () => {
    navigate("/product")
  }

  return (
    <CenterContainers>
      <Link onClick={edit} underline="none" color="black" >
        <Stack
          direction="row"
          justifyContent="center"
          alignItems="center"
          margin={1}
          borderBottom={1}
          borderTop={1}
          borderRadius={1}
          borderColor={blue[200]}
          width='62vw'
        >
          <img src={logo} width='150' height='150' alt="" />
          <Stack
            alignItems="baseline"
            ml='15%'
            mr='45%'
          >
            <b>Название</b>
            <label>Описание</label>
            <label>Производитель:</label>
            <label>Цена:</label>
          </Stack>
          <Stack>
            <b>Наличие</b>
            <Checkbox 
            disabled 
            checked
            sx={{
              '&.Mui-disabled': {
                color: blue[300],
              },
              '&.Mui-checked': {
                color: blue[300],
              }
            }}
            />
          </Stack>
        </Stack>
      </Link>
    </CenterContainers>
  )
}
