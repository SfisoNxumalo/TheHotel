import styles from './ListItemStyles.module.css'

export default function ListItemSmall({label, Img}:any)
{
    return(
        <div className={styles.holder}>
            <div className={styles.itemImage}>
                <img src={Img} />
            </div>
            <div className={styles.itemDetails}>
                <h6>{label}</h6>
            </div>
            

        </div>
    );
}