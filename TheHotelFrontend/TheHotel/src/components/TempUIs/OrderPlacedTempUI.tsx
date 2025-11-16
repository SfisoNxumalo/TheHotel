import { Button } from "@mui/material"
import { cookingGif } from "../../assets/imageStore"
import styles from './styles.module.css'
import { useLocation, useNavigate } from "react-router-dom";
import { useEffect } from "react";

export default function OrderPlacedUI(){
const location = useLocation();
  const order = location.state;
  const navigate = useNavigate();
  
  const orderId:string = order.orderId

    return(
        <div className={styles.main}>
            <div>
                <p>Your order was received by the restuarant and will be prepared for you</p>
                <img src={cookingGif}/>
            </div>{orderId}
            
            <Button className={styles.button} variant="contained">View Order</Button>
        </div>
    )
}