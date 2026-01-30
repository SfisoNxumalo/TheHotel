import {
  Box,
  Grid,
  Card,
  CardContent,
  Typography,
  IconButton,
  AppBar,
  Avatar,
  Badge,
  BadgeProps,
  Container,
  CssBaseline,
  Slide,
  styled,
  Toolbar,
  useScrollTrigger,
} from "@mui/material";
import { useNavigate } from "react-router-dom";
import ChatBubbleOutlineIcon from "@mui/icons-material/ChatBubbleOutline";
import ReceiptLongIcon from "@mui/icons-material/ReceiptLong";
import BarChartIcon from "@mui/icons-material/BarChart";
import { deepOrange } from "@mui/material/colors";
import React, { useState } from "react";
import LogoutIcon from '@mui/icons-material/Logout';

import styles from '../../DashboardPage/styles/DashboardStyles.module.css'
import { dashIma } from "../../../../assets/imageStore";
import { useAuthStore } from "../../../../stores/authStore";
import RateDialog from "../../DashboardPage/Components/RateDialog/RateDialog";


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

  const StyledBadge = styled(Badge)<BadgeProps>(() => ({
    '& .MuiBadge-badge': {
      right: 0,
      top: 0,
      border: `2px solid var(--app-color)`,
      padding: '0 4px',
    },
  }));
  
  function Compo(props: Props){
    const user = useAuthStore((s) => s.user);
    const logout = useAuthStore.getState().logout;
    const navigate = useNavigate();
    return(
      <React.Fragment >
                      <CssBaseline />
                      <HideOnScroll  {...props} >
                        <AppBar sx={{ backgroundColor: 'transparent', 
                                      boxShadow: 'none'
                                        }}> 
                          <Toolbar>
                            <div className={styles.MainDetailsHolder}>
                                <div className={styles.holder} style={{height:'100px'}}>
                                  <div  className={styles.holderItems}>
                                    <div className={styles.holderItems} style={{width:'100%', display: 'flex'}}>
                                    <Avatar sx={{ bgcolor: deepOrange[500]}}>{user?.fullName.charAt(0).toLocaleUpperCase()}</Avatar>
                                    <label> Hello {`${user?.fullName.charAt(0).toLocaleUpperCase()}${user?.fullName.substring(1)}`}</label>
                                  </div>
                                  <IconButton onClick={()=>{logout(), navigate('/login') }} sx={{color:'white'}} aria-label="cart">
                                    <StyledBadge color="error">
                                      <LogoutIcon sx={{ fontSize: 20 }} />
                                    </StyledBadge>
                                  </IconButton>
                                  </div>
                                  <div className={styles.sthombeHolder}>
                                  <img className={styles.sthombe} src={dashIma}/>
                                </div>
                                </div>
                            </div>
                            
                          </Toolbar>
                        </AppBar>
                      </HideOnScroll>
                      <Toolbar />
                      <Container>
                        <Box sx={{ my: 2 }}>
                          {/* {[...new Array(12)]
                            .map(
                              () => `Cras mattis consectetur purus sit amet fermentum.
                Cras justo odio, dapibus ac facilisis in, egestas eget quam.
                Morbi leo risus, porta ac consectetur ac, vestibulum at eros.
                Praesent commodo cursus magna, vel scelerisque nisl consectetur et.`,
                            )
                            .join('\n')} */}
                        </Box>
                      </Container>
                    </React.Fragment>
    )
  }

export default function AdminDashboard() {
  const navigate = useNavigate();

  const tiles = [
    {
      title: "Chats",
      description: "View and manage user conversations",
      icon: <ChatBubbleOutlineIcon sx={{ fontSize: 36, color: "#3470ed" }} />,
      path: "/admin/chats",
    },
    {
      title: "Orders",
      description: "Manage all room service orders",
      icon: <ReceiptLongIcon sx={{ fontSize: 36, color: "#3470ed" }} />,
      path: "/admin/orders",
    },
    {
      title: "Analytics",
      description: "View performance insights & sales data",
      icon: <BarChartIcon sx={{ fontSize: 36, color: "#3470ed" }} />,
      path: "/admin/analytics",
    },
  ];

  const [open, setOpen] = useState(false);

   const closeDialog = ()=> {
      setOpen(false)
   }
    return(
        <section style={styles}>
           <div className={styles.topContainer}></div>
           <div className={styles.bottomContainer}></div>
           <div className={styles.overDiv}>
                <div className={styles.mainContainer}>
                    <div className={styles.mainContainerTop}>
                    <Compo/>
                    </div>
                    <div className={`${styles.mainContainerBottom} slide-up`}> 
                      <h4>Admin Dashboard</h4>
                      <Box sx={{ p: 1 }}>
                          {/* Header */}
                        

                          {/* Navigation Tiles */}
                          <Grid container spacing={4} columns={12}>
                            {tiles.map((item) => (
                              <Grid key={item.title} size={{ xs: 12, md: 4 }}>
                                <Card
                                  onClick={() => navigate(item.path)}
                                  sx={{
                                    p: 2,
                                    height: 180,
                                    borderRadius: 3,
                                    cursor: "pointer",
                                    transition: "0.25s ease",
                                    display: "flex",
                                    flexDirection: "column",
                                    justifyContent: "center",
                                    boxShadow: "0 2px 8px rgba(0,0,0,0.08)",
                                    "&:hover": {
                                      boxShadow: "0 4px 18px rgba(0,0,0,0.12)",
                                      transform: "translateY(-4px)",
                                    },
                                  }}
                                >
                                  <CardContent>
                                    <Box
                                      display="flex"
                                      justifyContent="center"
                                      alignItems="center"
                                      mb={2}
                                    >
                                      {item.icon}
                                    </Box>

                                    <Typography
                                      variant="h6"
                                      fontWeight={700}
                                      align="center"
                                      sx={{ mb: 1 }}
                                    >
                                      {item.title}
                                    </Typography>

                                    <Typography
                                      color="text.secondary"
                                      fontSize={14}
                                      align="center"
                                    >
                                      {item.description}
                                    </Typography>
                                  </CardContent>
                                </Card>
                              </Grid>
                            ))}
                          </Grid>
                        </Box>
                    </div>
                </div>
                
           </div>
           
           <RateDialog open={open} handleCloseDialog={closeDialog}/>
        </section>
    )
}
