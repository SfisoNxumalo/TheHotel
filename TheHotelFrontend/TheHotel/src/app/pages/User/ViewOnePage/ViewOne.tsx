import { AppBar, Button, Container, CssBaseline, TextField, Toolbar, Typography, useScrollTrigger } from '@mui/material';
import styles from './ViewOne.module.css'
import React, { useEffect, useState } from 'react';
import { useNavigate, useParams } from 'react-router-dom';
import globalStyles from '../../../../GlobalStyles/globalStyle.module.css'
import { useCartStore } from '../../../../stores/cartStore';
import { GoArrowLeft } from 'react-icons/go';
import { CartItem } from '../../../../Interfaces/CartItem';
import { Product } from '../../../../Interfaces/products';
import { getMenuItemById } from '../../../../services/roomServiceService';


interface Props {
  /**
   * Injected by the documentation to work in an iframe.
   * You won't need it on your project.
   */
  window?: () => Window;
  children?: React.ReactElement<{ elevation?: number }>;
}

function ElevationScroll(props: Props) {
  const { children, window } = props;
  // Note that you normally won't need to set the window ref as useScrollTrigger
  // will default to window.
  // This is only being set here because the demo is in an iframe.
  const trigger = useScrollTrigger({
    disableHysteresis: true,
    threshold: 200,
    target: window ? window() : undefined,
  });

  return children
    ? React.cloneElement(children, {
        elevation: trigger ? 4 : 0,
        
      })
    : null;
}


export default function ViewOne(props:Props){
  const navigate = useNavigate();
   const addItem = useCartStore((state) => state.addItem);

  const [menuItem, setMenuItem] = useState<Product>();
  const [note, setNote] = useState<string>("");


  const { id } = useParams<{ id: string }>();

  const handleAddToCart = () => {

    if(!menuItem?.id) return
    const item: CartItem = { ...menuItem, quantity: 1, note };
    addItem(item);
    setNote("");
  };

  useEffect(() => {
    const getData = async () => {

      if(!id) return

      const res = await getMenuItemById(id);

      if(res.status == 200){
        setMenuItem(res.data)
      }
    }
    getData()
  },[])

    
    return (
<>
            
<React.Fragment>
      <CssBaseline />
      <ElevationScroll {...props}>
        <AppBar >

          <Toolbar style={{paddingLeft: '5px'}}>
            <button className={globalStyles.backButton} onClick={()=>navigate(-1)}><GoArrowLeft /></button>
            <Typography variant="h6" component="div">
              {menuItem?.itemName}
            </Typography>
          </Toolbar>
          
        </AppBar>
      </ElevationScroll>
      <Toolbar />
      <Container sx={{padding:0}}>
        <div className={styles.container} style={{backgroundImage:`url(${menuItem?.image})`}}>
        </div>
        <div className={styles.contentHolder}>

            <h4>R{menuItem?.price}</h4>
            
            <h6>Description:</h6>
            <p>{menuItem?.description ?? 'No Description'}</p>
        
            {/* <h6>Ingridients:</h6>
            <p>Lorem ipsum dolor sit amet consectetur adipisicing elit. Modi autem nostrum ratione sint corporis ex, recusandae, ut doloremque itaque minima cum, natus molestias doloribus molestiae dolore tenetur id! Itaque, quibusdam.</p> */}

            <h6>Notes:</h6>
            <TextField
              id="outlined-textarea"
              label=""
              placeholder="Add any extra notes"
              multiline
              size='small'
              value={note} 
              onChange={(event)=> {
                  setNote(event.target.value);
              }}
            />

            <div className={styles.cartButtonHolder}> 
                <Button onClick={handleAddToCart} variant="contained">Add to cart</Button>
            </div>
        </div>     
    </Container>
    </React.Fragment>
</>
        
        
    );
}