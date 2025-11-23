import styles from './ListItemStyles.module.css'

interface ListProps{
    image:string;
    title:string;
    holderClick: () => void
}
export default function ListItemSmall({image, title, holderClick}:ListProps)
{
    
    return(
        <div onClick={holderClick} className={styles.holder}>
            <div className={styles.itemDetails}>
                {/* <h5>Room Service</h5> */}
                 <p>{title}</p>
                
            </div>
            <div className={styles.itemImage}>
                <img src={image} />
            </div>

        </div>
    );
}