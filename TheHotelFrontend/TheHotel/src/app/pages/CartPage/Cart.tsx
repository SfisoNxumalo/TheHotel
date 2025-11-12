import { Card, Box, CardContent, Typography, IconButton, CardMedia, Button, Grid } from "@mui/material";
import { useTheme } from "styled-components";
import { restaurantBanner } from "../../../assets/imageStore";
import globalStyles from '../../../GlobalStyles/globalStyle.module.css'
import styles from './Cart.module.css'
import { useNavigate } from "react-router-dom";
import { GoArrowLeft } from "react-icons/go";
import { FaPlus } from "react-icons/fa6";
import { TiMinus } from "react-icons/ti";
import { useCartStore } from "../../../stores/cartStore";
import { IconTrashFilled } from '@tabler/icons-react';

export default function Cart(){

const navigate = useNavigate();
const { items, removeItem, updateQuantity, clearCart, total } = useCartStore();

const handleCheckout = () =>{
  console.log(items);
  
}

  return (
    <div className={styles.holder}>

      <div className={styles.cartTopBar}>
          <button style={{color:'black'}} className={globalStyles.backButton} onClick={()=>navigate(-1)}><GoArrowLeft /></button>
          <h3>Cart</h3>
      </div>
        
      {items.length === 0 ? (
            <p>Your cart is empty 🛍️</p>
          ) : (
            <div className={styles.itemHolders}>
              {items.map((item) => (
                <div style={{paddingBottom: '5px', cursor:'pointer'}} >
                  <Card key={item.id} sx={{ display: 'flex' }}>
                    <Box style={{width:"100%"}} sx={{ display: 'flex', flexDirection: 'column' }}>
                      <CardContent sx={{ flex: '1 0 auto' }} onClick={()=>{navigate(`/view-one/${item.id}`)}}>
                        <Typography component="div" variant="h6">
                          {item.itemName}
                        </Typography>
                        <p>R {item.price} ea</p>
                      </CardContent>
                      
                      <Box sx={{ display: 'flex', alignItems: 'center', pl: 2, pb: 1, pr:2 }}>
                        <div  className={styles.cartButtonHolder}> 
                              <button onClick={() =>
                                  updateQuantity(item.id, item.quantity - 1)
                                } className={styles.incrementButton}><TiMinus color="red"/></button>
                                <label>{item.quantity}</label>
                              <button onClick={() =>
                                  updateQuantity(item.id, item.quantity + 1)
                                } className={styles.incrementButton}><FaPlus/></button>
                          </div>
                          <div style={{width:'100%', height:'100%'}} onClick={()=>{navigate(`/view-one/${item.id}`)}}></div>
                          <button onClick={() => removeItem(item.id)} className={styles.DeleteCartItem}><IconTrashFilled color="red" size={20}/></button>
                      </Box>
                    </Box>

                    <CardMedia
                      component="img"
                      sx={{ width: 151 }}
                      image={restaurantBanner}
                      alt="Live from space album cover"
                      onClick={()=>{navigate(`/view-one/${item.id}`)}}
                    />
                  </Card>
                  <hr></hr>
                </div>
                
              ))}
            </div>
          )
      }

      <div className={styles.bottomNav}>
        <Grid width={'100%'} display={'flex'} justifyContent={'space-between'} container rowSpacing={1} columnSpacing={{ xs: 1, sm: 2, md: 3 }}>
          <Grid display={'flex'} gap={0.5} alignItems={'center'} size={6}>
            <label>SubTotal: </label> <label><b>R{total().toFixed(2)}</b></label>
          </Grid>
          <Grid  justifyContent={'right'} display={'flex'} size={6}>
            <Button onClick={handleCheckout} disabled={items.length === 0} variant="contained">Checkout</Button>
          </Grid>
        </Grid>
      </div>
        
      
    </div>


  );
}