
import { List, ListSubheader, ListItem, ListItemText, Autocomplete, Stack, TextField, BottomNavigation, BottomNavigationAction, Badge, IconButton, useScrollTrigger, Container, AppBar, Box, CssBaseline, Toolbar, Typography, Slide } from '@mui/material';
import { useState } from 'react';
import styles from './roomservice.module.css'
import ListHolder from './Components/ListHolder/ListHolder';
import SearchBar from './Components/SearchBar/SearchBar';
import { FavoriteOutlined, Folder, Home, LocalAirport, Person, Person2, Person3, PersonOffOutlined, Restore, Shop, ShoppingCart } from '@mui/icons-material';
import { restaurantBanner } from '../../../assets/imageStore';
import React from 'react';
import { red } from '@mui/material/colors';
import { useNavigate } from 'react-router-dom';


interface Props {
  /**
   * Injected by the documentation to work in an iframe.
   * You won't need it on your project.
   */
  window?: () => Window;
  children?: React.ReactElement<unknown>;
}

function HideOnScroll(props: Props) {
  const { children, window } = props;
  // Note that you normally won't need to set the window ref as useScrollTrigger
  // will default to window.
  // This is only being set here because the demo is in an iframe.
  const trigger = useScrollTrigger({
    target: window ? window() : undefined,
  });

  return (
    <Slide appear={false} direction="down" in={!trigger}>
      {children ?? <div />}
    </Slide>
  );
}

export default function RoomService(props:Props){
    
    return(
 <React.Fragment>
      <CssBaseline />
      <HideOnScroll {...props}>
        <AppBar>
          <Toolbar style={{backgroundColor:"green", padding:"0px"}}>
            <div className={styles.topSection}>
            {/* <img className={styles.Banner} src={retaurantBanner}/> */}
            <h2>The Hotel Restaurant</h2>
            <b>4.5★</b>
            <b>08:00 - 21:00</b>
            {/* <SearchBar /> */}
          </div>
          </Toolbar>
        </AppBar>
      </HideOnScroll>
      <Toolbar />
      <Container style={{padding:"0px", paddingBottom:"15px"}}>
        <Box sx={{ my: 2, pb:5 }}>
          <div className={styles.container}>

          <div className={styles.middleSection}>
            <ListHolder/>
          </div>
        </div>
        </Box>
      </Container>
    </React.Fragment>
    );
}