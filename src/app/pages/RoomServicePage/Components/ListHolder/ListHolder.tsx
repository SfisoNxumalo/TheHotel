import { List, ListSubheader, ListItem, ListItemText, Button, Card, CardActions, CardContent, CardMedia, Typography } from "@mui/material";
import styles from './ListHolder.module.css'
import { restaurantBanner } from "../../../../../assets/imageStore";
import { useNavigate } from "react-router-dom";
export default function ListHolder(){
    const navigate = useNavigate();
    return (
        <List
      sx={{
        width: '100%',
        // maxWidth: 360,
        bgcolor: 'background.paper',
        position: 'relative',
        overflow: 'auto',
        // maxHeight: 900,
        '& ul': { padding: 0 },
      }}
      subheader={<li />}
    >
      {[0, 1, 2, 3,4].map((sectionId) => (
        <li key={`section-${sectionId}`}>
          <ul>
            <ListSubheader>{`I'm sticky ${sectionId}`}</ListSubheader>
            <div className={styles.ItemHolder}>
              {[0, 1, 2].map((item) => (
                <ListItem key={`item-${sectionId}-${item}`}>
                  {/* <Card>
                      <CardMedia
                        component="img"
                        alt="green iguana"
                        height="140"
                        image={retaurantBanner}
                      />
                      <CardContent>
                        <Typography gutterBottom variant="h5" component="div">
                          Lizard
                        </Typography>
                        <Typography variant="body2" sx={{ color: 'text.secondary' }}>
                          Lizards are a widespread group of squamate reptiles, with over 6,000
                          species, ranging across all continents except Antarctica
                        </Typography>
                      </CardContent>
                      <CardActions>
                        <Button size="small">Share</Button>
                        <Button size="small">Learn More</Button>
                      </CardActions>
                    </Card> */}
                    <div onClick={()=>{navigate(`/view-one/item-${sectionId}-${item}`)}} className={styles.menuItem4}>
                      <label className={styles.promo}>Out of Stock</label>
                      <div className={styles.menuItem2}>

                          <div className={styles.imgho}>
                              <img className={styles.mainlogo2} src={restaurantBanner}/>
                          </div>
                          
                          <div className={styles.prodtext}>
                              <label>This is a bro</label>

                              <div className={styles.pchold}>
                                  <div className={styles.pr}>
                                      <label className={styles.price}>R10000</label>
                                      {/* <label className={styles.price}>R</label>
                                      <label  className={styles.price}>R</label> */}
                                  </div>
                                  <button className={styles.actionbtn}  type="button">
                                      vv
                                  </button>
                              </div>
                              
                          </div>
                          <label className={styles.promoLabel}>Promotion!</label>
                          
                      </div>
                      
                  </div>
                </ListItem>
              ))}
            </div>
            
          </ul>
        </li>
      ))}
    </List>
    );
}