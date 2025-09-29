import styles from './ListItemStyles.module.css'
import { roomServiceImg } from '../../../../../assets/imageStore';
import { useNavigate } from 'react-router-dom';

export default function ListItemSmall()
{
    const navigate = useNavigate();
    return(
        <div onClick={()=> {navigate('/room-service')}} className={styles.holder}>
            <div className={styles.itemDetails}>
                {/* <h5>Room Service</h5> */}
                 <p>Let's find you something to eat.</p>
                
            </div>
            <div className={styles.itemImage}>
                <img src={roomServiceImg} />
            </div>

        </div>
    );
}