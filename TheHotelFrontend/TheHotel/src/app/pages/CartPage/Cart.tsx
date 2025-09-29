import { Card, Box, CardContent, Typography, IconButton, CardMedia } from "@mui/material";
import { useTheme } from "styled-components";
import { restaurantBanner } from "../../../assets/imageStore";
import globalStyles from '../../../GlobalStyles/globalStyle.module.css'
import styles from './Cart.module.css'
import { useNavigate } from "react-router-dom";
import { GoArrowLeft } from "react-icons/go";

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
</div>
    

    <hr/>

    <label>SubTotal:</label> <label>R2000</label>
</div>


  );
}