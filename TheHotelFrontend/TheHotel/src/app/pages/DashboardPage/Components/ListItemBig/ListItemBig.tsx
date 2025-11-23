import styles from './ListItemStyles.module.css'
import { roomServiceImg, stayImg } from '../../../../../assets/imageStore';

export default function ListItemBig()
{
    return(
        <div className={styles.holder}>
            <div className={styles.Top}>
                <h5>Your stay with us</h5>
            </div>
            
            <div className={styles.Middle}>

                <div className={styles.itemDetails}>
                    {/* <p>View full booking details</p> */}
                </div>

                <div className={styles.itemImage}>
                    <img src={stayImg} />
                </div>
            </div>

            <div className={styles.Bottom}>
                <div className={styles.Checks}>
                    <label className={styles.lblChecks}>Check-in</label>
                    <label className={styles.lblChecksDate}>Mon 24 Nov</label>
                    <label className={styles.lblChecksTime}>10:00</label>
                </div>
                <hr/>
                {/* <div className={styles.CheckDivider}>

                </div> */}
                <div className={styles.Checks}>
                    <label className={styles.lblChecks}>Check-out</label>
                    <label className={styles.lblChecksDate}>Thurs 27 Nov</label>
                    <label className={styles.lblChecksTime}>15:00</label>
                </div>

            </div>
            

        </div>
    );
}