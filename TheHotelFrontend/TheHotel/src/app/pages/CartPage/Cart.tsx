import { Card, Box, CardContent, Typography, IconButton, CardMedia, Button, Grid } from "@mui/material";
import { useTheme } from "styled-components";
import { restaurantBanner } from "../../../assets/imageStore";
import globalStyles from '../../../GlobalStyles/globalStyle.module.css'
import styles from './Cart.module.css'
import { useNavigate } from "react-router-dom";
import { GoArrowLeft } from "react-icons/go";
import { FaPlus } from "react-icons/fa6";
import { TiMinus } from "react-icons/ti";

export default function Cart(){
const navigate = useNavigate();
  return (
<div className={styles.holder}>

<div style={{display:'flex'}}>
<button style={{color:'black'}} className={globalStyles.backButton} onClick={()=>navigate(-1)}><GoArrowLeft /></button>
    <h3>Cart</h3>
</div>
    
<div onClick={()=>{navigate(`/view-one/itemd`)}}>
<Card  sx={{ display: 'flex' }}>
      <Box  style={{width:"100%"}} sx={{ display: 'flex', flexDirection: 'column' }}>
        <CardContent sx={{ flex: '1 0 auto' }}>
          <Typography component="div" variant="h5">
            Beef
          </Typography>
        </CardContent>
        <Box sx={{ display: 'flex', alignItems: 'center', pl: 2, pb: 1 }}>
          
          <div className={styles.cartButtonHolder}> 
                <button className={styles.incrementButton}><TiMinus/></button>
                  <label>12</label>
                <button className={styles.incrementButton}><FaPlus/></button>
            </div>
        </Box>
      </Box>
      <CardMedia
        component="img"
        sx={{ width: 151 }}
        image={restaurantBanner}
        alt="Live from space album cover"
      />
    </Card>
</div>
<hr/>
<Grid container rowSpacing={1} columnSpacing={{ xs: 1, sm: 2, md: 3 }}>
  <Grid size={6}>
    <label>SubTotal:</label> <label>R2000</label>
  </Grid>
  <Grid justifyContent={'right'} display={'flex'} size={6}>
    <Button variant="contained">Checkout</Button>
  </Grid>
  
</Grid>


</div>


  );
}