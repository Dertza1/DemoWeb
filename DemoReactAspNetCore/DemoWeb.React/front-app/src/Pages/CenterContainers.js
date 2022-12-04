import { Grid } from '@mui/material'
import React from 'react'

export default function CenterContainers(props) {

    return (
        <Grid container
            direction="column"
            alignItems="center">
            <Grid item
                xs={1}>
                {props.children}
            </Grid>
        </Grid>
    )
}