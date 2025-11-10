import { AppBar, Box, Button, Container, CssBaseline, IconButton, TextField, Toolbar, Typography, useScrollTrigger } from '@mui/material';
import styles from './ViewOne.module.css'
import React from 'react';
import DeleteIcon from '@mui/icons-material/Delete';
import { useNavigate } from 'react-router-dom';
import globalStyles from '../../../GlobalStyles/globalStyle.module.css'
import { GoArrowLeft } from 'react-icons/go';
import { FaPlus } from "react-icons/fa6";
import Stack from '@mui/material/Stack';
import { TiMinus } from "react-icons/ti";

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
// console.log(...props);
    const navigate = useNavigate();
    return (
<>
            <div className={styles.container}>
        </div>
<React.Fragment>
      <CssBaseline />
      <ElevationScroll {...props}>
        <AppBar >

          <Toolbar style={{paddingLeft: '5px'}}>
            <button className={globalStyles.backButton} onClick={()=>navigate(-1)}><GoArrowLeft /></button>
            <Typography variant="h6" component="div">
              Chicken and pizza
            </Typography>
            
          </Toolbar>
          
        </AppBar>
      </ElevationScroll>
      <Toolbar />
      <Container>
        <div className={styles.contentHolder}>

            <h4>R1000.00</h4>
            

            <h6>Description:</h6>
            <p>Lorem ipsum dolor sit amet consectetur adipisicing elit. Modi autem nostrum ratione sint corporis ex, recusandae, ut doloremque itaque minima cum, natus molestias doloribus molestiae dolore tenetur id! Itaque, quibusdam.</p>
        
            <h6>Ingridients:</h6>
            <p>Lorem ipsum dolor sit amet consectetur adipisicing elit. Modi autem nostrum ratione sint corporis ex, recusandae, ut doloremque itaque minima cum, natus molestias doloribus molestiae dolore tenetur id! Itaque, quibusdam.</p>

            <label>Notes:</label>
            <TextField
              id="outlined-textarea"
              label=""
              placeholder="Add any extra notes"
              multiline
              size='small'
            />

            <div className={styles.cartButtonHolder}> 
                <button className={styles.incrementButton}><TiMinus/></button>
                  <label>12</label>
                <button className={styles.incrementButton}><FaPlus/></button>
                <Button variant="contained">Add to cart</Button>
            </div>
        </div>     
    </Container>
    </React.Fragment>
</>
        
        
    );
}