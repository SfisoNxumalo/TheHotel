import styles from './RightChatItem.module.css'

export default function RightChatItem(){
    return(
        <div className={styles.holder}>
            <div>
                <p>
                    Lorem ipsum dolor sit amet consectetur adipisicing elit. Deleniti, 
                    modi suscipit? Nisi dolorum repudiandae praesentium quam omnis, 
                    sapiente neque! Possimus earum impedit sequi voluptatum quas facere veniam magnam repellat veritatis.
                </p>
                <label>12:00</label>
            </div>
        </div>
    )
}