import styles from './ListItemStyles.module.css'
import { roomServiceImg } from '../../../../../assets/imageStore';

export default function ListItemSmall()
{
    return(
        <div className={styles.holder}>
            <div className={styles.itemDetails}>
                <h5>Room Service</h5>
                <p>Let's find you something to eat.</p>
            </div>
            <div className={styles.itemImage}>
                <img src={roomServiceImg} />
            </div>

        </div>
    );
}