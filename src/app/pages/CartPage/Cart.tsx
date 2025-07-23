import { Card, Box, CardContent, Typography, IconButton, CardMedia } from "@mui/material";
import { useTheme } from "styled-components";
import { restaurantBanner } from "../../../assets/imageStore";

import styles from './Cart.module.css'

export default function Cart(){

  return (
<div className={styles.holder}>

    <h3>Cart</h3>

    <Card sx={{ display: 'flex' }}>
      <Box  style={{width:"100%"}} sx={{ display: 'flex', flexDirection: 'column' }}>
        <CardContent sx={{ flex: '1 0 auto' }}>
          <Typography component="div" variant="h5">
            Beef
          </Typography>
          <Typography
            variant="subtitle1"
            component="div"
            sx={{ color: 'text.secondary' }}
          >
            Quantity: 5
          </Typography>
        </CardContent>
        <Box sx={{ display: 'flex', alignItems: 'center', pl: 1, pb: 1 }}>
          bn
        </Box>
      </Box>
      <CardMedia
        component="img"
        sx={{ width: 151 }}
        image={restaurantBanner}
        alt="Live from space album cover"
      />
    </Card>

    <hr/>

    <label>SubTotal:</label> <label>R2000</label>
</div>


  );
}