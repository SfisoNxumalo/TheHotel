import styles from './ListItemStyles.module.css'
import { roomServiceImg } from '../../../../../assets/imageStore';
import { Link } from 'react-router-dom';

export default function ListItemSmall()
{
    return(
        <div className={styles.holder}>
            <div className={styles.itemDetails}>
                {/* <h5>Room Service</h5> */}
                 <Link to="/room-service"><p>Let's find you something to eat.</p></Link>
                
            </div>
            <div className={styles.itemImage}>
                <img src={roomServiceImg} />
            </div>

        </div>
    );
}